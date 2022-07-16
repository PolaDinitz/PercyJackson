using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public LevelLoader lvlLoader;

    private void Awake()
    {
        SetMaxHealth();
    }

    public void SetMaxHealth()
    {
        slider.maxValue = 100f;
        slider.value = 100f;

        fill.color = gradient.Evaluate(1f);
    }

    public void updateHealthBar(PlayerInventory playerInventory)
    {
        if (playerInventory.currentHealth == 0)
        {
            lvlLoader.GameOver();
        }

        slider.value = playerInventory.currentHealth;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
