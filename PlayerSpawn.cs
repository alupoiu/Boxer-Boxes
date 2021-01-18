using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    public bool isDead1;
    public bool isDead2;

    public int deathCount1;
    public int deathCount2;

    public GameObject player1;
    public GameObject player2;

    public GameObject spawn1;
    public GameObject spawn2;

    public PointSystem pointSystem;

    void Update()
    {
        if (isDead1 == true)
        {
            Object.Instantiate(player1, spawn1.transform);
            Object.Instantiate(player2, spawn2.transform);
            isDead1 = false;
            deathCount1 += 1;
            pointSystem.player2Points += 1;
        }
        if (isDead2 == true)
        {
            Object.Instantiate(player2, spawn2.transform);
            Object.Instantiate(player1, spawn1.transform);
            isDead2 = false;
            deathCount2 += 1;
            pointSystem.player1Points += 1;
        }
    }
}
