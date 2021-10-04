using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallScript : MonoBehaviour
{
    public int value;

    public float gravity = 9.8f;

    public bool randomGen = true;
    public bool storedBall = false;
    [Header("UI")]
    public Text valueText;


    private void Start()
    {
        if (randomGen)
        {
            generateStartingValue();
        }
        else
        {
            valueText.text = value.ToString();
        }
        setColour();
    }

    private void FixedUpdate()
    {
        GetComponent<Rigidbody>().AddForce(Vector3.up * gravity * Time.deltaTime);
        valueText.canvas.transform.forward = Camera.main.transform.forward;
    }


    public void generateStartingValue()
    {
        int roll = Random.Range(0, 4);

        value = GameManager.instance.possibleValues[roll];
        valueText.text = value.ToString();
    }
    public void setColour()
    {
        gameObject.GetComponent<Renderer>().material = GameManager.instance.colours[GameManager.instance.possibleValues.IndexOf(value)];
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bubble")
        {
            GameObject otherBubble = collision.gameObject;
            if(otherBubble.GetComponent<BallScript>().value == value)
            {
                CombinationManager.instance.storedCollisionObjects.Add(gameObject);
                CombinationManager.instance.combineObjects();
            }
        }
    }

}
