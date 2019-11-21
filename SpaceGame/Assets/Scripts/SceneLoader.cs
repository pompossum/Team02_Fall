using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Jeff Wakeman
// 10/17/19 Created
//Script is used in Main menu scene
//Attached to Button prefab
//Changes Main Menu scene to game scenes
public class SceneLoader : MonoBehaviour
{
    //Switches scene from button press
   public void SceneSwitch(string theScene)
    {
        SceneManager.LoadScene(theScene);
    }

    public void doExitGame()
    {
        Debug.Log("Game has been closed.");
        Application.Quit();
    }
}
