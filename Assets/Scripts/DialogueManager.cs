using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;


public class DialogueManager : MonoBehaviour
{

   

   public static DialogueManager instance;
    public Image characterIcon;
    public TextMeshProUGUI characterName;
    public TextMeshProUGUI dialogueArea;
    public  GameObject DialogBox;

    private Queue<DialogueLine> lines;
    public bool isDialogueActive = false;
    public float typingSpeed = 0.2f;



    private void Awake()
    {
        if(instance == null)
            { instance = this; }

         lines = new Queue<DialogueLine>();
        DialogBox.SetActive(false);

    }

    public void StartDialogue(Dialogue dialogue)
    {
        Movement.Instance.speed = 0f;
        DialogBox.SetActive(true);
            isDialogueActive =true;
            lines.Clear();

        foreach (DialogueLine dialogueLine in dialogue.dialogueLines)
        {
            lines.Enqueue(dialogueLine);
        }
        DisplayNextDialogueLine();
    }
   
    public void DisplayNextDialogueLine()
    {
        if (lines.Count == 0)
        {
            EndDialogue();
            return;
        }
        DialogueLine currentLine = lines.Dequeue();

        characterIcon.sprite = currentLine.character.icon;
        characterName.text = currentLine.character.name;

        StopAllCoroutines();
        StartCoroutine(TypeSentence(currentLine));
    }

    IEnumerator TypeSentence(DialogueLine dialogueLine)
    {
        dialogueArea.text = " ";
        foreach(char letter in dialogueLine.line.ToCharArray())
        {
            dialogueArea.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    void EndDialogue()
    {
        Movement.Instance.speed = 3f;
        DialogBox.SetActive(false);
        isDialogueActive = false;

    }
}
