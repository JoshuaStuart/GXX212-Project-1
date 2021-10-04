using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    public float speed;

    float x,y;
  
    private void Update()
    {
        x = Input.GetAxis("Mouse X");
        y = Input.GetAxis("Mouse Y");
    }

    private void FixedUpdate()
    {
        //middle button held...
        if (Input.GetMouseButton(2))
        {
            //transform.Rotate(new Vector3(-y * speed * Time.deltaTime, x * speed * Time.deltaTime, 0));
            transform.Rotate(new Vector3(0, x * speed * Time.deltaTime, 0));
        }
    }
}
