using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stall_Script : MonoBehaviour
{
    private GameObject quizPanel;
    private GameObject[] childForCanvas;
    private ChangeQuizText quizScript;
    private GameObject quiz;
    public bool redActivated = true;
    public bool blueActivated = false;
    private bool quizIsDown;

    // Start is called before the first frame update
    void Start()
    {
<<<<<<< HEAD
        quizPanel = GameObject.Find("Panel");
        quizPanel.SetActive(false);
=======
        quizPanel = GameObject.Find("Canvas/Panel");
>>>>>>> 7fcdaec0b20db253d2c10315b412f01362ca91d4
        quiz = GameObject.FindGameObjectWithTag("Quiz");
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "BluePlayer"|| other.gameObject.tag == "RedPlayer")
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
