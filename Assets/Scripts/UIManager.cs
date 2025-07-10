using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] private GameObject website;
    [SerializeField] private GameObject comment;
    private bool isWebOpen=false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        comment.SetActive(false);
    }

    
    void Update()
    {
        if(isWebOpen==true && Input.GetKeyDown(KeyCode.X))
        {
            comment.SetActive(true);
        }
    }

    public void Open()
    {
        website.SetActive(true);
        isWebOpen = true;
    }
    public void Close()
    {
        website.SetActive(false);
        isWebOpen = false;
    }

   
}
