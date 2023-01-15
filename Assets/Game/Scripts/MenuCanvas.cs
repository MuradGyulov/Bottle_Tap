using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using YG;

public class MenuCanvas : MonoBehaviour
{
    [SerializeField] private Sprite spriteMusicON;
    [SerializeField] private Sprite spriteMusicOFF;
    [SerializeField] private Sprite spriteSoundsON;
    [SerializeField] private Sprite spriteSoundsOFF;
    [Space(20)]
    [SerializeField] private Image musicImage;
    [SerializeField] private Image soundsImage;


    private AudioSource musicPlayer;

    private void OnEnable() => YandexGame.GetDataEvent += GetData;
    private void OnDisable() => YandexGame.GetDataEvent -= GetData;

    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("MusicPlayer");
        musicPlayer = player.GetComponent<AudioSource>();
        GetData();
    }

    private void GetData()
    {
        LoadMusicSettings();
        LoadSoundsSettings();
    }

    private void LoadMusicSettings()
    {
        if (YandexGame.savesData.savesMusicSettings)
        {
            musicPlayer.volume = 1;
            musicImage.sprite = spriteMusicON;
        }
        else if(!YandexGame.savesData.savesMusicSettings)
        {
            musicPlayer.volume = 0;
            musicImage.sprite = spriteMusicOFF;
        }
    }

    private void LoadSoundsSettings()
    {
        if (YandexGame.savesData.savesSoundsSettings)
        {
            soundsImage.sprite = spriteSoundsON;
        }
        else if (!YandexGame.savesData.savesSoundsSettings)
        {
            soundsImage.sprite = spriteSoundsOFF;
        }
    }

    public void SetMusicSettings()
    {
        if (YandexGame.savesData.savesMusicSettings)
        {
            musicPlayer.volume = 0;
            musicImage.sprite = spriteMusicOFF;
            YandexGame.savesData.savesMusicSettings = false;
            YandexGame.SaveProgress();
        }
        else if(!YandexGame.savesData.savesMusicSettings)
        {
            musicPlayer.volume = 1;
            musicImage.sprite = spriteMusicON;
            YandexGame.savesData.savesMusicSettings = true;
            YandexGame.SaveProgress();
        }
    }

    public void SetSoundsSettings()
    {
        if (YandexGame.savesData.savesSoundsSettings)
        {
            soundsImage.sprite = spriteSoundsOFF;
            YandexGame.savesData.savesSoundsSettings = false;
            YandexGame.SaveProgress();
        }
        else if (!YandexGame.savesData.savesSoundsSettings)
        {
            soundsImage.sprite = spriteSoundsON;
            YandexGame.savesData.savesSoundsSettings = true;
            YandexGame.SaveProgress();
        }
    }

    public void StartGame()
    {
        int lastCompleteLevel = YandexGame.savesData.savesCompletedLevels;
        SceneManager.LoadScene(lastCompleteLevel);
    }
}