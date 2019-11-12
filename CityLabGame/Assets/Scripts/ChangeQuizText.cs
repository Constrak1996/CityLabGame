using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeQuizText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Text quizText = GameObject.Find("Canvas/Quiz Spørgsmål").GetComponent<Text>();
        quizText.text = "Does this work";
        Text answerText1 = GameObject.Find("Canvas/Svar 1/Text").GetComponent<Text>();
        answerText1.text = "Yes";
        Text answerText2 = GameObject.Find("Canvas/Svar 2/Text").GetComponent<Text>();
        answerText2.text = "No";
        Text answerText3 = GameObject.Find("Canvas/Svar 3/Text").GetComponent<Text>();
        answerText3.text = "Who knows?";
    }

    //Update is called once per frame
    void Update()
    {
        
    }
}
