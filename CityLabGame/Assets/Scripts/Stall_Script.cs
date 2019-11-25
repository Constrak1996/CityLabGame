using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stall_Script : MonoBehaviour
{
    [SerializeField]
    private GameObject quizPanel;
    private ChangeQuizText quizScript;
    private GameObject quiz;
    public bool redActivated = true;
    public bool blueActivated = false;
    private bool quizIsDown;
    public int number;

    // Start is called before the first frame update
    void Start()
    {
        quiz = GameObject.FindGameObjectWithTag("Quiz");
    }

    // Update is called once per frame
    void Update()
    {
        quizScript = quiz.gameObject.GetComponent<ChangeQuizText>();
        if (quizScript != null)
        {
            quizIsDown = quizScript.answer;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "BluePlayer" && quizIsDown == false || other.gameObject.tag == "RedPlayer" && quizIsDown == false)
        {
            QuizPOPUp();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "BluePlayer" || other.gameObject.tag == "RedPlayer")
        {
            QuizClose();
        }
    }

    public void QuizClose()
    {
        quizPanel.SetActive(false);
    }
    public void QuizPOPUp()
    {
        quizPanel.SetActive(true);
    }
}
