using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    private Text text;
    private int startTime = 60;
    private GameObject firstPersonController;
    private Canvas canvas;
    private Image image;
    private float percentageChangeAmount;

    // Start is called before the first frame update
    void Start()
    {
        canvas = GetComponentInParent<Canvas>();
        text = canvas.GetComponentInChildren<Text>();
        firstPersonController = GameObject.Find("FPSController");
        //text.text = startTime.ToString();
        image = GetComponent("Image") as Image;
        CalculatePercentageChange();
        StartCoroutine(CountDownTimerImage());
    }

    IEnumerator CountDownTimerText()
    {
        while(startTime > 0)
        {
            startTime--;
            yield return new WaitForSeconds(1);
            text.text = startTime.ToString();
        }

        StartCoroutine(LoadYourAsyncMenu());
    }

    IEnumerator CountDownTimerImage()
    {
        while (startTime > 0)
        {
            startTime--;
            yield return new WaitForSeconds(1);
            image.fillAmount -= percentageChangeAmount;
        }

        StartCoroutine(LoadYourAsyncMenu());
    }

    private IEnumerator LoadYourAsyncMenu()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(0);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    private void CalculatePercentageChange()
    {
        percentageChangeAmount = 1f / startTime;
    }

    private void Update()
    {
        //text.transform.position = new Vector3(firstPersonController.transform.position.x, firstPersonController.transform.position.y, firstPersonController.transform.position.z);
    }
}
