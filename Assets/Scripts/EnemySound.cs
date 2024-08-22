using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySound : MonoBehaviour
{
    private AudioSource audioSource;
    private Vector3 lastPosition;

    public AudioClip enemyStep; //clip for when enemy takes a step

    private float soundTimer;   //timer to control how often sound is played

    public float timeBetweenSounds = 1f;    //second between sound plays


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        audioSource.clip = enemyStep;

        //ref to enemy's position
        lastPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        soundTimer += Time.deltaTime;   //updating timer

        //checks to see if enemy moved
        if (transform.position != lastPosition && soundTimer >= timeBetweenSounds)
        {
            soundTimer = 0f;

            //randomize pitch and volume for variety
            audioSource.pitch = Random.Range(0.9f, 1.2f);
            audioSource.volume = Random.Range(0.4f, 1f);

            audioSource.PlayOneShot(enemyStep);
        }

        //update lastPosition to enemy's current position
        lastPosition = transform.position;
    }
}
