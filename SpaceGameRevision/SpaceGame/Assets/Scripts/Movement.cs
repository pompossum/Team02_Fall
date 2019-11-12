using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Jeff Wakeman, Nikki Garcia
// 10/15/19 Created
//Script is used in all scenes where the Player Prefab is located
//Attached to Player Prefab
//Moves the Player along the X and Z axes and gives the Player Prefab a jump movement option
public class Movement : MonoBehaviour
{
    public float moveSpeed = 10f;
    public GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        //Vector3.forward means move on Z axis
        if(Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
        //moves backwards
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(-Vector3.forward * moveSpeed * Time.deltaTime);
        }
        //moves left
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }
        //moves right
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }
        //jumps
        if (Input.GetKey(KeyCode.Space))
        {
            if (player.transform.position.y == 1);
            {
               transform.Translate(Vector3.up * 10 * Time.deltaTime);
            }
        }
    }
}
