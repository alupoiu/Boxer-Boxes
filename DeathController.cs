using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathController : MonoBehaviour
{
    public PlayerSpawn playerSpawn;
    public GameObject player1;
    public GameObject player2;

    public bool justDied;

    private void Update()
    {
        if(player1 == null)
        {
            player1 = GameObject.FindGameObjectWithTag("Destroyable1");
        }
        if (player2 == null)
        {
            player2 = GameObject.FindGameObjectWithTag("Destroyable2");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Destroyable1")
        {
            Object.Destroy(other.gameObject);
            Object.Destroy(player2);
            playerSpawn.isDead1 = true;
            justDied = true;
        }
        if (other.gameObject.tag == "Destroyable2")
        {
            Object.Destroy(other.gameObject);
            Object.Destroy(player1);
            playerSpawn.isDead2 = true;
            justDied = true;
        }
    }
}
