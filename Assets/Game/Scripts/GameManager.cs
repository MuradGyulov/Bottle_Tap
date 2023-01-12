using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private int collectStars;
    [SerializeField] private Animator fadeAnimator;

    private int starsCounter = 0;

    private void Awake()
    {
        instance = this;
    }

    public void StarsCounter()
    {
        starsCounter++;

        if(starsCounter == collectStars)
        {
            Invoke("FadePanel", 3.5f);
            Invoke("LoadNextlevel", 4.5f);
        }
    }

    public void FadePanel()
    {
        fadeAnimator.SetBool("FadePanelDisapperance", true);
    }

    public void LoadNextlevel()
    {
        SceneManager.LoadScene(2);
    }
}
