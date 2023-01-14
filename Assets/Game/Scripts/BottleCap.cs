using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class BottleCap : MonoBehaviour
{

    public GameObject starAnimationPrefab;
    public AudioSource pickUpStar;

    private void Start()
    {
        if(YandexGame.savesData.savesSoundsSettings == false)
        {
            pickUpStar.volume = 0f;
        }

        if (YandexGame.savesData.savesSoundsSettings == false)
        {
            pickUpStar.volume = 0f;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Star"))
        {
            Destroy(other.gameObject);
            pickUpStar.Play();
        }

        if (other.gameObject.CompareTag("Destroyer"))
        {
            Destroy(gameObject);
        }
    }
}
