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
    }


    void calculating()
    {
        attackTurn = GameManager.instance.turnsRemaining - Random.Range(5, GameManager.instance.turnsRemaining);
        currentState = stateMachine.waiting;

        amount = Random.Range(2, 8);
    }

    void attack()
    {
        currentState = stateMachine.attacking;
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
}
