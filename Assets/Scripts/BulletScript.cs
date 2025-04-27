using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private bool isThrown = false;
    private float delayTime = 1f;   //delay time before enemy can be destroyed by its own bullets
    private bool canCollideWithEnemy = false;   // to control collision behavior
    
    public float bulletSpeed = 10f;

    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        Vector3 direction = (player.position - transform.position).normalized;

        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = direction * bulletSpeed;

    }

    private void Update()
    {
        if (isThrown && !canCollideWithEnemy)
        {
            delayTime -= Time.deltaTime;
            if(delayTime <= 0f)
            {
                //after delay, enable collisions with enemy
                canCollideWithEnemy = true;
            }
        }
    }

    public void StartThrowingDelay()
    {
        isThrown = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //only handle collisions with the enemy after the delay
        if(canCollideWithEnemy && collision.gameObject.CompareTag("Enemy"))
        {
            StartCoroutine(DespawnEnemyAfterDelay(collision.gameObject));
        }
    }

    private IEnumerator DespawnEnemyAfterDelay(GameObject enemy)
    {
        //wait 1 sec before destroying enemy
        yield return new WaitForSeconds(1f);

        //destory enemy after delay
        Destroy(enemy);

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
