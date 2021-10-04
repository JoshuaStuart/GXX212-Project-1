using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public GameObject uiSlot;


    public void Start()
    {
        GameObject uiGoalBubble = Instantiate(GameManager.instance.uiBubble, uiSlot.transform);
        uiGoalBubble.GetComponent<UIBubble>().GenerateBubble(GameManager.instance.levelGoal, GameManager.instance.colours[GameManager.instance.possibleValues.IndexOf(GameManager.instance.levelGoal)]);
        uiGoalBubble.transform.position = uiSlot.transform.position;
    }
}
