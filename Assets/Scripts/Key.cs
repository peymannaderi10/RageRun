
using UnityEngine;
using UnityEngine.UI;

public class Key : MonoBehaviour
{
    [SerializeField] private Image keybarCurrent;
    [SerializeField] private AudioClip pickupSound;
    public static bool HasKey { get; private set; }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SoundManager.instance.PlaySound(pickupSound);
            keybarCurrent.color = Color.white;
            GetComponent<Collider2D>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;
            HasKey = true;
            
        }
    }

    public void ResetKey()
    {
        HasKey = false;
        keybarCurrent.color = Color.black;
        GetComponent<Collider2D>().enabled = true;
        GetComponent<SpriteRenderer>().enabled = true;

    }

}
