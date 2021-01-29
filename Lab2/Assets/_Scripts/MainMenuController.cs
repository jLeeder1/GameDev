using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void ButtonHandlerPlay()
    {
        StartCoroutine(LoadYourAsyncScene());
        Debug.Log("Button method called");
    }

    private IEnumerator LoadYourAsyncScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(1);

        Debug.Log("Load method called");

        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        Debug.Log("Button method finished");
    }
}
