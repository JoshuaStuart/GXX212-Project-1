using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public Transform canvas;

    private void Start()
    {
        canvas.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (canvas.gameObject.activeInHierarchy == false)
            {
                canvas.gameObject.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                canvas.gameObject.SetActive(false);
                Time.timeScale = 1;
            } 
        }
    }
    
    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void UnPause()
    {
        canvas.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
