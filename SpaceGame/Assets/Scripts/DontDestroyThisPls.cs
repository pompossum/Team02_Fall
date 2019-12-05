using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyThisPls : MonoBehaviour
{
    void Awake()
    {
        GameObject.DontDestroyOnLoad(gameObject);
    }
}
