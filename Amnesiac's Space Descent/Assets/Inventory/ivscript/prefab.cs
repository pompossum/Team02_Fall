using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prefab : MonoBehaviour
{
    public GameObject ItemToCollect;
    void Start()
    {
        
        //spawn the blue sphere Object1Blue prefab
        //create 10 of them in random positions in the scene

        for (int i = 0; i < 10; i++)
        {
            GameObject ItemObject = GameObject.Instantiate<GameObject>(ItemToCollect);
            ItemObject.transform.position = new
                Vector3(Random.Range(-18, 18), .5f, Random.Range(-18, 18));
            ItemObject.name = "blueBall" + i;
        }
    
    }

}