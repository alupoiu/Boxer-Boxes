using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointSystem : MonoBehaviour
{
    public int player1Points;
    public int player2Points;

    public GameObject endGameOptions;

    public Text pointText;
    public Text winStatement;
    public Image fill1;
    public Image fill2;

    public bool hasWon = false;

    // Update is called once per frame
    void Update()
    {
        pointText.text = player1Points.ToString() + " - " + player2Points.ToString();

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
