using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerTransform;
    public Vector3 offset = new Vector3(0, 0, 0); //offset from player
    public float followSpeed = 5f;
    public float rotationSpeed = 5f;

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 desiredPosition = playerTransform.position + offset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, followSpeed * Time.deltaTime);

        Vector3 direction = playerTransform.position - transform.position;
        direction.y = 0f; //ensures camera only rotates horizontally

        if (direction.magnitude > 0.1f)
        {
            Quaternion desiredRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
