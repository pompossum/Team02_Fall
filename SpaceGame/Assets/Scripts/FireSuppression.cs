using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSuppression : MonoBehaviour
{
    private bool on = false;
    public ParticleSystem water;
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && Input.GetKeyDown(KeyCode.F))
        {
            if (on)
            {
                on = false;
                water.Play();
            }
            else if (!on)
            {
                on = true;
                water.Stop();
                Grow();
            }
        }
    }
    void Grow()
    {
        int children = transform.childCount;
        for (int i = 0; i < children; i++)
        {
            transform.GetChild(i).localScale = new Vector3(200f, 200f, 200f);
        }

    }
}
