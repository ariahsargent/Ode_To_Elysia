using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float bulletSpeed = 10f;

    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        Vector3 direction = (player.position - transform.position).normalized;

        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = direction * bulletSpeed;

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Hit Player!");

            Destroy(gameObject);

        }
    }
}
