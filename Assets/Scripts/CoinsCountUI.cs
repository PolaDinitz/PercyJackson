using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinsCountUI : MonoBehaviour
{
    private TextMeshProUGUI coinText;

    // Start is called before the first frame update
    void Start()
    {
        coinText = GetComponent<TextMeshProUGUI>();    
    }

    public void UpdateCoinText(PlayerInventory playerInventory)
    {
        coinText.text = playerInventory.CoinsAmount.ToString();
    }
}
