using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();

        if (playerInventory != null && other.gameObject.CompareTag("Player"))
        {
            playerInventory.CoinCollected();
            gameObject.SetActive(false);
        }
    }
}
