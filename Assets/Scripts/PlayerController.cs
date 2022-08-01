using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] CharacterController controller;
    [SerializeField] float speed;
    [SerializeField] float jump;

    private Vector3 direction;
    private float gravity = -9.8f;
    private bool canDoubleJump;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        direction.x = horizontalInput * speed;

        

        if (controller.isGrounded)
        {
            direction.y = -1;
            canDoubleJump = true;

            if (Input.GetButtonDown("Jump"))
            {
                direction.y = jump;
            } 
        }
        else
        {
            direction.y += gravity * Time.deltaTime;

            if (Input.GetButtonDown("Jump") && canDoubleJump)
            {
                direction.y = jump;
                canDoubleJump = false;
            }
        }

        controller.Move(direction * Time.deltaTime);
    }
}
