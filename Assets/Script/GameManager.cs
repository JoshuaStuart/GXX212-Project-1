using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    public GameObject winUI, lossUI;

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
                winUI.SetActive(true);
            }
        }

        if(turnsRemaining == 0)
        {
            lastTurnCountdown -= 1 * Time.deltaTime;
            if(lastTurnCountdown <= 0)
            {
                print("LEVEL FAILED");
                lossUI.SetActive(true);
            }
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
