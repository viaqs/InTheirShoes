using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
   public static GameManager Instance;
    [SerializeField] private Image fadeImg;
    private float fadeSpeed = 1.0f;



    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    IEnumerator EnterPC()
    {
        yield return StartCoroutine(Fade(1));

        SceneManager.LoadScene("Website");
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

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
           StartCoroutine(EnterPC());
            Cursor.lockState = CursorLockMode.None;
        }
       
        
    }
}
