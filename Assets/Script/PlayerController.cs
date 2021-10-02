using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public Transform spawnPoint;
    float x,y;

    GameObject controlledBubble;

    private void Start()
    {
        newControlledBubble();
    }

    private void FixedUpdate()
    {
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");
    }

    private void Update()
    {
        gameObject.transform.position += new Vector3(x * moveSpeed * Time.deltaTime, 0, y * moveSpeed * Time.deltaTime);
        controlledBubble.transform.position = spawnPoint.position;

        if (Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            GameManager.instance.turnsRemaining -= 1;
            controlledBubble.GetComponent<BallScript>().gravity = 10;
            controlledBubble.GetComponent<SphereCollider>().enabled = true;
            if(GameManager.instance.turnsRemaining > 0)
            {
                newControlledBubble();
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
}
