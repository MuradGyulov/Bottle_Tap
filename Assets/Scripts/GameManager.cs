using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int starsCollect;
    public int totalStart = 3;
    public int bottleCapsDestroied;
    public int totalBottleCaps;

    public Animator fader;
    public GameObject tutorialPanel;
    public GameObject gameOverPanel;
    public GameObject winPanel;



    int levelNo;

    private void Awake()
    {
        instance = this;
    }


    private void Update()
    {
        if(starsCollect == totalStart)
        {            
            StartCoroutine(FadeOut());
            StartCoroutine(WinPanelOn());
        }
        
        //if(bottleCapsDestroied == totalBottleCaps && starsCollect > 3)
        //{
        //    StartCoroutine(FadeOut());
        //    StartCoroutine(GameOverPanelOn());
        //}
    }


    private void Start()
    {

        levelNo = SceneManager.GetActiveScene().buildIndex;

        if (SceneManager.GetActiveScene().name == "1")
        {
            StartCoroutine(TutorialPanelOn());
        }

        if (SceneManager.GetActiveScene().name == "11")
        {
            StartCoroutine(TutorialPanelOn());
        }

    }


    //------------------------- Buttons only -------------------------//

    public void VertFirstStartButton()
    {
        int level = PlayerPrefs.GetInt("LevelCount", 1);
        SceneManager.LoadScene(level);
    }

    public void TutorialPanelOffButton()
    {
        tutorialPanel.SetActive(false);
    }

    public void Retry()
    {
        AdManager.instance.ShowAd();
        SceneManager.LoadScene(levelNo);
    }

    public void NextLevel()
    {
        if (levelNo % 5 == 0)
        {
            AdManager.instance.ShowAd();
        }
        levelNo++;
        PlayerPrefs.SetInt("LevelCount", levelNo);
        SceneManager.LoadScene(levelNo);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }
    //------------------------- Buttons only -------------------------//

    public void Privacypolicy()
    {
        Application.OpenURL("https://hypercausualgamesfree.s3.ap-south-1.amazonaws.com/hypercausualgames/Satisfying.txt");
    }

    //------------------------- Wait Here -------------------------//

    IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(2.5f);
        fader.SetBool("FadeAway", true);
    }

    IEnumerator TutorialPanelOn()
    {
        yield return new WaitForSeconds(1f);
        tutorialPanel.SetActive(true);
    }

    IEnumerator GameOverPanelOn()
    {
        yield return new WaitForSeconds(2.6f);
        gameOverPanel.SetActive(true);

    }

    IEnumerator WinPanelOn()
    {
        yield return new WaitForSeconds(3.6f);
        winPanel.SetActive(true);
    }
    //------------------------- Wait Here -------------------------//
}
