using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameCanvas : MonoBehaviour
{
    [SerializeField] private Text LevelIndexIndicator;

    private void Start()
    {
        DisplaySceneIndex();
    }

    public void BackToHome()
    {
        SceneManager.LoadScene(0);
    }

    public void RestartLevel()
    {
        int levelIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(levelIndex);
    }

    private void DisplaySceneIndex()
    {
       // int levelIndex = SceneManager.GetActiveScene().buildIndex;
       // LevelIndexIndicator.text = "Level " + levelIndex.ToString();
    }
}