using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
// Justin BIttner
// 12/1/2019 2335
// Captains Logs...
// Compiles Interactable Items Into A List With Required Items To Interact With
// And Gives The Effect To Be Triggered

// Also Removes Items From Inventory
public class ItemReqList : MonoBehaviour
{
    // Ini Format
    // [X, 0] Object Interacted With's Name
    // [X, 1] Scene Name For This Item Use
    // [X, 2] Object Required To Interact With Object In 0.
    // [X, 3] Name Of Function To Trigger Upon Completion
    // For [X,3] Attach Script With Function To Same Game Object As This Script
    // Failure To Do So May Result In Complete System Failure
    // Or it just won't work...
    // [X, 4] Remove Item After This Specific Use? (y,n)
    // Ini Example Below
    // Interactable name!Scene Name@Required Item's Name#Name Of Function$Remove After This Use(y,n)
    // Hull Breach!Barracks@Arc Welder#RepairHullFunction$y

    // Global Declaration
    int foundOne;

    // Public Declaration
    public string[,] itemList;
    public int objectsInList;
    void Start()
    {
        objectsInList = GameObject.Find("GameStatus").GetComponent<GameStatus>().objectsInList;
        itemList = new string[objectsInList, 5];

        for (int i = 0; i < objectsInList; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                itemList[i, j] = GameObject.Find("GameStatus").GetComponent<GameStatus>().itemList[i, j];
            }
        }
    }

    // Use Item
    void OnTriggerStay(Collider other)
    {
        GameObject gameStatus = GameObject.Find("GameStatus");

        string nameOne = "";
        string nameTwo = "";
        string funcToCall;

        int timesSpotted = 0;

        if (other.tag == "Player" && Input.GetKeyDown(KeyCode.F))
        {
            timesSpotted = 0;
            // Scans For Object In The List
            for (int i = 0; i < objectsInList; i++)
            {
                if (timesSpotted == 0)
                {
                    // Continues To Next Check
                    if (itemList[i, 0] == gameObject.name)
                    {
                        timesSpotted = 1;
                        nameOne = itemList[i, 2];
                        foundOne = i;
                        for (int j = i + 1; j < objectsInList; j++)
                        {
                            if (itemList[j, 0] == gameObject.name)
                            {
                                nameTwo = itemList[j, 2];
                                Debug.Log(nameOne);
                                Debug.Log(nameTwo);
                                timesSpotted = 2;
                                j = objectsInList;
                            }
                        }
                    }
                }
            }

            // Calls Check Function
            // Checks If Item Is To Be Removed
            // Then Removes Item
            if (timesSpotted == 1)
            {
                if (InInventory(nameOne))
                {
                    funcToCall = itemList[foundOne, 3];
                    gameObject.SendMessage(funcToCall, itemList[foundOne, 2]);
                    removeItem(nameOne);
                }
            }

            else if (timesSpotted == 2)
            {
                if (InInventory(nameOne, nameTwo))
                {
                    Debug.Log("True");
                    funcToCall = itemList[foundOne, 3];
                    gameObject.SendMessage(funcToCall);
                    Debug.Log("Hit");
                    removeItem(nameOne);
                    Debug.Log("Hit2");
                    removeItem(nameTwo);

                }
            }
        }
    }
    void removeItem(string removeThis)
    {
        bool removed;
        removed = false;

        for (int i = 0; i < GameStatus.inventory.Count; i++)
        {
            if (!removed)
            {
                if (GameStatus.inventory[i].name == removeThis)
                {
                    GameStatus.inventory.Remove(GameStatus.inventory[i].gameObject);
                    removed = true;
                    Debug.Log("Removed " + GameStatus.inventory[i].gameObject.name);
                }
            }
        }
    }

    // Inventory Scans
    // One Item Scan
    public bool InInventory(string item1)
    {
        for (int i = 0; i < GameStatus.inventory.Count; i++)
        {
            if (GameStatus.inventory[i].gameObject.name.ToString() == item1)
            {
                return true;
            }
        }
        return false;
    }

    // Two Item Scan
    public bool InInventory(string item1, string item2)
    {
        foreach (GameObject i in GameStatus.inventory)
        {
            if (i.gameObject.name.ToString() == item1)
            {
                foreach (GameObject j in GameStatus.inventory)
                {
                    if (j.gameObject.name.ToString() == item2)
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }
}
