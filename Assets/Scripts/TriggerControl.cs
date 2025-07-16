using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class TriggerControl : MonoBehaviour
{
    [Header("Desktop Trigger area")]
    [SerializeField] private Transform chair;
    [SerializeField] private Collider chairCollider;

    [Header("UI")]
    public TextMeshProUGUI instruction;

    [Header("Player Detection")]
    [SerializeField] private CharacterController controller;
    [SerializeField] private Transform player;
    private Vector3 savedPos;


    private bool isInTrigger = false;
    private bool isSat=false;

    void Start()
    {
        chairCollider.enabled = true;
    }

    public void SitDown()
    {
        Movement.canMove = false;
        controller.enabled = false;
        chairCollider.enabled = false;
        player.position = chair.position;
        isSat = true;
        if (isSat == true)
        {
            instruction.text = "Press [R] to stand up\nPress [T] to interact with PC";
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player entered the trigger!");
            if (player == null)
            {
                Debug.LogError("Player Transform is not assigned!");
                return;
            }

            if (instruction == null)
            {
                Debug.LogError("Instruction Text is not assigned!");
                return;
            }

            savedPos = player.position;
            instruction.text = "Press [E] to sit down";
            isInTrigger = true;
        }
    }

    private void OnTriggerExit()
    {
        instruction.text = " ";
    }
    void Update()
    {
        
        
       

        if (isInTrigger == true && Input.GetKeyDown(KeyCode.E))
        {
            Movement.canMove = false;
            controller.enabled = false;
            chairCollider.enabled = false;
            player.position = chair.position;
            isSat = true;
           
        }
        if (isSat == true)
        {
            instruction.text = "Press [R] to stand up\nPress [T] to interact with PC";
            if(Input.GetKeyDown(KeyCode.R))
            { 
                player.position = savedPos;
                chairCollider.enabled = true;
                controller.enabled = true;
                Movement.canMove = true;
                isSat=false;
            }
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            controller.enabled = true;
           
        }

     
    
    }
}
