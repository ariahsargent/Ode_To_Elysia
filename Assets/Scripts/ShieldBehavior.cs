using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBehavior : MonoBehaviour
{
    public GameObject shieldVisual;
    public Transform playerCamera; //ref player's camera
    public Transform player;
    public Vector3 shieldOffset;

    //brings it closer or further away as needed
    //float distanceFromPlayer = 0.2f;

    //speed shield gets rotated by player
    public float rotationSpeed = 10f;

    //start shield as active
    //public bool shieldActive = true;
    //public Vector3 shieldOffset = new Vector3(0, 0, 1); //keep shield in front of player
   
    void Start()
    {
        //load shield with scene
        //shieldVisual.SetActive(shieldActive);
        Debug.Log("shield loaded in at" + shieldVisual.transform.position);
    }


    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = new Vector3(player.position.x, player.position.y + shieldOffset.y, player.position.z);
        shieldVisual.transform.position = newPosition;

        /*
        //trigger shield on and off
        if (Input.GetKeyDown(KeyCode.Space))
        {
            shieldActive = !shieldActive;
            shieldVisual.SetActive(shieldActive);
            Debug.Log("shield toggled");
        }

        if (shieldActive)
        {
            Vector3 newPosition = transform.position + transform.forward * distanceFromPlayer;
            shieldVisual.transform.position = newPosition;
            
            //UpdateShieldPosition();
            //Debug.Log("updating shield position");
        }
        */
    }
    /*
    void UpdateShieldPosition()
    {
        //position shield in front of player based on camera direction
        shieldVisual.transform.position = transform.position + playerCamera.transform.forward * distanceFromPlayer;

        //rotate shield to match camera's facing
        //flipped with -playerCamera to put in on rightside of player's view
        shieldVisual.transform.rotation = Quaternion.LookRotation(-playerCamera.transform.forward);

        //Debug.Log("shield position:" + shieldVisual.transform.position);
    }*/
}
