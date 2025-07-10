using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class TriggerControl : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI instruction;
    [SerializeField] private Transform chair;
    [SerializeField] private CharacterController controller;
    [SerializeField] private Transform player;
    private Vector3 savedPos;
    private bool isInTrigger = false;
    private bool isSat=false;
    
    void Start()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            instruction.text = "Press [E] to sit down";
            isInTrigger = true;
        }
       


    }
    void Update()
    {
        if (isInTrigger == true && Input.GetKeyDown(KeyCode.E))
        {
            Movement.canMove = false;
            controller.enabled = false;
            player.position = chair.position;
            isSat = true;
           
        }
        if (isSat == true)
        {
            instruction.text = "Press [R] to stand up\nPress [T] to interact with PC";
        }
    }
}
