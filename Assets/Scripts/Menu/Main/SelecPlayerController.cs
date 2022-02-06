using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class SelecPlayerController : MonoBehaviour
{
    public GameObject DefaultSelect;
    EventSystem EVRef;
    private void Start()
    {
        EVRef = EventSystem.current;
        PlayerPrefs.SetString("CurrentPlayer", "P1");
        PlayerPrefs.Save();

        EVRef.SetSelectedGameObject(DefaultSelect);
    }

    public void ConfirmAndStart()
    {
        PlayerPrefs.SetString("SaveGame", "true");
        PlayerPrefs.Save();
        SceneManager.LoadScene("World1Westland");
    }
}
