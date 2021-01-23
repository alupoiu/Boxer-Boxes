using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathController : MonoBehaviour
{
    // Defines player gameobjects
    public GameObject player1;
    public GameObject player2;

    // Calls bools to be used for event triggers
    public bool justDied = true;
    public bool isDead1 = false;
    public bool isDead2 = false;

    private void Update()
    {
        // assigns player gameobjects after each death
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
        // Destroys gameobjects after each death and defines the death
        if(other.gameObject.tag == "Destroyable1" && justDied == false)
        {
            Object.Destroy(player1);
            Object.Destroy(player2);
            isDead1 = true;
            justDied = true;
        }
        if (other.gameObject.tag == "Destroyable2" && justDied == false)
        {
            Object.Destroy(player2);
            Object.Destroy(player1);
            isDead2 = true;
            justDied = true;
        }
    }
}
