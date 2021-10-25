using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    public int spins = 1;
    public float speed = 5;
    private void Start()
    {
        iTween.RotateBy(gameObject, iTween.Hash("y", spins, "speed", speed, "easeType", iTween.EaseType.linear, "onComplete", "EndItween"));
    }

    void EndItween()
    {
        Destroy(gameObject);
    }
}
