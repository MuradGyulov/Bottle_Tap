using UnityEngine;
using YG;

public class GameCanvas : MonoBehaviour
{
    public void BackToHome() => GameManager.instance.LoadMainMenu();
    public void RestartLevel() => GameManager.instance.RestartLevel();
    public void ResetProgress()
    {
        YandexGame.savesData.savesCompletedLevels = 1;
        YandexGame.SaveProgress();
    }
}