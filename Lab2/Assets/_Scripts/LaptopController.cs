using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaptopController : MonoBehaviour
{
    private Text laptopTimeText;

    // Start is called before the first frame update
    void Awake()
    {
        Canvas canvas = GameObject.FindObjectOfType<Canvas>();
        laptopTimeText = canvas.GetComponentInChildren<Text>();
        Debug.Log(laptopTimeText);
    }

    // Update is called once per frame
    void Update()
    {
        laptopTimeText.text = Time.timeSinceLevelLoad.ToString();
    }
}
