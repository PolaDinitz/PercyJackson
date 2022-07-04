using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public LevelLoader lvlLoader;

    public void PlayGame()
    {
        lvlLoader.LoadNextLevel();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
