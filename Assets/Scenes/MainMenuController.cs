using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void playGame()
    {
        SceneManager.LoadScene("Level_0");
    }
    public void Options() { }

    public void Quit()
    {
        Application.Quit();
    }
}
