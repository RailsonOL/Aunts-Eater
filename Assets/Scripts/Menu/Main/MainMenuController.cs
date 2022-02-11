using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject OptionsMenu;
    public GameObject SelectPlayer;

    public Text newOrContinueText;
    void Start()
    {
        if (SaveLoad.CheckSaveExists())
        {
            newOrContinueText.text = "CONTINUE";
        }
    }

    public void PlayGame()
    {
        MainMenu.SetActive(false);
        SelectPlayer.SetActive(true);
    }

    public void Options()
    {
        MainMenu.SetActive(false);
        OptionsMenu.SetActive(true);
    }

    public void BacktoMenu()
    {
        MainMenu.SetActive(true);
        OptionsMenu.SetActive(false);
        SelectPlayer.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
