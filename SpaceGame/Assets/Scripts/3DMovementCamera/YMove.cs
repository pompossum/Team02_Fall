using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Nikki Garcia
// 10/15/19 Created
// Attached To Camera
// Used in No Gravity Environment
// All Scenes w/o Gravity
public class YMove : MonoBehaviour
{
    public float speed = 0;
    public float speedInc = .05f;
    public float maxSpeed = 5f;
    public float minSpeed = -5f;
    public bool collided = false;
    //private void OnCollisionEnter(Collision collision)
    //{
    //    collided = true;
    //}
    //private void nCollisionExit(Collision collision)
    //{
    //    collided = false;
    //}
    void FixedUpdate()
    {
        // Speed Correction
        if (speed > maxSpeed)
        {
            speed = maxSpeed;
        }

        else if (speed < minSpeed)
        {
            speed = minSpeed;
        }

        // Forward
        if (Input.GetKey(KeyCode.Q))
        {
            if (speed < maxSpeed)
            {
                speed += speedInc;
            }
        }

        // Backwards
        else if (Input.GetKey(KeyCode.E))
        {
            if (speed > minSpeed)
            {
                speed -= speedInc;
            }
        }
        // Slow Down
        else if (!Input.GetKey(KeyCode.Q) && !Input.GetKey(KeyCode.E))
        {
            if (speed != 0)
            {
                if (speed < 0)
                {
                    speed += speedInc;
                }
                else if (speed > 0)
                {
                    speed -= speedInc;
                }

                if (speed < .20f && speed > -.20f)
                {
                    speed = 0;
                }
            }
        }
        // Move
        if (speed != 0)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
    }
}

