using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Jeff Wakeman, Nikki Garcia
// 10/15/19 Created
//Script is used in all scenes where the Player Prefab is located
//Attached to Player Prefab
//Allows for camera movement through mouse movement
//Alternate camera control used for Phase II
public class cameraController : MonoBehaviour
{

    public enum RotationAxis
    {
        MouseX = 1,
        MouseY = 2
    }

    public RotationAxis axes = RotationAxis.MouseX;
    //sensitivity for the movement looking horizontally
    public float sensHorizontal = 10.0f;
    //sensitivity for the movement looking vertically
    public float sensVertical = 10.0f;
    //the vertical angle at the which the player is looking
    public float rotationX = 0;

    public float minimumVert = -45.0f;
    public float maximumVert = 45.0f;
    void Update()
    {
        if (axes == RotationAxis.MouseX)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensHorizontal, 0);
        }
        else if (axes == RotationAxis.MouseY)
        {
            //increment the vertical axis based on the mouse movements
            rotationX -= Input.GetAxis("Mouse Y") * sensVertical;
            // this clamps the vertical angle withing the minimum and maximum limits
            rotationX = Mathf.Clamp(rotationX, minimumVert, maximumVert);

            float rotationY = transform.localEulerAngles.y;
            //create a new vector for the stored rotation values
            transform.localEulerAngles = new Vector3(rotationX, rotationY, 0);
        }
    }
}
