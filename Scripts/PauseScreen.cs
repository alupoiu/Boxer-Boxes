using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour
{
    // Defines gameobjects that are manipulated when paused
    public GameObject pauseMenu;
    public GameObject countDownObject;

    // Defines game pausing for reference script manipulation
    public bool isPaused;

    // References countdown script
    public CountDown countDown;

    public void Update()
    {
        // Runs pause function if the game is not counting down
        if(Input.GetKeyDown(KeyCode.Escape) && countDown.isCountingDown == false)
        {
            PauseManager();
        }

        if(isPaused == true)
        {
            // Freezes timescale at 0
            Time.timeScale = 0;
            countDownObject.SetActive(false);
        }
        else
        {
            // Resets timescale
            Time.timeScale = 1;
        }
    }

    public void PauseManager()
    {
        // Activates and deactivates the pause menu based on the current state
        pauseMenu.SetActive(!pauseMenu.activeSelf);
        isPaused = pauseMenu.activeSelf;
    }
}
