using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using static TriggerManager;

public class DialogueSystem : MonoBehaviour
{   
    public static DialogueSystem instance;


    public TextMeshProUGUI text;
    public Sprite[] portraits;
    public Image image;
    public string[] lines;
    public float typeSpeed;

    private int index;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);

    }
    void Start()
    {
        text.text = string.Empty;
        StartDialogue();
    }
     void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if (text.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                text.text = lines[index];
            }
       
        }
    }
    public void StartDialogue()
    {
        index = 0;
        image.sprite = portraits[index];
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach(char c in lines[index].ToCharArray())
        {
            text.text += c;
            yield return new WaitForSeconds(typeSpeed);
        }
    }
    
    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            text.text = string.Empty;
            image.sprite = portraits[index];
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

}
