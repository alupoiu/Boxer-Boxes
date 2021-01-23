using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    // Defines global variables for game options
    public static class Data
    {
        public static float playerSpeed = 5f;
        public static float chargeSpeed = 0.2f;
        public static float roundCount = 5f;
        public static float volume = 100f;
    }

    // Defines UI elements for game options
    public Text playerSpeedText;
    public Text chargeSpeedText;
    public Text roundCountText;
    public Text volumeText;

    public Slider playerSpeedSlider;
    public Slider chargeSpeedSlider;
    public Slider roundCountSlider;
    public Slider volumeSlider;


    public void Update()
    {
        // Sets all sliders to data values
        if(playerSpeedSlider != null && chargeSpeedSlider != null && roundCountSlider != null && volumeSlider != null)
        {
            playerSpeedSlider.value = Data.playerSpeed;
            chargeSpeedSlider.value = Data.chargeSpeed * 10f;
            roundCountSlider.value = Data.roundCount;
            volumeSlider.value = Data.volume;
        }
    }

    // Receives UI input from all sliders, manipulates global variables, and displays slider value
    public void SetPlayerSpeed(float Speed)
    {
        Data.playerSpeed = Speed;
        playerSpeedText.text = ("Player Speed: " + Data.playerSpeed.ToString());
        if(Speed == 5)
        {
            playerSpeedText.text = ("Player Speed: " + Data.playerSpeed.ToString() + " (Default)");
        }
    }
    public void SetChargeSpeed(float Speed)
    {
        Data.chargeSpeed = Speed * 0.1f;
        chargeSpeedText.text = ("Charge Speed: " + Data.chargeSpeed.ToString());
        if (Speed == 2)
        {
            chargeSpeedText.text = ("Charge Speed: " + Data.chargeSpeed.ToString() + " (Default)");
        }
    }
    public void SetRounds(float Rounds)
    {
        Data.roundCount = Rounds;
        roundCountText.text = ("Rounds: " + Data.roundCount.ToString());
        if (Rounds == 5)
        {
            roundCountText.text = ("Rounds: " + Data.roundCount.ToString() + " (Default)");
        }
    }
    public void SetVolume(float Volume)
    {
        Data.volume = Volume;
        volumeText.text = ("Volume: " + Data.volume.ToString());
    }
}
