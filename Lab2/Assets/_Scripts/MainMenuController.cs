using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void ButtonHandlerPlay()
    {
        StartCoroutine(PlaySoundOnGameStart());
    }

    IEnumerator PlaySoundOnGameStart()
    {
        AudioSource playButtonSound = GetComponent<AudioSource>();
        playButtonSound.Play();

        yield return new WaitForSeconds(2);

        StartCoroutine(LoadYourAsyncScene());
    }

    private IEnumerator LoadYourAsyncScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(1);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
