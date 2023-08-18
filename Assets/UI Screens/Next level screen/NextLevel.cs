using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public void PlayNext()
    {
        Debug.Log("LoadNextLevel method called.");
       // SceneManager.LoadScene(nextLevelBuildIndex);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
