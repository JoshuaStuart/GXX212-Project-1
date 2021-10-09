using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject nextPopUp;
    public string[] completeInputs;



    private void Update()
    {
        foreach(string button in completeInputs)
        {
            if (Input.GetButtonDown(button))
            {
                Invoke("NextTip", 0.5f);
            }
        }
    }

    public void NextTip()
    {
        nextPopUp.SetActive(true);
        gameObject.SetActive(false);
    }
    public void SkipTutorial()
    {
        gameObject.transform.parent.gameObject.SetActive(false);
    }
}
