using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diactivator : MonoBehaviour
{
    [SerializeField] private GameObject triggerControl;
    
    
    private void OnTriggerEnter(Collider other)
    {   
        if (other.CompareTag("Player"))
        {
            GameManager.desktopArea = true;
            triggerControl.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.desktopArea = false;
            triggerControl.SetActive(false);
        }
        

    }
}
