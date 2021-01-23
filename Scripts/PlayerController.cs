using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Defines player gameobjects and their rigidbody components
    public GameObject player1;
    public GameObject player2;
    Rigidbody rb1;
    Rigidbody rb2;

    // Defines player speed and player energy values
    public float speed = 5;
    public float energy1 = 50;
    public float energy2 = 50;

    // Defines variables for player input on the X and Z axis
    float X1;
    float Z1;
    float X2;
    float Z2;
    Vector3 player1Input;
    Vector3 player2Input;

    // Defines booleans for settings for modifying player input based on gamemode
    public bool localPlayer;
    public bool multiPlayer;
    public bool playerRed;
    public bool playerBlue;

    // Defines reference script
    public CountDown countDown;
    public PointSystem pointSystem;

    public void Update()
    {
        // Finds player gameobjects after their destruction and assigns their respective rigidbody components to their variables
        if(player1 == null || player2 == null)
        {
            player1 = GameObject.FindGameObjectWithTag("Destroyable1");
            player2 = GameObject.FindGameObjectWithTag("Destroyable2");
        }
        if(rb1 == null&& player1 != null)
        {
            rb1 = player1.GetComponent<Rigidbody>();
        }
        if (rb2 == null && player2 != null)
        {
            rb2 = player2.GetComponent<Rigidbody>();
        }

        // Changes input settings based on gamemode (Only local gamemode currently implemented)
        if (localPlayer == true)
        {
            X1 = Input.GetAxis("Horizontal");
            Z1 = Input.GetAxis("Vertical");

            X2 = Input.GetAxis("Horizontal2");
            Z2 = Input.GetAxis("Vertical2");
        }
        if (multiPlayer == true && playerRed == true)
        {
            X1 = Input.GetAxis("Horizontal");
            Z1 = Input.GetAxis("Vertical");
        }
        if (multiPlayer == true && playerBlue == true)
        {
            X2 = Input.GetAxis("Horizontal");
            Z2 = Input.GetAxis("Vertical");
        }
    }
    public void FixedUpdate()
    {
        // Runs movement voids if there is no active counting down event
        if (countDown.isCountingDown == false && pointSystem.hasWon == false)
        {
            if (player1 != null)
            {
                PlayerMovement1();
                EnergyCharge1();
            }
            if (player2 != null)
            {
                PlayerMovement2();
                EnergyCharge2();
            }
        }
    }

    // Moves player 1 and use dash ability
    void PlayerMovement1()
    {
        player1Input = new Vector3(X1, 0, Z1);
        rb1.MovePosition(player1.transform.position + (player1Input * OptionsMenu.Data.playerSpeed * Time.deltaTime));

        if (Input.GetKey(KeyCode.Space) && energy1 > 10f)
        {
            rb1.AddForce(player1Input * 100f);
            energy1 -= 10f;
        }
    }

    // charges dash ability if it is below 100
    void EnergyCharge1()
    {
        if (energy1 < 100f)
        {
            energy1 += OptionsMenu.Data.chargeSpeed;
        }
    }

    // Moves player 2 and use dash ability
    void PlayerMovement2()
    {
        player2Input = new Vector3(X2, 0, Z2);
        rb2.MovePosition(player2.transform.position + (player2Input * OptionsMenu.Data.playerSpeed * Time.deltaTime));

        if (Input.GetKey(KeyCode.Return) && energy2 > 10f)
        {
            rb2.AddForce(player2Input * 100f);
            energy2 -= 10f;
        }
    }

    // charges dash ability if it is below 100
    void EnergyCharge2()
    {
        if (energy2 < 100f)
        {
            energy2 += OptionsMenu.Data.chargeSpeed;
        }
    }
}
