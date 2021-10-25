using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    public float moveSpeed;
    public Transform spawnPoint;
    [HideInInspector]
    public float x,y;

    public GameObject controlledBubble;

    private void Start()
    {
        instance = this;
        newControlledBubble();
    }

    private void FixedUpdate()
    {
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");

        gameObject.transform.forward = Camera.main.transform.forward;
    }

    private void Update()
    {
        //Movement
        gameObject.transform.Translate(Vector3.forward * y * moveSpeed * Time.deltaTime);
        gameObject.transform.Translate(Vector3.right * x * moveSpeed * Time.deltaTime);
        if(controlledBubble != null)
        {
            controlledBubble.transform.position = spawnPoint.position;
        }

        if (Input.GetKeyUp(KeyCode.Space) && controlledBubble != null)
        {
            controlledBubble.GetComponent<BallScript>().gravity = 10;
            controlledBubble.GetComponent<SphereCollider>().enabled = true;
            if(GameManager.instance.turnsRemaining > 1)
            {
                Invoke("newControlledBubble", 1);
            }
            GameManager.instance.turnsRemaining -= 1;
            controlledBubble = null;
        }

        if(GameManager.instance.turnsRemaining > 0)
        {
            if (Input.GetKeyDown(KeyCode.F) && Inventory.instance.storedBubbles.Count < 3)
            {
                //TEMP
                GameObject newStoredBubble = Instantiate(GameManager.instance.uiBubble, Inventory.instance.slots[0].transform);
                newStoredBubble.GetComponent<UIBubble>().GenerateBubble(controlledBubble.GetComponent<BallScript>().value, GameManager.instance.colours[GameManager.instance.possibleValues.IndexOf(controlledBubble.GetComponent<BallScript>().value)]);
                Inventory.instance.storedBubbles.Add(newStoredBubble);
                Destroy(controlledBubble);
                newControlledBubble();
            }
            else if (Input.GetMouseButtonDown(1)  && Inventory.instance.storedBubbles.Count > 0 && controlledBubble.GetComponent<BallScript>().storedBall == false && controlledBubble != false)
            {
                Destroy(controlledBubble);
                controlledBubble = null;
                //TEMP

                int count = Inventory.instance.storedBubbles.Count;
                GetBubbleFromInventory(Inventory.instance.storedBubbles[count -1].GetComponent<UIBubble>().value);
                Destroy(Inventory.instance.storedBubbles[count - 1].GetComponent<UIBubble>().gameObject);
                Inventory.instance.storedBubbles.Remove(Inventory.instance.storedBubbles[count - 1]);


            }
        }
    }

    void newControlledBubble()
    {
        GameObject newBubble = Instantiate(GameManager.instance.bubble);
        newBubble.transform.position = spawnPoint.position;
        newBubble.GetComponent<SphereCollider>().enabled = false;
        newBubble.GetComponent<BallScript>().gravity = 0;

        controlledBubble = newBubble;
    }
    void GetBubbleFromInventory(int storedBallValue)
    {
        GameObject newBubble = Instantiate(GameManager.instance.bubble);
        newBubble.GetComponent<BallScript>().randomGen = false;
        newBubble.GetComponent<BallScript>().storedBall = true;
        newBubble.GetComponent<BallScript>().value = storedBallValue;
        newBubble.transform.position = spawnPoint.position;
        newBubble.GetComponent<SphereCollider>().enabled = false;
        newBubble.GetComponent<BallScript>().gravity = 0;



        controlledBubble = newBubble;
    }
}
