using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    // Callsefines reference scripts
    public DeathController deathController;
    public PointSystem pointSystem;
    public GameObject energyBars;

    // Defines duration on the IEnumerator
    public int countdownTime = 3;

    // Callsefines the display text during countdown
    public Text countdownText;

    // Defines bool to stop player movement during countdown
    public bool isCountingDown;

    void Update()
    {
        // Disables visual after win event
        if (pointSystem.hasWon == true)
        {
            countdownText.gameObject.SetActive(false);
        }
        // Starts countdown after each death
        if (deathController.justDied == true)
        {
            StartCoroutine(Countdown());
        }
    }
    IEnumerator Countdown()
    {
        isCountingDown = true;

        // Sets up UI during countdown
        if (pointSystem.hasWon == false)
        {
            countdownText.gameObject.SetActive(true);
        }
        energyBars.SetActive(false);

        // Counts down and displays time until game start
        while (countdownTime > 0)
        {
            countdownText.text = countdownTime.ToString();
            yield return new WaitForSeconds(1f);
            countdownTime--;
        }

        // Sets up UI for game start
        energyBars.SetActive(true);
        countdownText.text = "GO!";

        isCountingDown = false;

        // Waits before disabling "GO!" visual
        yield return new WaitForSeconds(0.5f);
        countdownText.gameObject.SetActive(false);

        // Resets countdown
        countdownTime = 3;
    }
}
