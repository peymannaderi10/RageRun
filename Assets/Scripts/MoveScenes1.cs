using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveScenes1 : MonoBehaviour
{
    public int sceneBuildIndex;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
        }
    }
}
