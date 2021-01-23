using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointSystem : MonoBehaviour
{
    // Defines variables for player points
    public int player1Points;
    public int player2Points;

    // Defines UI screen for endgame options
    public GameObject endGameOptions;

    // Defines manipulated UI 
    public Text pointText;
    public Text winStatement;
    public Image fill1;
    public Image fill2;

    // Calls boolean for triggering win event
    public bool hasWon = false;

    public void Update()
    {
        // Changes UI to display current score
        pointText.text = player1Points.ToString() + " - " + player2Points.ToString();

        // Runs win statement when a specific number of points are fulfilled
        if(player1Points == OptionsMenu.Data.roundCount && hasWon == false)
        {
            hasWon = true;
            fill1.color = new Color(229, 59, 59, 0);
            fill2.color = new Color(45, 77, 214, 0);
            winStatement.text = "Red Wins!";
        }
        if(player2Points == OptionsMenu.Data.roundCount && hasWon == false)
        {
            hasWon = true;
            fill1.color = new Color(229, 59, 59, 0);
            fill2.color = new Color(45, 77, 214, 0);
            winStatement.text = "Blue Wins!";
        }

        // Displays endgame options
        if(hasWon == true)
        {
            endGameOptions.SetActive(true);
        }
        else
        {
            endGameOptions.SetActive(false);
        }
    }
}
