using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Required For Raw Image
using UnityEngine.UI;

// Required For Scene Change
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

    public float nextX;
    public float nextY;
    public float nextZ;

    public bool setSpawn;

    //booleans to check if main objectives are comple
    public bool power = false;
    public bool oxy = false;
    public bool food = false;
    public bool sos = false;
    public bool signal = false;

    // SOS Reqs
    public bool secOverwritten;
    public bool sosPlacement;

    // Signal Reqs
    public bool table;
    public bool signaled;

    // Power Reqs
    public bool cell1;
    public bool cell2;
    public bool cell3;
    public bool leakFixed;

    // Oxygen Reqs
    public bool hullFix;
    public bool lifeSupportFix;

    // Public Declaration For List
    public string[,] itemList;
    public int objectsInList;

    public static List<GameObject> inventory = new List<GameObject>(); //List of inventory items
    public static List<GameObject> isPickedUp = new List<GameObject>(); //Creates a list of all items picked up

    private static GameStatus instance;
    public string timeStampCreate;
    public int timeStamp;

    public static GameStatus GetCurrent()
    {
        return instance; //Returns the current instance
    }
    void Awake()
    {
        timeStampCreate = System.DateTime.Now.Hour.ToString() + System.DateTime.Now.Minute.ToString() + System.DateTime.Now.Second.ToString() + System.DateTime.Now.Millisecond.ToString();
        timeStamp = System.Convert.ToInt32(timeStampCreate);
        //Singleton. There can only be one! If one already exists then destroy this one.
        if (instance != null && timeStamp > instance.timeStamp)
        {
            Destroy(this.gameObject);
            Debug.Log("New GameStatus Destroyed");
            return;
        }
        instance = this;
        GameObject.DontDestroyOnLoad(this.gameObject); //Makes the object this script is attached to not unload on new scene. Carries this object to the next scene.
    }

    void Start()
    {
        // Declarations
        int countItems = 0;
        string readLine;
        string path = Application.dataPath + "/Resources/itemReqList.ini";// Location Of Ini File
        System.IO.StreamReader listCompiler;

        // Checks Amount Of Lines(Items)
        // Also has 1000 item limit in case of error unity won't freeze
        listCompiler = new System.IO.StreamReader(path);
        while ((readLine = listCompiler.ReadLine()) != null && countItems < 1000)
        {
            countItems++;
        }
        Debug.Log(countItems);

        // Total Objects Count
        objectsInList = countItems;

        // Define Array Size
        itemList = new string[countItems, 5];

        // Reset Count Var And StreamReader
        countItems = 0;
        listCompiler.Close();
        listCompiler = new System.IO.StreamReader(path);

        // Populate Array
        while ((readLine = listCompiler.ReadLine()) != null && countItems < 1000)
        {
            // Set Indexes
            int first = readLine.IndexOf('!');
            int second = readLine.IndexOf('@');
            int third = readLine.IndexOf('#');
            int last = readLine.IndexOf('$');

            // Set [x, 0]
            // Interactive Name
            string intName = readLine.Substring(0, first);
            itemList[countItems, 0] = intName;

            // Set [x,1]
            // Required Scene(Room) Name
            string sceneName = readLine.Substring(first + 1, second - first - 1);
            itemList[countItems, 1] = sceneName;

            // Set [x,2]
            // Item Required To Complete Puzzle
            string reqItem = readLine.Substring(second + 1, third - second - 1);
            itemList[countItems, 2] = reqItem;

            // Set [x,3]
            // Function Called To Complete Puzzle
            string funcCall = readLine.Substring(third + 1, last - third - 1);
            itemList[countItems, 3] = funcCall;

            // Set [x,4]
            // Remove Item After This Use
            string itemRemove = readLine.Substring(last + 1);
            itemList[countItems, 4] = itemRemove;

            countItems++;
        }
        listCompiler.Close();
    }

    // Sets Main Conditions To True
    // If Conditions Are Met
    void Update()
    {
        // Oxygen
        if (oxy == false && hullFix == true && lifeSupportFix == true)
        {
            GetComponent<Countdown>().enabled = false;
            oxy = true;
        }

        // Signal
        if (signal == false && table == true && signaled == true)
        {
            signal = true;
        }

        // Sos
        if (sos == false && sosPlacement == true && secOverwritten == true)
        {
            sos = true;
        }

        // Power
        if (power == false && cell1 == true && cell2 == true && cell3 == true && leakFixed == true)
        {
            power = true;
        }

        if (power == true && sos == true && signal == true && oxy == true && food == true)
        {
        Destroy(gameObject);
        SceneManager.LoadScene("WinScene");
        }
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
        //IsItemPickedUp(); //Checks to see if items in room have been picked up

        //Depending on what room the game has loaded and the previous level loaded this will place the player in the appropriate area for the correct door
        //Puzzle.Check();
        IsItemPickedUp(); //Checks to see if items in room have been picked up
        if (setSpawn)
        {
            Spawner.Spawn(nextX, nextY, nextZ);
            setSpawn = false;
        }
    }
    //add item to inventory list
    public static void AddInventory(GameObject item)
    {
        inventory.Add(item);
        isPickedUp.Add(item);

        // Debug
        //foreach (GameObject i in inventory) //Displays inventory in debug log
        //{
        //    Debug.Log(i.name);
        //}
        //Debug.Log("------------------");
        DontDestroyOnLoad(item.gameObject);
        item.gameObject.SetActive(false);
    }

    // Justin Bittner 11/25/19 2329
    // Func Called To Figure Out
    // Called After Pick Up To Establish Texture Ontop Of Inventory UI By Scanning Inventor For The Item And Checking The Slot
    private static int GetSlot(GameObject obj)
    {
        // Sets Counter
        int slot = 1;

        // Scans Through List
        foreach (GameObject item in inventory)
        {
            
            // Checks For Slot
            if (item == obj)
            {
                return slot;
            }

            // Counts
            slot += 1;

        }

        // Error
        return -1;
    }
    //is called when an item is picked up. 
    public static void IsItemPickedUp()//Checks if the item is in the item has been picked up and if it is present in the scene it deactivates it.
    {
        //foreach (GameObject item in isPickedUp)
        //{
        //    Destroy(item);
        //    Debug.Log("Destroyed");
        //}
        for (int i = 0; i < isPickedUp.Count; i++)
        {
            string searchFor = isPickedUp[i].gameObject.name;
            GameObject destroy = GameObject.Find(searchFor);
            if (destroy != null)
            {
                Destroy(destroy);
            }
        }
    }
    public static int GetLength()//Returns the length of the inventory list
    {
        return inventory.Count;
    }



    public bool Puzzles(string name, string item1, string item2, string item3)
    {
        foreach (GameObject i in inventory)
        {
            if (i.name == item1)
            {
                foreach (GameObject j in inventory)
                {
                    if (j.name == item2)
                    {
                        foreach (GameObject k in inventory)
                        {
                            if (k.name == item3)
                            {
                                inventory.Remove(i);
                                inventory.Remove(j);
                                inventory.Remove(k);
                                return true;
                            }
                        }

                    }
                }
            }
        }
        return false;
    }

    public bool Puzzles(string name, string item1, string item2)
    {
        foreach (GameObject i in inventory)
        {
            if (i.name == item1)
            {
                foreach (GameObject j in inventory)
                {
                    if (j.name == item2)
                    {
                        inventory.Remove(i);
                        inventory.Remove(j);
                        return true;

                    }
                }
            }
        }
        return false;
    }
    public bool Puzzles(string name, string item)
    {
        foreach (GameObject i in inventory)
        {
            if (i.name == item)
            {
                inventory.Remove(i);
                return true;
            }
        }
        return false;
    }








}
