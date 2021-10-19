using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIScript : MonoBehaviour
{
    public int attackTurn;
    public GameObject obsticlePrefab;
    public int amount = 0;

    public enum stateMachine
    {
        calulating,
        waiting,
        attacking
    }
    public stateMachine currentState;

    private void Start()
    {
        currentState = stateMachine.calulating;
        calculating();
    }

    private void Update()
    {
        if (GameManager.instance.turnsRemaining == attackTurn)
        {
            attack();
        }
        if (blinded && Input.GetKeyDown(KeyCode.Space))
        {
            GameObject[] bubbles = GameObject.FindGameObjectsWithTag("Bubble");

            foreach (GameObject bubble in bubbles)
            {
                bubble.GetComponent<BallScript>().valueText.enabled = true;
            }
            blinded = false;
        }
        if (inverted)
        {
            confused();
            if (Input.GetKeyDown(KeyCode.Space))
            {
                inverted = false;
            }
        }
    }


    void calculating()
    {
        attackTurn = GameManager.instance.turnsRemaining - Random.Range(3, 10);
        currentState = stateMachine.waiting;

        amount = Random.Range(2, 8);
    }

    void attack()
    {
        currentState = stateMachine.attacking;

        deciding();
    }
    bool blinded = false;
    void obstructed()
    {
        if(amount != 0)
        {
            GameObject ob = Instantiate(obsticlePrefab);
            ob.transform.position = new Vector3(Random.Range(-4, 4), Random.Range(2, 8), Random.Range(-4, 4));

            amount -= 1;
        }
        else
        {
            currentState = stateMachine.calulating;
            calculating();
        }
    }
    void blinding()
    {
        GameObject[] bubbles = GameObject.FindGameObjectsWithTag("Bubble");

        foreach(GameObject bubble in bubbles)
        {
            bubble.GetComponent<BallScript>().valueText.enabled = false;
        }

        blinded = true;
        currentState = stateMachine.calulating;
        calculating();
    }
    bool inverted = false;
    void confused()
    {
        inverted = true;
        PlayerController.instance.x = -PlayerController.instance.x;
        PlayerController.instance.y = -PlayerController.instance.y;

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
