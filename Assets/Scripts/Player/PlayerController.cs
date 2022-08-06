using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] CharacterController controller;
    [SerializeField] Animator playerAnimator;
    [SerializeField] Transform playerModel;
    [SerializeField] GameManager gameManager;
    [SerializeField] float speed;
    [SerializeField] float jump;

    private Vector3 direction;
    private float gravity = -9.8f;
    private bool canDoubleJump;

    // Update is called once per frame
    void Update()
    {
        if (gameManager.IsGameOver())
        {
            playerAnimator.SetTrigger("isDead");

            this.enabled = false;
        }

        float horizontalInput = Input.GetAxis("Horizontal");
        direction.x = horizontalInput * speed;
        playerAnimator.SetFloat("Speed", Mathf.Abs(horizontalInput));
        playerAnimator.SetBool("isGrounded", controller.isGrounded);

        if (controller.isGrounded)
        {
            direction.y = -1;
            canDoubleJump = true;

            if (Input.GetButtonDown("Jump"))
            {
                Jump();
            }

            if (Input.GetKeyDown(KeyCode.X))
            {
                playerAnimator.SetTrigger("fireballAttack");
            }
        }
        else
        {
            direction.y += gravity * Time.deltaTime;

            if (Input.GetButtonDown("Jump") && canDoubleJump)
            {
                DoubleJump();
            }
        }

        if (playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("FireballAttack"))
        {
            return;
        }

        if(horizontalInput != 0)
        {
            Quaternion newRotation = Quaternion.LookRotation(new Vector3(horizontalInput, 0, 0));
            playerModel.rotation = newRotation;
        }

        controller.Move(direction * Time.deltaTime);
    }

    private void Jump()
    {
        direction.y = jump;
    }

    private void DoubleJump()
    {
        direction.y = jump;
        canDoubleJump = false;
        playerAnimator.SetTrigger("doubleJump");
    }
}
