using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeQuizText : MonoBehaviour
{
    bool answer = false;

    // Start is called before the first frame update
    void Start()
    {
        Text quizText = GameObject.Find("Canvas/Quiz Spørgsmål").GetComponent<Text>();
        quizText.text = "Is it cold outside, this time of the year?";
        Text answerText1 = GameObject.Find("Canvas/Svar 1/Text").GetComponent<Text>();
        answerText1.text = "Yes";
        Button answer1 = GameObject.Find("Canvas/Svar 1").GetComponent<Button>();
        answer1.onClick.AddListener(Answer1OnClick);
        Text answerText2 = GameObject.Find("Canvas/Svar 2/Text").GetComponent<Text>();
        answerText2.text = "No";
        Button answer2 = GameObject.Find("Canvas/Svar 2").GetComponent<Button>();
        answer2.onClick.AddListener(Answer2OnClick);
        Text answerText3 = GameObject.Find("Canvas/Svar 3/Text").GetComponent<Text>();
        answerText3.text = "Who knows?";
        Button answer3 = GameObject.Find("Canvas/Svar 3").GetComponent<Button>();
        answer3.onClick.AddListener(Answer3OnClick);
    }

    void Answer1OnClick()
    {
        answer = true;
        Debug.Log("you answer is " + answer);
    }
    void Answer2OnClick()
    {
        answer = false;
        Debug.Log("You answer is " + answer);
    }
    void Answer3OnClick()
    {
        answer = false;
        Debug.Log("You answer is " + answer);
    }

    //Update is called once per frame
    void Update()
    {
        
    }
}
