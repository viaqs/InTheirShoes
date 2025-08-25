using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using static TriggerManager;

[System.Serializable]
public class DialogueCharacter
{
    public string name;
    public Sprite icon;
}

[System.Serializable] 
public class DialogueLine
{
    public DialogueCharacter character;
    [TextArea(3,10)]
    public string line;
}
[System.Serializable]
public class Dialogue
{
    public List<DialogueLine> dialogueLines = new List<DialogueLine>();
}

public class DialogueSystem : MonoBehaviour
{
    public Dialogue dialogue;

    public void triggerDialogue()
    {
        DialogueManager.instance.StartDialogue(dialogue);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        { 
            triggerDialogue();
            Cursor.lockState = CursorLockMode.None;

        }
    }
    private void OnTriggerExit(Collider other)
    {
        Destroy(gameObject);
        Cursor.lockState = CursorLockMode.Locked;
    }
}
