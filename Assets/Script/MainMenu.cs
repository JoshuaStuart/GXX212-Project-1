using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{   
    public void Play()
    {
        SceneManager.LoadScene(1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void PlaySound()
    {
        gameObject.GetComponent<AudioSource>().Play();
    }

    public void Button2()
    {
        SceneManager.LoadScene(2);
    }

    public void Button3()
    {
        SceneManager.LoadScene(3);
    }
}
