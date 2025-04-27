using System.Collections;
using System.Collections.Generic;
using Unity.VRTemplate;
using UnityEngine;
using UnityEngine.AI;

public class EnemyShoot : MonoBehaviour
{
    public Transform player;
    public float enemySpeed = 3f;   //speed of enemy 
    public float bulletSpeed = 10f;    //speed of bullet

    public GameObject projectilePrefab;  //bullet prefab
    public Transform spawnPoint;    //where projectile spawns
    
    public AudioClip shootingSound; //audio for when enemy throws projectile

    private AudioSource audioSource;
    [SerializeField] private float timer = 5f;   //time between shots
    private float bulletTime;   //internal timer for shooting


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        audioSource.clip = shootingSound;
    }

    // Update is called once per frame
    void Update()
    {
        bulletTime -= Time.deltaTime;

        //calling shooting method
        if (bulletTime <= 0) 
        {
            ShootAtPlayer();
            bulletTime = timer;
        }

        MoveTowardsPlayer();

    }


    void MoveTowardsPlayer()
    {
        Vector3 direction = player.position - transform.position;
        direction.y = 0f;  //movement only on horizontal

        //move towards player
        transform.position = Vector3.MoveTowards(transform.position, player.position, enemySpeed * Time.deltaTime);

        //rotate to face player
        transform.rotation = Quaternion.LookRotation(direction);

    }

    void ShootAtPlayer()
    { 

        //makey the bullety at the spawn pointy
        GameObject projectile = Instantiate(projectilePrefab, spawnPoint.position, spawnPoint.rotation);

       // Rigidbody rb = projectile.GetComponent<Rigidbody>();
        //movement of bullet
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        rb.AddForce(rb.transform.forward * bulletSpeed, ForceMode.VelocityChange);

        BulletScript projectileScript = projectile.GetComponent<BulletScript>();

        if ( projectileScript != null)
        {
            projectileScript.StartThrowingDelay();
        } else
        {
            Debug.LogError("Projectile script not found on the projectile prefab!");
        }

        if (shootingSound != null)
        {
            audioSource.PlayOneShot(shootingSound);
        }

        //small delay to prevent projectile from immediately colliding with enemy
        //projectile.GetComponent<Projectile>().StartThrowingDelay();

        //destory zhe bullet
        Destroy(projectile, 10f);
    }

}
