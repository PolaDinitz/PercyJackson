using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temple : MonoBehaviour
{
    public LevelLoader lvlLoader;

    private void OnTriggerEnter(Collider other)
    {
        Inventory inventory = other.GetComponent<Inventory>();

        if (other.gameObject.CompareTag("Player") && inventory.Amount() <=4)
        {
            lvlLoader.LoadNextLevel();
        }
        else
        {
            Debug.Log("You have to collect all items");
        }
    }

}
