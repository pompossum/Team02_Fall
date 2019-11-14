using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CountdownTimer : MonoBehaviour
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
    //public IEnumerator StartCountdown(float countdownValue = 10)
    //{
    //    currCountdownValue = countdownValue;
    //    while (currCountdownValue > 0)
    //    {
    //        Debug.Log("Countdown: " + currCountdownValue);
    //        yield return new WaitForSeconds(1.0f);
    //        currCountdownValue--;
    //    }

    //    if (currCountdownValue == 0)
    //    {
    //        SceneManager.LoadScene(LevelToLoad);
    //    }
    //}
}
