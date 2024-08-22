using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPowerUp : MonoBehaviour
{
    public AudioClip powerUpSound;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (audioSource == null || powerUpSound == null)
        {
            Debug.LogError("Missing AudioSource or AudioClip!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            //destroy object
            Destroy(other.gameObject);

            //play sound
            audioSource.PlayOneShot(powerUpSound);

            //apply power-up effect here **

        }
    }
}
