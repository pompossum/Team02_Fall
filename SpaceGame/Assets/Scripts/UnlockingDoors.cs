using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockingDoors : MonoBehaviour
{
    public void UnlockDoor()
    {
        gameObject.AddComponent<DontDestroyThisPls>();
        GameStatus.isPickedUp.Add(gameObject);
        gameObject.SetActive(false);
		Debug.Log("UnlockDoor()");
    }

    public void UnlockSpace()
    {
        gameObject.AddComponent<DontDestroyThisPls>();
        GameStatus.isPickedUp.Add(gameObject);
        gameObject.SetActive(false);
        Debug.Log("UnlockSpace()");
    }

    public void UnlockCaptainOffice()
    {
        gameObject.AddComponent<DontDestroyThisPls>();
        GameStatus.isPickedUp.Add(gameObject);
        gameObject.SetActive(false);
        Debug.Log("UnlockCaptainOffice()");
    }
}
