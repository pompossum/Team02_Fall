using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
