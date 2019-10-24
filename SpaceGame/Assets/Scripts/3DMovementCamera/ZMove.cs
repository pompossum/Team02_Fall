using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZMove : MonoBehaviour
{
    public float speed = 0;
    public float speedInc = .05f;
    public float maxSpeed = 5f;
    public float minSpeed = -5f;

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
        if (Input.GetKey(KeyCode.D))
        {
            if (speed < maxSpeed)
            {
                speed += speedInc;
            }
        }

        // Backwards
        else if (Input.GetKey(KeyCode.A))
        {
            if (speed > minSpeed)
            {
                speed -= speedInc;
            }
        }
        // Slow Down
        else if (!Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
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
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
    }
}
