using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Jeff Wakeman
//11/23/19
//Placed on the power switch. Used to toggle the power on and off
public class PowerSwitch : MonoBehaviour
{
    private bool on;
    void Start()
    {
        if(GameStatus.GetCurrent().power == false)
        {
            on = false;
        }
        else if(GameStatus.GetCurrent().power == true)
        {
            on = true;
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && Input.GetKeyDown(KeyCode.F))
        {
            if(on)
            {
                on = false;
                GameStatus.GetCurrent().power = false;
            }
            else if(!on)
            {
                on = true;
                GameStatus.GetCurrent().power = true;
            }
        }
    }
}
