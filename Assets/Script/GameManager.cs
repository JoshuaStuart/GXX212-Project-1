using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int turnsRemaining;
    public GameObject bubble;

    public List<int> possibleValues;
    public List<Material> colours;




    private void Awake()
    {
        instance = this;
    }


}
