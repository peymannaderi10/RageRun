
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private GameObject winScreen;
    [SerializeField] private AudioClip win;
    [SerializeField] private AudioClip gameover;


    private void Awake()
    {
        gameOverScreen.SetActive(false);
        winScreen.SetActive(false);
    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
        SoundManager.instance.PlaySound(gameover);


    }
    public void WinGame()
    {
        winScreen.SetActive(true);
        SoundManager.instance.PlaySound(win);


    }
    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
    public void Quit()
    {
        Application.Quit();
    }

}
