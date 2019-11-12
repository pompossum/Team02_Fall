using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxFall : MonoBehaviour
//upon entering empty game object the player will trigger a box fall above them
{
    public Rigidbody rb1;
    public Rigidbody rb2;
    public Rigidbody rb3;
    public Rigidbody rb4;
    public Rigidbody rb5;
    public Rigidbody rb6;
    public Rigidbody rb7;
    void Start()
    {
      // rb1 = GetComponent<Rigidbody>();
      // rb2 = GetComponent<Rigidbody>();
      // rb3 = GetComponent<Rigidbody>();
      // rb4 = GetComponent<Rigidbody>();
      // rb5 = GetComponent<Rigidbody>();
      // rb6 = GetComponent<Rigidbody>();
      // rb7 = GetComponent<Rigidbody>();
    }

    // Let the rigidbody take control and detect collisions.
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            rb1.isKinematic = false;
            rb1.useGravity = true;
            rb2.isKinematic = false;
            rb2.useGravity = true;
            rb3.isKinematic = false;
            rb3.useGravity = true;
            rb4.isKinematic = false;
            rb4.useGravity = true;
            rb5.isKinematic = false;
            rb5.useGravity = true;
            rb6.isKinematic = false;
            rb6.useGravity = true;
            rb7.isKinematic = false;
            rb7.useGravity = true;
        }
    }
}
