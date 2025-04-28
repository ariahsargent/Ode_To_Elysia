using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* 
 * Code created by: Ariah Sargent
 * Year: 2025
 * For GIMM Individual Game at Boise State University
 * References used:
 *  ChaptGPT -> for lots of troubleshooting
 *      https://chatgpt.com/share/680f673d-5e80-8007-bf36-b2ef3eee7008
 */

public class PauseMenuNavigation : MonoBehaviour
{
    
        public Button resumeButton;
        public Button optionsButton;
        public Button mainButton;
    public Button backButton;
        private Button[] buttons;
        private int selectedButtonIndex = 0;

        void Start()
        {
            buttons = new Button[] { resumeButton, optionsButton, mainButton, backButton };
            UpdateButtonSelection();
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                selectedButtonIndex = (selectedButtonIndex + 1) % buttons.Length;
                UpdateButtonSelection();
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                selectedButtonIndex = (selectedButtonIndex - 1 + buttons.Length) % buttons.Length;
                UpdateButtonSelection();
            }

            if (Input.GetKeyDown(KeyCode.Return))
            {
                // trigger selected button's onClick()
                buttons[selectedButtonIndex].onClick.Invoke();
            }
        }

        void UpdateButtonSelection()
        {
            //change bubton color when selected
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].GetComponent<Image>().color = i == selectedButtonIndex ? Color.green : Color.white;
            }
        }
    }
