using System.Collections;
using UnityEngine;

public class Cage : MonoBehaviour
{
    private UIManager uiManager;
    private void Awake()
    {
        uiManager = FindObjectOfType<UIManager>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player" && Key.HasKey)
        {
            GetComponent<Collider2D>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;
            StartCoroutine(WaitAndShowGameOver(1f)); // Wait for 2 seconds before showing game over
        }
    }

    IEnumerator WaitAndShowGameOver(float waitTime)
    {
        yield return new WaitForSeconds(waitTime); // Wait for the specified amount of seconds
        uiManager.WinGame(); // Call the method to show the game over screen
    }
}
