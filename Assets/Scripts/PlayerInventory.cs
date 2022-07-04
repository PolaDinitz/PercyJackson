using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
    public int CoinsAmount { get; private set; }
    public int currentHealth { get; private set; }

    private void Awake()
    {
        CoinsAmount = 0;
        currentHealth = 100;
    }

    public UnityEvent<PlayerInventory> OnCoinCollected;
    public UnityEvent<PlayerInventory> OnHealthPotionCollected;

    public void CoinCollected()
    {
        CoinsAmount++;
        OnCoinCollected.Invoke(this);
    }
  
    public void HealthPotionCollected()
    {
        currentHealth += 10;
        OnHealthPotionCollected.Invoke(this);
    }
}
