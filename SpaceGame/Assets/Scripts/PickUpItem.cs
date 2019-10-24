using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Jeff Wakeman, Jaime Calderon
// 10/15/19 Created
//Script is used in all scenes where Interactable objects that can be picked up are
//Attached to all Interactable objects
//Allows a player to pick up an Interactable object with the F key, and adds the game object to a private instance of inventory
public class PickUpItem : MonoBehaviour
{
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && Input.GetKeyDown(KeyCode.F))
        {
            if (GameStatus.GetLength() < 12)//Checks if there is room in player inventory
            {
                GameStatus.AddInventory(this.gameObject);//adds object to inventory
                this.gameObject.SetActive(false);
                Debug.Log(this.gameObject.name);
            }
            else
            {
                Debug.Log("Inventory Full!");//tells the player their inventory is full
            }
        }
    }
}
