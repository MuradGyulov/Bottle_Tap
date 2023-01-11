using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;


    [SerializeField] private Animator fadeAnimator;
    [SerializeField] private GameObject fadePanel;


    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        
    }

    public void DisableFadePanel()
    {
        fadePanel.SetActive(false);
    }

    public void EnableFadePanel()
    {
        fadePanel.SetActive(true);
        fadeAnimator.SetBool("FadePanelDisapperance", true);
    }


    public void RestartLevel()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneIndex);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
