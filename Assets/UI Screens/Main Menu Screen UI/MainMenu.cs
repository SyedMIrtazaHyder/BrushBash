using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private RawImage animPlay;
    [SerializeField] private VideoPlayer playAnim;
    private void Start()
    {
        playAnim.Play();
        StartCoroutine(PauseAnim());
    }
    public void Play()
    {
        playAnim.Play();
        animPlay.enabled = true;
        StartCoroutine(WaitForAnim());
    }

    private IEnumerator PauseAnim()
    {
        yield return new WaitForSeconds(4f);
        playAnim.Pause();
        animPlay.enabled = false;
    }

    private IEnumerator WaitForAnim()
    {
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
