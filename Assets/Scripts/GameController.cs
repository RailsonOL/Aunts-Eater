using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [Header("Status")]
    public int playerLife = 100;
    public Text playerLifeText;
    public int sexyAppealPoints;
    public Text sAText;

    [Header("Boss")]
    public int totalPointsToBoss = 50;
    public int totalPointsToWin = 100;

    [Header("World Config")]
    public float SpawnVelocity = -2.5f;
    public Transform PlayerSpawnPoint;
    public string PlayerCurrent;
    public GameObject[] PlayerList;
    public GameObject PauseMenu;
    public GameObject DemoEnd;
    public static GameController instance;

    public bool isPause = false;

    private bool doublePoints = false;

    void Start()
    {
        instance = this;
        PlayerCurrent = PlayerPrefs.GetString("CurrentPlayer");
        InstantiatePlayer();
        UpdateLifePoints();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Cancel") && !PauseMenu.activeSelf)
        {
            Pause(true);
            PauseMenu.SetActive(true);
        }
        else if(Input.GetButtonDown("Cancel") && PauseMenu.activeSelf)
        {
            Pause(false);
            PauseMenu.SetActive(false);
        }

        if (sexyAppealPoints >= totalPointsToWin)
        {
            Pause(true);
            DemoEnd.SetActive(true);
            Invoke(nameof(QuitGame), 2f);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void AddPoints(int pointValue = 1)
    {
        if (doublePoints) pointValue *= 2; //P2 Bonus

        sexyAppealPoints += pointValue;
        sAText.text = "x " + sexyAppealPoints.ToString();
    }

    public void UpdateLifePoints()
    {
        playerLifeText.text = "x " + playerLife.ToString();
    }

    public void Pause(bool on = true)
    {
        isPause = !isPause;
        Time.timeScale = on ? 0 : 1;
    }

    public void AddPlayerUniqueStatus()
    {
        switch (PlayerCurrent)
        {
            case "P1":
                int PlayerExtraLife = 50;
                playerLife += PlayerExtraLife;
                UpdateLifePoints();
                break;
            case "P2":
                doublePoints = true;
                break;
            case "P3":
                SpawnVelocity = -3.75f;
                break;
            case "P4":
                //IN DONKEY SCRIPT
                break;
            case "P5":
                //IN BOSS PROJECTILE SCRIPT
                break;
        }

    }

    public void InstantiatePlayer()
    {
        switch (PlayerCurrent)
        {
            case "P1":
                Instantiate(PlayerList[0], PlayerSpawnPoint.position, Quaternion.identity);
                GameObject.Find("P1Dialogue").GetComponent<DialogueTrigger>().TriggerDialogue();
                break;
            case "P2":
                Instantiate(PlayerList[1], PlayerSpawnPoint.position, Quaternion.identity);
                GameObject.Find("P2Dialogue").GetComponent<DialogueTrigger>().TriggerDialogue();
                break;
            case "P3":
                Instantiate(PlayerList[2], PlayerSpawnPoint.position, Quaternion.identity);
                GameObject.Find("P3Dialogue").GetComponent<DialogueTrigger>().TriggerDialogue();
                break;
            case "P4":
                Instantiate(PlayerList[3], PlayerSpawnPoint.position, Quaternion.identity);
                GameObject.Find("P4Dialogue").GetComponent<DialogueTrigger>().TriggerDialogue();
                break;
            case "P5":
                Instantiate(PlayerList[4], PlayerSpawnPoint.position, Quaternion.identity);
                GameObject.Find("P5Dialogue").GetComponent<DialogueTrigger>().TriggerDialogue();
                break;
        }

        AddPlayerUniqueStatus();
    }
}
