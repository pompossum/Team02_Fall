using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    //Switches scene from button press
   public void SceneSwitch(string theScene)
    {
        SceneManager.LoadScene(theScene);
    }
}
