using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    public float speed;

  
    private void Update()
    {
        if (Input.GetKeyDown("a"))
        {
            SpinLeft();
        }

        if(Input.GetKeyDown("d"))
        {
            SpinRight();
        }
    }

    private void SpinLeft()
    {
        transform.Rotate(new Vector3(0, speed, 0));
    }

    private void SpinRight()
    {
        transform.Rotate(new Vector3(0, -speed, 0));
    }
}
