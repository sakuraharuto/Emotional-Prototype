using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{   
    public CharacterController controller;
    public float moveSpeed = 10f;

    Vector3 velocity;
    public float gravity = -9.8f;

    public Transform groundCheck;
    public float groundDist = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;

    // Update is called once per frame
    void Update()
    {   
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDist,groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 moveDirection = transform.right * moveX + transform.forward * moveZ;

        controller.Move(moveDirection * moveSpeed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
