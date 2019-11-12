using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
//11/12/2019 Jaime made a light switch
{
    public GameObject light;
    private bool on = false;

    // Use this for initialization
    void OnTriggerStay(Collider plyr)
    {
        if (plyr.tag == "Player" && Input.GetKeyDown(KeyCode.F) && !on)
        {
            light.SetActive(true);
            on = true;
        }
        else if (plyr.tag == "Player" && Input.GetKeyDown(KeyCode.F) && on)
        {
            light.SetActive(false);
            on = false;
        }
    }
}
