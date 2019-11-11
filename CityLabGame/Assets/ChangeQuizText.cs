using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeQuizText : MonoBehaviour
{
    string toChange = null;

    // Start is called before the first frame update
    void Start()
    {
        Text quizText = GameObject.Find("Canvas/Quiz Spørgsmål").GetComponent<Text>();
        quizText.text = "Does this work";
    }

    //Update is called once per frame
    void Update()
    {
        
    }
}
