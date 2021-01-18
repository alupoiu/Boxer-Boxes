using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyController : MonoBehaviour
{
    public Slider slider;

    public GameObject player1;
    public GameObject player2;

    public Player1Movement player1Movement;
    public Player2Movement player2Movement;

    public bool p1;
    public bool p2;

    public void Update()
    {
        if(player1 == null && p1 == true)
        {
            player1 = GameObject.FindGameObjectWithTag("Destroyable1");
        }
        if(player1Movement == null && player1 != null && p1 == true)
        {
            player1Movement = player1.GetComponent<Player1Movement>();
        }
        if (player2 == null && p2 == true)
        {
            player2 = GameObject.FindGameObjectWithTag("Destroyable2");
        }
        if (player2Movement == null && player2 != null && p2 == true)
        {
            player2Movement = player2.GetComponent<Player2Movement>();
        }
        if (p1)
        {
            slider.value = player1Movement.energy;
        }
        if (p2)
        {
            slider.value = player2Movement.energy;
        }
    }
}
