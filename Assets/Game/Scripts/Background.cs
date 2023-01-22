using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] Sprite background_1;
    [SerializeField] Sprite background_2;
    [SerializeField] Sprite background_3;
    [SerializeField] Sprite background_4;

    private void Start()
    {
        int randomNumber = Random.Range(1, 5);
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        switch(randomNumber)
        {
            case 1:
                spriteRenderer.sprite = background_1;
                break;
                case 2:
                spriteRenderer.sprite = background_2;
                break;
                case 3:
                spriteRenderer.sprite = background_3;
                break;
                case 4:
                spriteRenderer.sprite = background_4;
                break;
        }
    }
}
