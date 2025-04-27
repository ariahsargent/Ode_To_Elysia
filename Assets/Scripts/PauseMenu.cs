using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEditor.Build;

public class PauseMenu : MonoBehaviour
{
    public static bool Paused = false;
    public GameObject PauseMenuCanvas;
    public GameObject OptionsMenuCanvas;
    public GameObject firstPauseButton;
    public GameObject firstOptionsButton;

    public CharacterMovement PlayerScript;
    void Start()
    {
        Time.timeScale = 1f;
        if (PauseMenuCanvas != null) PauseMenuCanvas.SetActive(false);
        if (OptionsMenuCanvas != null) OptionsMenuCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Paused)
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
        PlayerScript.canMove = true;
        Time.timeScale = 0f;
        Paused = true;

    }

    public void Play()
    {
        PauseMenuCanvas.SetActive(false);
        PlayerScript.canMove = false;
        Time.timeScale = 1f;
        Paused = false;
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void OpenOptionsMenu()
    {
        if (OptionsMenuCanvas != null)
        {
            OptionsMenuCanvas.SetActive(true);
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(firstOptionsButton);
        }

        if (PauseMenuCanvas != null)
        {
            PauseMenuCanvas.SetActive(false);    
        }
    }

    public void CloseOptionsMenu()
    {
        if (OptionsMenuCanvas != null)
        {
            OptionsMenuCanvas.SetActive(false);
        }

        if (PauseMenuCanvas != null)
        {
            PauseMenuCanvas.SetActive(true);
        }
    }
}
