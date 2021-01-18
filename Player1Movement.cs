using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player1Movement : MonoBehaviour
{

    public GameObject player1;
    public GameObject pointController;
    public PointSystem pointSystem;
    public GameObject canvasController;
    public CountDown countDown;

    Rigidbody rb1;

    public Vector3 player1Input;

    public float speed = 5f;
    public float energy;

    void Start()
    {
        rb1 = player1.GetComponent<Rigidbody>();
        pointController = GameObject.FindGameObjectWithTag("Point Controller");
        pointSystem = pointController.GetComponent<PointSystem>();
        speed = OptionsMenu.Data.playerSpeed;
        canvasController = GameObject.FindGameObjectWithTag("Canvas Controller");
        countDown = canvasController.GetComponent<CountDown>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(countDown.isCountingDown == false)
        {
            PlayerMovement();
            EnergyCharge();
        }
    }

    void PlayerMovement()
    {
        if (rb1 == null)
        {
            return;
        }

        float X1 = Input.GetAxis("Horizontal");
        float Z1 = Input.GetAxis("Vertical");

        if (pointSystem.hasWon != true)
            rb1.transform.Translate(X1 * speed * Time.deltaTime, 0, Z1 * speed * Time.deltaTime, Space.World);

        if (Input.GetKey(KeyCode.Space) && energy > 10f && pointSystem.hasWon != true)
        {
            rb1.AddForce(new Vector3(X1, 0, Z1) * 100f);
            energy -= 10f;
        }
    }

    void EnergyCharge()
    {
        if(energy < 100f)
        {
            energy += OptionsMenu.Data.chargeSpeed;;
        }
    }
}
