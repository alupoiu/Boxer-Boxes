using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    // Defines player gameobjects and their respective spawnpoints 
    // Note that the player gameobjects are prefabs to be respawned, rather than found in the game scene
    public GameObject player1;
    public GameObject player2;
    public GameObject spawn1;
    public GameObject spawn2;

    // Calls reference scripts
    public PointSystem pointSystem;
    public DeathController deathController;
    public PlayerController playerController;

    public void Update()
    {

        if (deathController.justDied == true)
        {
            // Respawns both characters after their deletion
            Object.Instantiate(player1, spawn1.transform);
            Object.Instantiate(player2, spawn2.transform);

            // Sets the charge value of each player
            playerController.energy1 = 50f;
            playerController.energy2 = 50f;
            deathController.justDied = false;
        }

        // Adds respective points to the winner of the round
        if (deathController.isDead1 == true)
        {
            deathController.isDead1 = false;
            pointSystem.player2Points += 1;
        }
        if (deathController.isDead2 == true)
        {
            deathController.isDead2 = false;
            pointSystem.player1Points += 1;
        }
    }
}
