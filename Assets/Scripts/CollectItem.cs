using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
 * Code created by: Ariah Sargent
 * Year: 2025
 * For GIMM Individual Game at Boise State University
 * References used:
 *  ChaptGPT -> for lots of troubleshooting
 *      https://chatgpt.com/share/680f673d-5e80-8007-bf36-b2ef3eee7008
 * 
 */

public class CollectItem : MonoBehaviour
{
    public AudioClip powerUpSound;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        //make sure audioSource has powerUp sound assigned
        if (audioSource == null || powerUpSound == null)
        {
            Debug.LogError("Missing AudioSource or AudioClip!");
        }

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            audioSource.PlayOneShot(powerUpSound);

            Debug.Log("Collected!");
            //logic for what to do once item has been collected

            Destroy(gameObject, powerUpSound.length);
        }
    }
}
