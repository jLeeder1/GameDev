using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    private Text text;
    private int startTime = 60;

    // Start is called before the first frame update
    void Start()
    {
        Canvas canvas = GetComponentInParent<Canvas>();
        text = canvas.GetComponentInChildren<Text>();
        text.text = startTime.ToString();
    }

    IEnumerator CountDownTimer()
    {
        startTime--;
        yield return new WaitForSeconds(1);
    }
}
