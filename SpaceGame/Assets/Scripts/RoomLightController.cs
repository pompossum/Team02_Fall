﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Jeff Wakeman
//11/25/19
//Used in every room. Controls the lighting so the lights are on if the power is on and emergency lights are on if the power is off
public class RoomLightController : MonoBehaviour
{
    public Light wl;
    public Light rl;
    public ParticleSystem ps;
    void Start()
    {
        if (GameStatus.GetCurrent().power == false)
        {
            wl.enabled = false;
            StartCoroutine(Flashing());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(GameStatus.GetCurrent().power == true)
        {
            StopAllCoroutines();
            wl.enabled = true;
            rl.enabled = false;
            ps.Stop();
        }
    }
    IEnumerator Flashing()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(0.1f, 0.5f));
            rl.enabled = !rl.enabled;
        }
    }
}