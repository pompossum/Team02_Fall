using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Jeff Wakeman
//12/3/19
//Special thing for biodome. Controls sprinkler to make trees grow. Placed on consol in biodome
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
            transform.GetChild(i).localScale = new Vector3(4f, 4f, 4f);
        }

    }
}
