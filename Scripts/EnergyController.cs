using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyController : MonoBehaviour
{
    // Calls slider UI element
    public Slider slider;

    // Calls reference script
    public PlayerController playerController;

    // Calls booleans to be used for defining slider assignments
    public bool p1;
    public bool p2;

    public void Update()
    {
        // Slider value is changed based on the playerController reference variable
        if (p1)
        {
            slider.value = playerController.energy1;
        }
        if (p2)
        {
            slider.value = playerController.energy2;
        }
    }
}
