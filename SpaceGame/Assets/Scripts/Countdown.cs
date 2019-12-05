using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Countdown : MonoBehaviour
{
    [SerializeField] private Text uiText;
    [SerializeField] private float mainTimer;

    private float timer;
    private bool canCount = true;
    private bool doOnce = false;
    private static Countdown TimerInstance;
    public string timeStampCreate;
    public int timeStamp;

    public static Countdown GetCurrent()
    {
        return TimerInstance; //Returns the current instance
    }
    void Awake()
    {
        timeStampCreate = System.DateTime.Now.Hour.ToString() + System.DateTime.Now.Minute.ToString();
        timeStamp = System.Convert.ToInt32(timeStampCreate);
        //only one timer instance will exist at a time
        if (TimerInstance != null && timeStamp > TimerInstance.timeStamp)
        {
            Destroy(this.gameObject);
            Debug.Log("New Timer Destroyed");
            return;
        }
        TimerInstance = this;
        GameObject.DontDestroyOnLoad(this.gameObject); //Makes the object this script is attached to not unload on new scene. Carries this object to the next scene.
    }

    void Start()
    {
        timer = mainTimer;
    }

    void Update()
    {
        if (timer >= 0.0f && canCount)
        {
            timer -= Time.deltaTime;
            uiText.text = timer.ToString("F");
        }

        else if (timer <= 0.0f && doOnce)
        {
            canCount = false;
            doOnce = true;
            uiText.text = "0.00";
            timer = 0.0f;
        }

        else if (timer <= 0.0f)
        {
            Destroy(gameObject);
			Debug.Log("Countdown Update()");
            SceneManager.LoadScene("GameOver");
        }
    }
}
