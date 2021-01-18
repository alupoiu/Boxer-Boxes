using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    public DeathController deathController;
    public PointSystem pointSystem;
    public GameObject energyBars;

    public int countdownTime = 3;

    public Text countdownText;

    public bool isCountingDown;

    // Update is called once per frame
    void Update()
    {
        if (deathController.justDied == true)
        {
            StartCoroutine(Countdown());
            deathController.justDied = false;
        }
        if (pointSystem.hasWon == true)
        {
            countdownText.gameObject.SetActive(false);
        }
    }
    IEnumerator Countdown()
    {
            isCountingDown = true;
            countdownText.gameObject.SetActive(true);
            energyBars.SetActive(false);
            while (countdownTime > 0)
            {
                countdownText.text = countdownTime.ToString();
                yield return new WaitForSeconds(1f);
                countdownTime--;
            }
            Time.timeScale = 1;
            energyBars.SetActive(true);
            countdownText.text = "GO!";
            isCountingDown = false;
            yield return new WaitForSeconds(0.5f);
            countdownText.gameObject.SetActive(false);
            countdownTime = 3;
    }
}
