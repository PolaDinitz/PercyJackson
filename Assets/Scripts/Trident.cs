using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trident : MonoBehaviour
{    
    public LevelLoader lvlLoader;

    private void OnTriggerEnter(Collider other)
    {
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();

        if (other.gameObject.CompareTag("Player") && playerInventory.CoinsAmount >= 10)
        {
            lvlLoader.LoadNextLevel();
        }
        else if (playerInventory.CoinsAmount <= 10)
        {
            Debug.Log("You have to collect a least 10 coins");
        }
    }
}
