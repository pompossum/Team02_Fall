using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject[] inventory = new GameObject[12];
    private void OnTriggerEnter(Collider col)
        public class pickupItem : MonoBehaviour
    { 
    
        void OnTriggerEnter(Collider other)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Destroy(other.gameObject);
            }
        }
    
    {
        //when a collision occurs find out what you collided with and 
        // add interactable objects to inventory if room is available in inventory array
        //show the name of the object you collided with
        Debug.Log("you collided with the " + col.gameObject.name);
        GameObject SomeObject;
        SomeObject = col.gameObject;
        //disable the mesh renderer to make the object disappear
        MeshRenderer theMesh = SomeObject.GetComponent<MeshRenderer>();
        theMesh.enabled = false;
        Debug.Log("the tag is " + SomeObject.tag);
        bool isThere = false;
        if (SomeObject.CompareTag("Interact"))
        {
            for (int i = 0; i < inventory.Length; i++)
            {
                if (inventory[i] == SomeObject)
                {
                    isThere = true;
                    break;             //if the item is already in the inventory array, exit the loop
                }
            }
            if (!isThere)      // the item is not in the array, so add it
            {
                AddObject(SomeObject);  // call a method to add the item to the 
                                        //array at the next available slot
            }
        }
    }

    public void AddObject(GameObject item)
    {
        bool itemAdded = false;
        // find the first open slot in the array
        //if there is no available position, show "inventory full message"
        // the itemAdded boolean determines if the inventory is full
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] == null)
            {
                inventory[i] = item;
                Debug.Log(item.name + " was added");
                itemAdded = true;
                Debug.Log(item.name + " has disappeared");
                break;
            }
        }
        if (!itemAdded)
        {
            Debug.Log("Inventory full - item not added");
        }
    }
}
