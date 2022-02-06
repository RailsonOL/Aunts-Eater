using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{
    public Text nameText;
    public Text TextBox;
    public GameObject DialogueUI;

    private Queue<string> sentences;

    private void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        DialogueUI.SetActive(true);
        GameController.instance.Pause(true);
        nameText.text = dialogue.name;
        
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        ShowNextSentence();
    }

    public void ShowNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();

        TextBox.text = sentence;
    }

    void EndDialogue()
    {
        GameController.instance.Pause(false);
        GameObject.Find("DialoguesUI").SetActive(false);
    }
}
