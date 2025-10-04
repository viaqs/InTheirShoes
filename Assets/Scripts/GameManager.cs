using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
   public static GameManager Instance;

    public GameObject window;
    public Button button;
   
    [Header("UI")]
    [SerializeField] private Image fadeImg;
    private float fadeSpeed = 1.0f;

  

    [SerializeField] private GameObject website;
    [SerializeField] private GameObject comment;
    [SerializeField] private bool isWebOpen = false;
  



    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        fadeImg.enabled = false;
        comment.SetActive(false);
    }

    public IEnumerator EnterPC()
    {
        fadeImg.enabled = true;
        yield return StartCoroutine(Fade(1));
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("Website");
        
       
     
    }
    public IEnumerator ExitPC()
    {
         fadeImg.enabled = true;
         yield return StartCoroutine(Fade(1));
         SceneManager.LoadScene("Apartment");

    }

    IEnumerator Fade(float targetAlpha)
    {
        Color color = fadeImg.color;

        while (!Mathf.Approximately(color.a, targetAlpha))
        {
            color.a = Mathf.MoveTowards(color.a, targetAlpha, fadeSpeed * Time.deltaTime);
            fadeImg.color = color;
            yield return null;
        }
    }
    public void OpenBtn()
    {
        website.SetActive(true);
        isWebOpen = true;
    }
    public void CloseBtn()
    {
        website.SetActive(false);
        isWebOpen = false;
    }

   public void interaction1()
    {
        window.SetActive(true);
    }
    public void interaction2()
    {
        window.SetActive(false);
        Destroy(button);
        
    }

    void Update()
    {

        if (isWebOpen == true && Input.GetKeyDown(KeyCode.X))
        {
            comment.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            StartCoroutine(ExitPC());
            Movement.canMove = true;
            Cursor.lockState = CursorLockMode.Locked;
        }

    }
}

