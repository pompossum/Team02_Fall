using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Jeff Wakeman
//On the player prefab
//12/3/19
public class Flashlight : MonoBehaviour
{
    public Light flashlight;
    public bool on = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L) && on)
        {
            GetComponent<Light>().enabled = false;
            on = false;
        }
        else if (Input.GetKeyDown(KeyCode.L) && !on)
        {
            GetComponent<Light>().enabled = true;
            on = true;
        }
    }
}
