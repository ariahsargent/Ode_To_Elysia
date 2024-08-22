using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float playTurnSpeed = 10f;
    public float movementSpeed = 5f;

    Rigidbody playRigidbody;
    Vector3 playMovement;
    Quaternion playRotation = Quaternion.identity;

    // Start is called before the first frame update
    void Start()
    {
        playRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //get current coordinates of player
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        //to fix inverted controls due to camera (for some reason)
        //vertical = -vertical;

        playMovement = new Vector3(horizontal, 0f, vertical);
        playMovement.Normalize();

        if (horizontal != 0f || vertical != 0f)
        {
            //applies movement
            Vector3 movePosition = playRigidbody.position + playMovement * movementSpeed * Time.deltaTime;
            playRigidbody.MovePosition(movePosition);

            //rotate towards player movement direction
            Vector3 desiredForward = Vector3.RotateTowards(transform.forward, playMovement, playTurnSpeed * Time.deltaTime, 0f);
            playRotation = Quaternion.LookRotation(desiredForward);
            playRigidbody.MoveRotation(playRotation);
        }

        /* this code sucks
        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);

        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, playMovement, playTurnSpeed * Time.deltaTime, 0f);
        playRotation = Quaternion.LookRotation(desiredForward);
        */

    }


}
