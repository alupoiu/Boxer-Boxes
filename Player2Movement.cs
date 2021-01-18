using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Movement : MonoBehaviour
{

    public GameObject player2;
    public GameObject pointController;
    public PointSystem pointSystem;
    public GameObject canvasController;
    public CountDown countDown;

    Rigidbody rb2;

    public Vector3 player2Input;

    public float speed = 5f;
    public float energy;

    void Start()
    {
        rb2 = player2.GetComponent<Rigidbody>();
        pointController = GameObject.FindGameObjectWithTag("Point Controller");
        pointSystem = pointController.GetComponent<PointSystem>();
        speed = OptionsMenu.Data.playerSpeed;
        canvasController = GameObject.FindGameObjectWithTag("Canvas Controller");
        countDown = canvasController.GetComponent<CountDown>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (countDown.isCountingDown == false)
        {
            PlayerMovement();
            EnergyCharge();
        }
    }
    void PlayerMovement()
    {
        if (rb2 == null)
        {
            return;
        }

        float X2 = Input.GetAxis("Horizontal2");
        float Z2 = Input.GetAxis("Vertical2");

        if (pointSystem.hasWon != true)
            rb2.transform.Translate(X2 * speed * Time.deltaTime, 0, Z2 * speed * Time.deltaTime, Space.World);

        if (Input.GetKey(KeyCode.Return) && energy > 10f && pointSystem.hasWon != true)
        {
            rb2.AddForce(new Vector3(X2, 0, Z2) * 100f);
            energy -= 10f;
        }
    }
    void EnergyCharge()
    {
        if (energy < 100f)
        {
            energy += OptionsMenu.Data.chargeSpeed;
        }
    }
}
