using UnityEngine;

public class Star : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "BottleCap")
        {
            GameManager.instance.StarsCounter();
        }
    }
}
