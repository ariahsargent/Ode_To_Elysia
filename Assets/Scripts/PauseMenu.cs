using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEditor.Build;

/* 
 * Code created by: Ariah Sargent
 * Year: 2025
 * For GIMM Individual Game at Boise State University
 * References used:
 *  GarrettDeveloper on YouTube -> Unity PAUSE MENU 2022 Tutorial | Beginner Friendly
 *      https://www.youtube.com/watch?v=bxKEftSIGiQ&t=662s&ab_channel=GarrettDeveloper
 *  ChaptGPT -> for lots of troubleshooting
 *      https://chatgpt.com/share/680f673d-5e80-8007-bf36-b2ef3eee7008
 * 
 */

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject PauseMenuCanvas;
    public GameObject OptionsMenuCanvas;

    //pre select buttons for WASD navigation
    public GameObject firstPauseButton;
    public GameObject firstOptionsButton;


    //ref to player's script - freeze player's movement during pause
    Player player; 

    //public CharacterMovement PlayerScript;
    void Start()
    {
        //sets time to normal
        Time.timeScale = 1f;
        //keeps menus off until turned on
        if (PauseMenuCanvas != null) PauseMenuCanvas.SetActive(false);
        if (OptionsMenuCanvas != null) OptionsMenuCanvas.SetActive(false);

        //finds player in scene
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                PauseMenuCanvas.SetActive(true);
                OptionsMenuCanvas.SetActive(false);
                Play();     //refers to function below to freeze game play and objects
                EventSystem.current.SetSelectedGameObject(null);    //reset selection
                EventSystem.current.SetSelectedGameObject(firstPauseButton);
            }
            else
            {
                Stop();     //unfreezes game play and objects
            }
        }
    }

    void Stop()
    {
        PauseMenuCanvas.SetActive(true);
        OptionsMenuCanvas.SetActive(false); 
        //to access player movement script to continue player movement
        //PlayerScript.canMove = true;
        Time.timeScale = 0f;
        isPaused = true;

        EventSystem.current.SetSelectedGameObject(firstPauseButton.gameObject);
        
        if (player != null)
        {
            player.enabled = false;     //freeze player control
        }

    }

    public void Play()
    {
        PauseMenuCanvas.SetActive(false);
        //to access player movement script to halt player movement
        //PlayerScript.canMove = false;
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void MainMenuButton()
    {
        //need to put time back in place to ensure buttons can be used back at main menu
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
        Destroy(gameObject);  //will destroy pause menu so it doesn't interfer with returning to main menu
    }

    public void OpenOptionsMenu()
    {
        OptionsMenuCanvas.SetActive(true);
        PauseMenuCanvas.SetActive(false);
        /*
        if (OptionsMenuCanvas != null)
        {
            OptionsMenuCanvas.SetActive(true);
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(firstOptionsButton);
        }

        if (PauseMenuCanvas != null)
        {
            PauseMenuCanvas.SetActive(false);    
        }*/
    }

    public void CloseOptionsMenu()
    {
        PauseMenuCanvas.SetActive(true);
        OptionsMenuCanvas.SetActive(false);

        /*
        if (OptionsMenuCanvas != null)
        {
            OptionsMenuCanvas.SetActive(false);
        }

        if (PauseMenuCanvas != null)
        {
            PauseMenuCanvas.SetActive(true);
        }*/
    }
}
