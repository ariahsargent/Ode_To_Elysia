using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class ShieldCollision : MonoBehaviour
{
    public GameObject enemy;

    private void OnCollisionEnter(Collision collision)
    {
        // detect collisions with shield and what hit it
       // Debug.Log("Collision detected with: " + collision.gameObject.name); 

        if (collision.gameObject.CompareTag("EnemyProjectile"))
        {
            //Debug.Log("Shield blocked a projectile!");

            // get rigidbody of projectile and collider components of the projectile
            Rigidbody projectileRb = collision.gameObject.GetComponent<Rigidbody>();

            if (projectileRb != null)
            {
                //find the enemy via tag
                GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");


                if (enemy != null) {

                    // get shield's facing direction
                    // assuming shield is facing forward
                    Vector3 shieldNormal = transform.forward;

                    Vector3 reflectDir = Vector3.Reflect(projectileRb.velocity, shieldNormal);

                    // calculate direction to reflect projectile back to enemy
                    Vector3 shieldToEnemyDirection = (enemy.transform.position - transform.position).normalized;

                    // reflect the velocity based on shield's normal and enemy's position
                    //Vector3 reflectDir = Vector3.Reflect(projectileRb.velocity, collision.contacts[0].normal);

                    // "aim" towards the enemy by mixing reflection with direction
                    // for info on lerp go to bottom of code you learner you
                    reflectDir = Vector3.Lerp(reflectDir, shieldToEnemyDirection, 0.8f);

                    // variable to increase velocity of projectile after reflecting off shield
                    float boostFactor = 2.5f;
                    // take original velocity and boost it
                    reflectDir = reflectDir.normalized * projectileRb.velocity.magnitude * boostFactor;

                    // apply velocity to projectile
                    projectileRb.velocity = reflectDir;

                    // applying upward force to keep projectile off ground
                    // projectile WILL go straight to ground if possible
                    Vector3 upwardForce = Vector3.up * 5f;
                    projectileRb.AddForce(upwardForce, ForceMode.VelocityChange);

                    Debug.Log("Projectile reflected towards the enemy!");
                }
                
            }

        }
    }

}

/*

Lerp->Linear Interpolation: allows you to smoothly interpolate between two values based on a parameter that typically ranges from 0 to 1.

                    t = 0;      ->results of starting value
                    t = 1;      ->results of ending value
                    t = 0.5;    ->results exactly halfway between two values

 Lerp is useful to move an object smoothly between two points, blending colors over time, and mixing two directions or velocities in physics.

*/