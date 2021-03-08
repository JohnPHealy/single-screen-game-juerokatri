using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed, maxSpeed;

    private float moveDir;
    private Rigidbody2D myRB;

    private void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        var moveAxis = Vector3.right * moveDir;
        
        myRB.AddForce((Vector2)moveAxis * moveSpeed, ForceMode2D.Force);
    }

    public void Move(InputAction.CallbackContext context)
    {

        moveDir = context.ReadValue<float>();
    }
    
    public void Jump(InputAction.CallbackContext context)
    {

        print(message:context.ReadValue<bool>());
    }
}