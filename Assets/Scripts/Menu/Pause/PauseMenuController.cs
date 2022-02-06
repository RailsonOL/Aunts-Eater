using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    public GameObject PauseMenu;
    public GameObject OptionsMenu;

    public void ResumeGame()
    {
        GameController.instance.Pause(false);
        gameObject.SetActive(false);
    }

    public void Options()
    {
        PauseMenu.SetActive(false);
        OptionsMenu.SetActive(true);
    }

    public void BacktoMenu()
    {
        PauseMenu.SetActive(true);
        OptionsMenu.SetActive(false);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
