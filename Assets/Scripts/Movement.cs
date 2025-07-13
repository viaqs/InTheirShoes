using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Movement : MonoBehaviour
{
   
    public float speed = 3f;
    private CharacterController controller;
    public static bool canMove;
    
    void Start()
    {
        controller = GetComponent<CharacterController>();
        canMove = true;
        
    }
    void Update()
    {
        if (!canMove) return;

        var input = new Vector3();
        input.x = Input.GetAxis("Horizontal");
        input.z = Input.GetAxis("Vertical");

        var move = (input.x * transform.right + input.z * transform.forward) *speed*Time.deltaTime;
        controller.Move(move);

       
    }

    
}
