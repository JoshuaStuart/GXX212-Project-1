using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int turnsRemaining;
    public Text turnsTXT;
    public int levelGoal;
    [Header("Prefabs")]
    public GameObject bubble;
    public GameObject uiBubble;

    [Header("Possible Bubbles")]
    public List<int> possibleValues;
    public List<Material> colours;

    GameObject[] allBubbles;

    float lastTurnCountdown = 5;


    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        turnsTXT.text = turnsRemaining.ToString();

        allBubbles = GameObject.FindGameObjectsWithTag("Bubble");

        foreach(GameObject bubble in allBubbles)
        {
            if(bubble.GetComponent<BallScript>().value == levelGoal && turnsRemaining > 0)
            {
                print("LEVEL COMPLETED");
            }
        }

        if(turnsRemaining == 0)
        {
            lastTurnCountdown -= 1 * Time.deltaTime;
            if(lastTurnCountdown <= 0)
            {
                print("LEVEL FAILED");
            }
        }
    }

}
