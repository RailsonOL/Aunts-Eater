using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject OptionsMenu;
    public GameObject SelectPlayer;
    void Start()
    {
        
    }

    void Update()
    {
        
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
