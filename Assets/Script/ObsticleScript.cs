using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsticleScript : MonoBehaviour
{
    public float gravity = 10;
    private void FixedUpdate()
    {
        GetComponent<Rigidbody>().AddForce(Vector3.up * gravity * Time.deltaTime);
    }
}
