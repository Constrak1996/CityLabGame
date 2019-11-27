using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coloring_Script : MonoBehaviour
{
    public ChangeQuizText quizText;
    private GameObject quizPanel;
    public bool BlueActivated;
    public bool RedActivated;
    [SerializeField]
    private bool isBlue;
    [SerializeField]
    private bool isRed;
    [SerializeField]
    private bool isReady = true;
    // Start is called before the first frame update
    void Start()
    {
        quizPanel = GameObject.FindGameObjectWithTag("QuizPanel");
    }

    // Update is called once per frame
    void Update()
    {
        quizText = quizPanel.gameObject.GetComponent<ChangeQuizText>();
        if (isBlue == true && isReady == true)
        {
            BlueActivated = quizText.answer;
        }
        if (isRed == true && isReady == true)
        {
            RedActivated = quizText.answer;
        }

        if (RedActivated == true)
        {
            StartCoroutine(StanderCD());
            isReady = false;
        }

        if (BlueActivated == true)
        {
            StartCoroutine(StanderCD());
            isReady = false;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "RedPlayer")
        {
            isRed = true;
        }

        if (other.gameObject.tag == "BluePlayer")
        {
            isBlue = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "RedPlayer")
        {
            isRed = true;
        }

        if (other.gameObject.tag == "BluePlayer")
        {
            isBlue = true;
        }
    }


    private IEnumerator StanderCD()
    {
        yield return new WaitForSeconds(15f);
        RedActivated = false;
        isRed = false;
        BlueActivated = false;
        isBlue = false;
        isReady = true;
    }
}
