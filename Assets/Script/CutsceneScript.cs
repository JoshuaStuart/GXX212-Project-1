using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneScript : MonoBehaviour
{
    private void Start()
    {
        gameObject.transform.parent.gameObject.GetComponent<CameraRotate>().enabled = true;
    }


}
