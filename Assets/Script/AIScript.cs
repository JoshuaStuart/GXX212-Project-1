using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AIScript : MonoBehaviour
{
    public int attackTurn;
    public GameObject obsticlePrefab;
    public Vector3 lvlBounds = new Vector3(3,3,3);
    int amount = 0;



    [Header("UI")]
    public GameObject uiComponent;
    public Text uiText;
    string phrase;

    public enum stateMachine
    {
        calulating,
        waiting,
        attacking
    }
    public stateMachine currentState;

    private void Start()
    {
        uiComponent.SetActive(false);
        currentState = stateMachine.calulating;
        calculating();
    }

    private void Update()
    {
        if (GameManager.instance.turnsRemaining == attackTurn)
        {
            attack();
        }
        if (blinded)
        {
            GameObject[] bubbles = GameObject.FindGameObjectsWithTag("Bubble");

            foreach (GameObject bubble in bubbles)
            {
                bubble.GetComponent<BallScript>().valueText.enabled = false;
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {

                foreach (GameObject bubble in bubbles)
                {
                    bubble.GetComponent<BallScript>().valueText.enabled = true;
                }
                blinded = false;
            }
        }
        if (inverted)
        {
            confused();
            if (Input.GetKeyDown(KeyCode.Space))
            {
                inverted = false;
            }
        }
        if(uiText.gameObject.active == true)
        {
            uiText.text = phrase;
        }

    }


    void calculating()
    {
        attackTurn = GameManager.instance.turnsRemaining - Random.Range(3, 10);
        currentState = stateMachine.waiting;
    }

    void attack()
    {
        currentState = stateMachine.attacking;
        uiComponent.SetActive(true);
        uiComponent.GetComponent<UIAI>().PlayAttackAnimation();

        deciding();
    }
    bool blinded = false;
    void obstructed()
    {
        amount = Random.Range(2, 8);
        while (amount != 0)
        {
            GameObject ob = Instantiate(obsticlePrefab);
            ob.transform.position = new Vector3(Random.Range(-lvlBounds.x, lvlBounds.x), Random.Range(0, lvlBounds.y), Random.Range(-lvlBounds.z, lvlBounds.z));

            amount -= 1;
            phrase = "Freeze em!";
        }
        currentState = stateMachine.calulating;
        calculating();
    }
    void blinding()
    {
        GameObject[] bubbles = GameObject.FindGameObjectsWithTag("Bubble");

        foreach(GameObject bubble in bubbles)
        {
            bubble.GetComponent<BallScript>().valueText.enabled = false;
        }

        blinded = true;
        phrase = "Peak-a-boo!";
        currentState = stateMachine.calulating;
        calculating();
    }
    bool inverted = false;
    void confused()
    {
        inverted = true;
        PlayerController.instance.x = -PlayerController.instance.x;
        PlayerController.instance.y = -PlayerController.instance.y;
        phrase = "Righty loosy, Lefty tighty";

        currentState = stateMachine.calulating;
        calculating();
    }

    void deciding()
    {
        int roll = Random.Range(0, 3);

        if(roll == 0)
        {
            obstructed();
            print("obstructed");
        }
        else if (roll == 1)
        {
            blinding();
            print("blinded");
        }
        else
        {
            confused();
            print("confused");
        }
    }
}
