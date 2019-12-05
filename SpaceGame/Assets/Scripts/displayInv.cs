using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Justin Bittner
// Used To Display Inventory
// Press E To Pay Respects
// To Show Inventory*
public class displayInv : MonoBehaviour
{
    bool move;
    bool keyDown;
    bool up;

    string direction;

    float moveSpeed;
    private void Start()
    {
        //Debug.Log(transform.position.y);
    }
    void Update()
    {
        moveSpeed = 100;

        if (move == false)
        {
            // Check Keys
            if (Input.GetKey(KeyCode.E))
            {
                keyDown = true;
            }

            else
            {
                keyDown = false;
            }
        }

        // Start Moving
        if (keyDown == true)
        {
            if (up == false)
            {
                direction = "up";
            }

            else
            {
                direction = "down";
            }

            move = true;
        }

        // Keep Moving
        if (move == true)
        {
            // Up
            if (direction == "up")
            {
                transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
            }

            // Down
            else if (direction == "down")
            {
                transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
            }

            // Auto Set To 624(Up)
            if (transform.position.y >= 624)
            {
                transform.position = new Vector3(transform.position.x, 624, transform.position.z);
                move = false;
                up = true;
            }

            // Auto Set to 574(Down)
            else if (transform.position.y <= 574)
            {
                transform.position = new Vector3(transform.position.x, 574, transform.position.z);
                move = false;
                up = false;
            }
        }
    }
}
