using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject countDownObject;

    public bool isPaused;

    public CountDown countDown;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && countDown.isCountingDown == false)
        {
            PauseManager();
        }
        if(isPaused == true)
        {
            Time.timeScale = 0;
        }
        if(isPaused == false && countDown.isCountingDown == false)
        {
            Time.timeScale = 1;
        }
        if(isPaused == true)
        {
            countDownObject.SetActive(false);
        }
    }
    public void Menu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void PauseManager()
    {
        pauseMenu.SetActive(!pauseMenu.activeSelf);
        isPaused = pauseMenu.activeSelf;
    }
}
