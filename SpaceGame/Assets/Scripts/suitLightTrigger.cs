using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class suitLightTrigger : MonoBehaviour
{
    // Justin Bittner
    // 11/26/19 1628

    // This little lightSource of mine
    // I'm going to let it shine.
    // Briefly.
    // Then turn it off.
    public GameObject lightSource;

    // On Box Collider Collide
    // Turn Light On
    private void OnTriggerEnter(Collider obj)
    {
        if (obj.gameObject.tag == "Player")
        {
            lightSource.SetActive(true);
        }
    }


    // On Box Collider Exit
    // Turn Light Off
    private void OnTriggerExit(Collider obj)
    {
        if (obj.gameObject.tag == "Player")
        {
            lightSource.SetActive(false);
        }
    }
}
