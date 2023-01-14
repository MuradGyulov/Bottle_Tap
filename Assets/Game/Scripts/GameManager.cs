using UnityEngine;
using UnityEngine.SceneManagement;
using YG;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private int collectStars;

    private Animator fadeAnimator;
    private int starsCounter = 0;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        GameObject fadePanel = GameObject.FindGameObjectWithTag("FadePanel");
        fadeAnimator= fadePanel.GetComponent<Animator>();

        if(YandexGame.savesData.savesCompletedLevels < 102)
        {
            YandexGame.savesData.savesCompletedLevels = SceneManager.GetActiveScene().buildIndex;
            YandexGame.SaveProgress();
        }
    }

    public void StarsCounter()
    {
        starsCounter++;

        if(starsCounter == collectStars)
        {
            Invoke("FadePanel", 3.5f);
            Invoke("LoadNextlevel", 4f);
        }
    }

    public void FadePanel()
    {
        fadeAnimator.SetBool("FadePanelDisapperance", true);
    }

    public void LoadNextlevel()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneIndex + 1);
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
