using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
