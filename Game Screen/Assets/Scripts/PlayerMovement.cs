using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed, maxSpeed, jumpForce;
    [SerializeField] private Collider2D groundCheck;
    [SerializeField] private LayerMask groundLayers;
 
    private float moveDir;
    private Rigidbody2D myRB;
    private bool canJump;

    private void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        var moveAxis = Vector3.right * moveDir;

        if (-maxSpeed < myRB.velocity.x && myRB.velocity.x < maxSpeed)
        {
            myRB.AddForce((Vector2) moveAxis * moveSpeed, ForceMode2D.Force);
        }
        
        if (groundCheck.IsTouchingLayers(groundLayers))
        {
            canJump = true;
        }
        else
        {
            canJump = false;
        }

    }

    public void Move(InputAction.CallbackContext context)
    {

        moveDir = context.ReadValue<float>();
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (canJump)
        {
            myRB.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
            canJump = false;
        }
    }
}