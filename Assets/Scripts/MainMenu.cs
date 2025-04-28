using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

/* 
 * Code created by: Ariah Sargent
 * Year: 2025
 * For GIMM Individual Game at Boise State University
 * References used:
 *  GarrettDeveloper on YouTube -> Unity MAIN MENU 2022 Tutorial | Beginner Friendly
 *      https://www.youtube.com/watch?v=pcyiub1hz20&ab_channel=GarrettDeveloper
 *  ChaptGPT -> for lots of troubleshooting
 *      https://chatgpt.com/share/680f673d-5e80-8007-bf36-b2ef3eee7008
 * 
 */
public class MainMenu : MonoBehaviour
{
    public GameObject MainMenuCanvas;
    public GameObject OptionsMenuCanvas;
    //pre select options so you can select via arrow or wasd keys
    public GameObject firstMainButton;
    public GameObject firstOptionsButton;

    private void Start()
    {
        if (MainMenuCanvas != null) MainMenuCanvas.SetActive(true);
        if (OptionsMenuCanvas != null) OptionsMenuCanvas.SetActive(false);
    }

    private void Update()
    {
        EventSystem.current.SetSelectedGameObject(null);    //reset selection
        EventSystem.current.SetSelectedGameObject(firstMainButton);
    }

    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void BackToMain()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void OpenOptionsMenu()
    {
        if (OptionsMenuCanvas != null)
        {
            OptionsMenuCanvas.SetActive(true);
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(firstOptionsButton);
        }

        if (MainMenuCanvas != null)
        {
            MainMenuCanvas.SetActive(false);
        }
    }

    public void CloseOptionsMenu()
    {
        if (OptionsMenuCanvas != null)
        {
            OptionsMenuCanvas.SetActive(false);
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(firstMainButton);
        }
        if (MainMenuCanvas != null)
        {
            MainMenuCanvas.SetActive(true);
        }
    }

    public void Quit()
    {
        Debug.Log("Player Has Quit The Game");
        Application.Quit();
    }
}
