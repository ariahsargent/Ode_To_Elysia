using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    //references player script
    public PlayerAdd playerScript;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyProjectile"))
        {
            Debug.Log("Player hit by projectile");
            playerScript.TakeDamage(20f);
            Destroy(other.gameObject);
        }

        if (other.CompareTag("PowerUp"))
        {
            Debug.Log("Player picked up PowerUp");    
            Destroy(other.gameObject);
        }
    }
}
