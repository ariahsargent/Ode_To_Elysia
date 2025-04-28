using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

/* 
 * Code created by: Ariah Sargent
 * Year: 2025
 * For GIMM Individual Game at Boise State University
 * References used:
 *  Atomic CS on YouTube -> Unity FPS Movement Controller 2022/2023 Tutorial
 *      https://www.youtube.com/watch?v=1tT2hz-tKTg&ab_channel=AtomicCS
 *  ChaptGPT -> for lots of troubleshooting
 *      https://chatgpt.com/share/680f673d-5e80-8007-bf36-b2ef3eee7008
 */


public class Player : MonoBehaviour
{
    // player variables
    private CharacterController controller;
    private Vector2 moveInput;
    public float speed;

    // outside forces on player variables
    private Vector3 playerVelocity;
    private bool grounded;
    public float gravity = -9.8f;
    public float jumpForce = 2f;

    // camera variables
    public Camera cam;
    private Vector2 lookPos;
    private float xRotation = 0f;
    public float xSens = 30f;
    public float ySens = 30f;

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        onJump();
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        lookPos = context.ReadValue<Vector2>();
    }

    private void Start()
    {
        controller = GetComponent<CharacterController>();

        //remove cursor during game play
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        grounded = controller.isGrounded;
        onMove();
        onLook();
    }

    public void onMove()
    {
        Debug.Log("onMove activated");

        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = moveInput.x;
        moveDirection.z = moveInput.y;
        controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);

        // control gravity for jump function
        playerVelocity.y += gravity * Time.deltaTime;
        if(grounded && playerVelocity.y < 0)
        {
            playerVelocity.y = -2f;
        }
        controller.Move(playerVelocity * Time.deltaTime);
    }

    public void onJump()
    {
        Debug.Log("onJump activated");

        if (grounded)
        {
            playerVelocity.y = Mathf.Sqrt(jumpForce * -3f * gravity);
        }
    }

    public void onLook()
    {
        Debug.Log("onLook activated");

        xRotation -= (lookPos.y * Time.deltaTime) * ySens;
        // sets how player can't look past certain degrees
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        cam.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        transform.Rotate(Vector3.up * (lookPos.x * Time.deltaTime) * xSens);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Portal at end of level -> moves player to next scene
        if (collision.gameObject.CompareTag("Portal"))
        {
            SceneManager.LoadScene("Level1Portal");
        }
    }
}
