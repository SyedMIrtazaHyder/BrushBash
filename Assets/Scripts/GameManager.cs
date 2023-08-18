using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool gameHasEnded = false;
    //public GameObject CompleteLevelUI;
    private static int currentScene = 1;
    public void EndGame()
    {
        //Debug.Log("Game Over");
        if (gameHasEnded == false)
        {
            SceneManager.LoadScene("END GAME"); //name of the scene to load

        }
    }

    public void LevelComplete()
    {
        SceneManager.LoadScene("Next Level");
    }
    public void Restart()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene("Restart"); //name of the scene to load
    }

    public void LoadNextLevel()
    {
        currentScene += 1;
        SceneManager.LoadScene(currentScene%11);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(currentScene);
    }

}