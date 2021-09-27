using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public Transform spawnPoint;
    float x;

    public GameObject controlledBubble;

    private void Start()
    {
        newControlledBubble();
    }

    private void FixedUpdate()
    {
        x = Input.GetAxisRaw("Horizontal");
    }

    private void Update()
    {
        controlledBubble.transform.position += new Vector3(x * moveSpeed * Time.deltaTime, 0, 0);


        if (Input.GetKeyUp(KeyCode.Space))
        {
            controlledBubble.GetComponent<Rigidbody>().useGravity = true;
            controlledBubble.GetComponent<SphereCollider>().enabled = true;
            controlledBubble = null;
            GameManager.instance.turnsRemaining -= 1;

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
        newBubble.GetComponent<Rigidbody>().useGravity = false;
        newBubble.GetComponent<SphereCollider>().enabled = false;

        controlledBubble = newBubble;
    }
}
