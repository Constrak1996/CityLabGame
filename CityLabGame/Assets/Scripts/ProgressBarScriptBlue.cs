using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarScriptBlue : MonoBehaviour
{
    public Slider slider;
    public Text blue;

    private float fillSpeed = 0.2f;
    private float targetProgress = 0;

    private int gridAmount = 4522;

    public float SliderValue { get; private set; }

    public void Awake()
    {
        slider = gameObject.GetComponent<Slider>();
    }

    void Start()
    {
        //IncrementProgressBar(0.75f);
    }

    // Update is called once per frame
    void Update()
    {
        SliderValue = PlayerGridCollision.blueScore / 45.22f;
        slider.value = SliderValue / 100;
        blue.text = "" + slider.value + "%";
    }

    //public void IncrementProgressBar(float newProgress)
    //{
    //    targetProgress = slider.value + newProgress;
    //}
}
