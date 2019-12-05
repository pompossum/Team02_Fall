using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class renameSlot : MonoBehaviour
{
    public int slot;
    public int slotIndex;
    public string holding;
    GameObject labelChange;
    void Start()
    {
        slot = System.Convert.ToInt32(gameObject.transform.parent.name.Substring(3));
        labelChange = gameObject.transform.GetChild(0).gameObject;
        gameObject.name = "InvSprite" + slot;
        slotIndex = slot;
        slotIndex--;
    }

    private void Update()
    {
        Texture newTexture;
        string itemIconPath;
        string changeTo = "";
        holding = "default";
        if (GameStatus.inventory.Count >= slot)
        {
            if (GameStatus.inventory[slotIndex] != null)
            {
                holding = GameStatus.inventory[slotIndex].name;
                changeTo = holding;
            }
            // Justin Bittner 11/25/19 1506
            // Add Sprite To Inventory

            // Prevents Error From Being Thrown
            // Checks If Sprite Exists Before Applying It As
            // The Item's Icon In The Inventory HUD
            // -- Justin
        }
        labelChange.GetComponent<Text>().text = changeTo;
        itemIconPath = "hudSprites/" + holding;
        newTexture = Resources.Load<Texture2D>(itemIconPath);
        transform.GetComponent<RawImage>().texture = newTexture;
    }
}
