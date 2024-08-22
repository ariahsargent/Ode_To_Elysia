using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{
    public float playerTurnSpeed = 20f;

    Animator playerAnimator;
    Rigidbody playerRigidbody;
    Vector3 playerMovement;
    Quaternion playerRotation = Quaternion.identity;

    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        //playerMovement.Set(horizontal, 0f, vertical);
        playerMovement = new Vector3(horizontal, 0f, vertical);
        playerMovement.Normalize();

        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);
        bool isWalking = hasHorizontalInput || hasVerticalInput;
        playerAnimator.SetBool("IsWalking", isWalking);

        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, playerMovement, playerTurnSpeed * Time.deltaTime, 0f);
        playerRotation = Quaternion.LookRotation(desiredForward);

    }

    void OnAnimatorMove()
    {
        playerRigidbody.MovePosition(playerRigidbody.position + playerMovement * playerAnimator.deltaPosition.magnitude);
        playerRigidbody.MoveRotation(playerRotation);
    }

}
