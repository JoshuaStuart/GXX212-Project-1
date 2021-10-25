using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAI : MonoBehaviour
{
    public void PlayAttackAnimation()
    {
        GetComponent<Animator>().Play("aiAttack");
        GetComponent<AudioSource>().Play();
        Invoke("PlayLeaveAnimation", 5);
    }
    public void PlayLeaveAnimation()
    {
        GetComponent<Animator>().Play("aiLeave");

        Invoke("disableObject", 5);
    }


    void disableObject()
    {
        gameObject.SetActive(false);
    }
}
