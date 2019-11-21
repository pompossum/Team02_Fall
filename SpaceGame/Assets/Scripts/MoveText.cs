using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveText : MonoBehaviour
{
    public string LevelToLoad;
    //float currCountdownValue;

    void Start()
    {
        GameObject.Find("Text");
    }
    void Update()
    {
        transform.Translate(new Vector3(0.0f, 45f, 0.0f) * Time.deltaTime * 1f);

        if (Input.GetKeyDown("space"))
        {
            SceneManager.LoadScene(LevelToLoad);
        }
    }
}
