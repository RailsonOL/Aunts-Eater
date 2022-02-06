using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public Transform BossAunt;
    public Transform BossSpawnPoint;

    bool ReadyToBoss = false;

    void Update()
    {
        if (GameController.instance.sexyAppealPoints >= GameController.instance.totalPointsToBoss && !ReadyToBoss)
        {
            switch (PlayerPrefs.GetString("CurrentPlayer"))
            {
                case "P1":
                    GameObject.Find("BossDialogueToP1").GetComponent<DialogueTrigger>().TriggerDialogue();
                    break;
                case "P2":
                    GameObject.Find("BossDialogueToP2").GetComponent<DialogueTrigger>().TriggerDialogue();
                    break;
                case "P3":
                    GameObject.Find("BossDialogueToP3").GetComponent<DialogueTrigger>().TriggerDialogue();
                    break;
                case "P4":
                    GameObject.Find("BossDialogueToP4").GetComponent<DialogueTrigger>().TriggerDialogue();
                    break;
                case "P5":
                    GameObject.Find("BossDialogueToP5").GetComponent<DialogueTrigger>().TriggerDialogue();
                    break;
            }
            
            Instantiate(BossAunt, BossSpawnPoint.position, Quaternion.identity);
            ReadyToBoss = true;
        }
    }
}
