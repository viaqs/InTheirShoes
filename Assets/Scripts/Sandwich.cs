using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Sandwich : MonoBehaviour
{
    [SerializeField] private GameObject canvas;

   
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            Debug.Log("Collided with: " + other.gameObject.name);
            if (canvas != null)
                canvas.SetActive(true);
        }
       
    }
}
