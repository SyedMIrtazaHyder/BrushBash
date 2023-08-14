using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    //public GameObject CompleteLevelUI;
    public static int tempIndex;
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
        //CompleteLevelUI.SetActive(true);
    }
    public void Restart()
    {
        tempIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene("Restart"); //name of the scene to load
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex + 1)%3);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(tempIndex);
    }

}