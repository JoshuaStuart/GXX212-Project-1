using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallScript : MonoBehaviour
{
    public int value;

    public bool randomGen = true;

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
