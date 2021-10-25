using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentOpen : MonoBehaviour
{
      // Update is called once per frame
    void Start()
    {
        MoveUp();
        RotateOpen();
    }

    void MoveUp()
    {
        iTween.MoveBy(gameObject, iTween.Hash("y", 0.5, "easetype", "linear", "time", 0.5, "delay", 0.5, "oncomplete", "MoveDown"));
    }

    void MoveDown()
    {
        iTween.MoveBy(gameObject, iTween.Hash("y", -0.5, "easetype", "linear", "time", 0.5, "delay", 0.5));
    }

    void RotateOpen()
    {
        iTween.RotateBy(gameObject, iTween.Hash("amount", new Vector3(0,1,0), "easetype", "linear", "time", 0.5, "delay", 0.5, "oncomplete", "RotateClose"));
    }

    void RotateClose()
    {
        iTween.RotateBy(gameObject, iTween.Hash("amount", new Vector3(0,1, 0), "easetype", "linear", "time", 0.5, "delay", 0.5));
    }
}
