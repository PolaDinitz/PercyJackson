using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Inventory inventory;

    // init
    void Start()
    {
        inventory.ItemAdded += InventoryScript_ItemAdded;
    }

    private void InventoryScript_ItemAdded(object sender, InventoryEventArgs e)
    {
        Transform inventoryPanel = transform.Find("InventoryPanel");
        
        foreach(Transform slot in inventoryPanel)
        {
            Image img = slot.GetChild(0).GetChild(0).GetComponent<Image>();

            if (!img.enabled)
            {
                Debug.Log("Sprite added to inventory");
                img.enabled = true;
                img.sprite = e.Item.Image;

                break;
            }
        }
    }
}
