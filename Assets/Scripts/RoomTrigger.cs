using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTrigger : MonoBehaviour
{
    public TriggerManager.Room roomType;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {   
            TriggerManager manager = FindObjectOfType<TriggerManager>();
            if (manager != null)
            {
                manager.setCurrentRoom(roomType);
                manager.ShowRoomInstruction(roomType);
            }
 
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TriggerManager manager = FindObjectOfType<TriggerManager>();
            if (manager != null)
            {
                manager.setCurrentRoom(TriggerManager.Room.none);
                manager.ShowRoomInstruction(TriggerManager.Room.none);
            }
        }
    }

}
