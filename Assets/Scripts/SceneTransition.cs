using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

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

public class SceneTransition : MonoBehaviour
{
    public GameObject firstSelectButton;

    void Start()
    {
        
    }

    private void Update()
    {
        EventSystem.current.SetSelectedGameObject(null);    //reset selection
        EventSystem.current.SetSelectedGameObject(firstSelectButton);
    }

    public void BackToMain()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Quit()
    {
        Debug.Log("Player Has Quit The Game");
        Application.Quit();
    }


}
