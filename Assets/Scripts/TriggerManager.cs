using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TriggerManager : MonoBehaviour
{
    public enum Room {none,bedroom,kitchen,bathroom};
    private Room currentRoom = Room.none;

    [Header("Bools & UI's")]
    private bool isSat = false;
    private bool isHere = false;
    private bool isHoldingSandwich = false;
    [SerializeField] private TextMeshProUGUI interactionText;

    [Header("Bedroom")]
    [SerializeField] private Transform chair;
    [SerializeField] private Collider chairCollider;

    [Header("Kitchen")]
    [SerializeField] private GameObject sandwich;
    [SerializeField] private Rigidbody sandwichRb;


    [Header("Player")]
    [SerializeField] private CharacterController controller;
    [SerializeField] private Transform player;
    [SerializeField] private Transform handPoint;
    private Vector3 savedPos;

    private void Awake()
    {
        sandwich.SetActive(false);
        sandwichRb.isKinematic = true;
    }

    private void Update()
    {   
        if(isSat==true && Input.GetKeyUp(KeyCode.R))
        {
            GetUp();
        }
        else if(Input.GetKeyUp(KeyCode.R)&& !isHoldingSandwich && isHere)
        {
             GrabSandwich();
            interactionText.text = "Press [R] again to drop it.";
           
        }
        else if (isHoldingSandwich && Input.GetKeyDown(KeyCode.R))
        {
            DropSandwich();
            interactionText.text = currentRoom == Room.kitchen
                ? "Press [R] to grab the sandwich again."
                : "";
        }


        if (isSat == true && Input.GetKeyDown(KeyCode.T))
        {
            GameManager manager = FindObjectOfType<GameManager>();
            manager.StartCoroutine(manager.EnterPC());
        }
        if(Input.GetKeyDown(KeyCode.E))
        {
            savedPos = player.position;
            HandleRoomAction();
        }
    }
    public void setCurrentRoom(Room room)
    {
        currentRoom = room;
        Debug.Log("You entered: " + room);
    }
    public void ShowRoomInstruction(Room room)
    {
        if (interactionText == null) return;

        switch (room)
        {
            case Room.bedroom:
                interactionText.text = "Press E to sit down";
                interactionText.enabled = true;
                if (isSat == true) interactionText.text = " ";
                break;
            case Room.kitchen:
                interactionText.text = "Press E to make a sandwich";
                interactionText.enabled = true;
                break;
            case Room.bathroom:
                interactionText.text = "Press E to take a shower";
                interactionText.enabled = true;
                break;
            default:
                interactionText.text = "";
                interactionText.enabled = false;
                break;
        }
    }
    private void HandleRoomAction()
    {
        switch (currentRoom)
        {
            case Room.bedroom:
                Debug.Log("You're in the Bedroom. Showing text and sitting.");
                SitDown();
                break;

            case Room.kitchen:
                Debug.Log("You're in the Kitchen. Enabling sandwich.");
                spawnSandwich();

                break;

            case Room.bathroom:
                Debug.Log("You're in the Bathroom. Taking a shower...");
                // Play animation or sound, etc.
                break;

            default:
                Debug.Log("You're not in a room.");
                break;
        }
    }

    void spawnSandwich()
    {
        sandwich.SetActive(true);
        isHere = true;
        interactionText.text = "Press [R] to grab the sandwich";
    }
    void DropSandwich()
    {
        Debug.Log("You dropped the sandwich!");

        sandwich.transform.SetParent(null);
        sandwich.transform.position = handPoint.position + player.forward * 1f;
        sandwichRb.isKinematic = false;

        isHoldingSandwich = false;
    }

        void GrabSandwich()
    {
        Debug.Log("You grabbed the sandwich!");

        sandwich.transform.SetParent(handPoint);
        sandwich.transform.localPosition = Vector3.zero;
        sandwich.transform.localRotation = Quaternion.identity;

        isHoldingSandwich = true;
        isHere = false;
        interactionText.text = "Press R to drop sandwich";
    }
    public void GetUp()
    {
        player.position = savedPos;
        chairCollider.enabled = true;
        controller.enabled = true;
        Movement.canMove = true;
        isSat = false;

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
            interactionText.text = "Press [R] to stand up\nPress [T] to interact with PC";
        }
    }

    public void MoveSandwitch()
    {
        if(isHere == true)
        {
            
        }
    }
}
