using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClick : MonoBehaviour
{
    public void ClickSound()
    {
        gameObject.GetComponent<AudioSource>().Play();
    }
}