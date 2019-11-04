using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Jeff Wakeman & Jaime 
//10/17/19
//All the scenes
//Empty object called game status
// Keeps info between scenes. Inventory/ Player data/ map data
//There can only be one!

public class GameStatus : MonoBehaviour
{
    
    public string level; //Holds the current scene's name
    public string prevLevel; //Holds the previous scene's name

    private static List<GameObject> inventory = new List<GameObject>(); //List of inventory items
    private static List<GameObject> isPickedUp = new List<GameObject>(); //Creates a list of all items picked up

    private static GameStatus instance;

    public static GameStatus GetCurrent()
    {
        return instance; //Returns the current instance
    }
    void Awake()
    {
        //Singleton. There can only be one! If one already exists then destroy this one.
        if (instance != null)
        {
            Destroy(this.gameObject);
            Debug.Log("New GameStatus Destroyed");
            return;
        }
        instance = this;
        GameObject.DontDestroyOnLoad(this.gameObject); //Makes the object this script is attached to not unload on new scene. Carries this object to the next scene.
    }
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }
    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }
    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Level Loaded");
        Debug.Log(scene.name);//Displays name of the scene
        Debug.Log("PrevLevel string: " + prevLevel); //Displays what the previous scene was
        GameStatus.GetCurrent().level = scene.name;// sets current level in the instance to the active scene
        IsItemPickedUp(); //Checks to see if items in room have been picked up

        //Depending on what room the game has loaded and the previous level loaded this will place the player in the appropriate area for the correct door
        //Room 1
        if (level == "BioDome")
        {
            if(prevLevel == "MessHall")
            {
                Spawner.Spawn(-36, 1, -10);//Place the player here
            }
        }
        //Room 2
        else if (level == "MessHall")
        {
            if(prevLevel == "BioDome")
            {
                Spawner.Spawn(0, 1, -12);//Place the player here
            }
            else if(prevLevel == "Barracks")
            {
                Spawner.Spawn(-12, 1, 0);//Place the player here
            }
            else if(prevLevel == "Offices")
            {
                Spawner.Spawn(0, 1, 12);//Place the player here
            }
            else if(prevLevel == "ExperimentalTesting")
            {
                Spawner.Spawn(12, 1, 0);//Place the player here
            }
            else if(prevLevel == "ControlRoom")
            {
                Spawner.Spawn(-8, 1, -12);//Place the player here
            }
        }
        //Room 3
        else if( level == "Barracks")
        {
            if(prevLevel == "MessHall")
            {
                Spawner.Spawn(0, 1, -12);//Place the player here
            }
            else if(prevLevel == "Offices")
            {
                Spawner.Spawn(12, 1, 0);//Place the player here
            }
        }
        //Room 4
        else if(level == "Offices")
        {
            if(prevLevel == "MessHall")
            {
                Spawner.Spawn(0, 1, -12);//Place the player here
            }
            else if(prevLevel == "Barracks")
            {
                Spawner.Spawn(-12, 1, 0);//Place the player here
            }
        }
        //Room 5
        else if(level == "ExperimentalTesting")
        {
            if(prevLevel == "MessHall")
            {
                Spawner.Spawn(0, 1, -12);//Place the player here
            }
            else if(prevLevel == "Cargo")
            {
                Spawner.Spawn(0, 1, 0);//Place the player here
            }
        }
        //Room 6
        else if(level == "ControlRoom")
        {
            if(prevLevel == "MessHall")
            {
                Spawner.Spawn(-10, 1, -10);//Place the player here
            }
            else if(prevLevel == "Power")
            {
                Spawner.Spawn(0, 1, 12);//Place the player here
            }
        }
        //Room 7
        else if(level == "Power")
        {
            if(prevLevel == "ControlRoom")
            {
                Spawner.Spawn(0, 1, -12);//Place the player here
            }
            else if(prevLevel == "Cargo")
            {
                Spawner.Spawn(-12, 1, 0);//Place the player here
            }
        }
        //Room 8
        else if(level == "Cargo")
        {
            if(prevLevel == "Power")
            {
                Spawner.Spawn(0, 0, 0);//Place the player here
            }
            else if(prevLevel == "ExperimentalTesting")
            {
                Spawner.Spawn(0, 0, 0);//Place the player here
            }
        }
    }
    //add item to inventory list
    public static void AddInventory(GameObject item)
    {
        inventory.Add(item);
        isPickedUp.Add(item);
        //foreach (GameObject i in inventory) //Displays inventory in debug log
        //{
        //    Debug.Log(i.name);
        //}
        //Debug.Log("------------------");
    }
    //is called when an item is picked up. 
    public static void IsItemPickedUp()//Checks if the item is in the item has been picked up and if it is present in the scene it deactivates it.
    {
        foreach (GameObject item in isPickedUp)
        {
            if(GameObject.Find(item.name) != null)
            {
                item.SetActive(false);
            }
        }
    }
    public static int GetLength()//Returns the length of the inventory list
    {
        return inventory.Count;
    }
}
