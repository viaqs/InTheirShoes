using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.SceneManagement;


using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
   public static GameManager Instance;

    [Header("Bools")]
    public static bool desktopArea;
   

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

    IEnumerator EnterPC()
    {
        fadeImg.enabled = true;
        yield return StartCoroutine(Fade(1));

        SceneManager.LoadScene("Website");
    }
    public IEnumerator ExitPC()
    {   fadeImg.enabled = true;
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

   
    void Update()
    {

        if (!desktopArea) return;

        if (isWebOpen == true && Input.GetKeyDown(KeyCode.X))
        {
            comment.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
           StartCoroutine(EnterPC());
            Cursor.lockState = CursorLockMode.None;
            
        }


        if (Input.GetKeyDown(KeyCode.Q))
        {
            StartCoroutine(ExitPC());
            Movement.canMove = true;
            Cursor.lockState = CursorLockMode.Locked;
        }

    }
}

