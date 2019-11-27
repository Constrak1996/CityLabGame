using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mono.Data.Sqlite;
using System.Data;

public class ChangeQuizText : MonoBehaviour
{
    public bool answer = false;
    int number;
    private GameObject stall;
    private List<string> questionList = new List<string>();
    [SerializeField]
    private GameObject quiz;
    private Text quizText;
    private Text answerText1;
    private Button answer1;
    private Text answerText2;
    private Button answer2;
    private Text answerText3;
    private Button answer3;
    private Stall_Script stallScript;
    private string question;
    private string incorrect_one;
    private string incorrect_two;
    private string correct;
    IDataReader reader;
    string sqlQueryQuestion;
    IDbCommand dbcmd;
    IDbConnection dbconn;

    // Start is called before the first frame update
    void Start()
    {
        number = Random.Range(1, 10);
        stall = GameObject.FindGameObjectWithTag("Stall");
        string conn = "URI=file:" + Application.dataPath + "/Database.s3db"; //Path to database.
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.
        quizText = GameObject.Find("Canvas/Panel/Quiz Spørgsmål").GetComponent<Text>();
        answerText1 = GameObject.Find("Canvas/Panel/Svar 1/Text").GetComponent<Text>();
        answerText2 = GameObject.Find("Canvas/Panel/Svar 2/Text").GetComponent<Text>();
        answerText3 = GameObject.Find("Canvas/Panel/Svar 3/Text").GetComponent<Text>();
        answer1 = GameObject.Find("Canvas/Panel/Svar 1").GetComponent<Button>();
        answer2 = GameObject.Find("Canvas/Panel/Svar 2").GetComponent<Button>();
        answer3 = GameObject.Find("Canvas/Panel/Svar 3").GetComponent<Button>();
    }

    public void Answer1OnClick()
    {
        answer = true;
        Debug.Log("you answer is " + answer);
        number = Random.Range(1, 10);
        StartCoroutine(CD());
        quiz.SetActive(false);
    }
    public void Answer2OnClick()
    {
        answer = false;
        Debug.Log("You answer is " + answer);
        quiz.SetActive(false);
    }
    public void Answer3OnClick()
    {
        answer = false;
        Debug.Log("You answer is " + answer);
        quiz.SetActive(false);
    }

    //Update is called once per frame
    void Update()
    {
        dbcmd = dbconn.CreateCommand();
        sqlQueryQuestion = $"SELECT Questions.question_text, Answer_incorrect.answer_text_one, Answer_incorrect.answer_text_two, Answer_correct.answer_text FROM Questions,Answer_incorrect, Answer_correct  WHERE QID = {number} AND IID = {number} AND CID = {number};"; //WHERE QID =" + number; 
        dbcmd.CommandText = sqlQueryQuestion;
        reader = dbcmd.ExecuteReader();
        while (reader.Read())
        {

            question = reader.GetString(0);
            incorrect_one = reader.GetString(1);
            incorrect_two = reader.GetString(2);
            correct = reader.GetString(3);

            Debug.Log(question + number);

            quizText.text = question;
            
            answerText1.text = correct;
            answer1.onClick.AddListener(Answer1OnClick);
            answerText2.text = incorrect_one;
            answer2.onClick.AddListener(Answer2OnClick);
            answerText3.text = incorrect_two;
            answer3.onClick.AddListener(Answer3OnClick);

            foreach (string question in questionList)
            {
                
            }

            if (questionList.Count == 0)
            {

            }

            //StartCoroutine(CD());
        }
        //if (answer == true)
        //{
        //    quiz.SetActive(false);
        //    //StartCoroutine(CD());
        //}
        stallScript = stall.gameObject.GetComponent<Stall_Script>();

        //if (stallScript != null && quiz.activeSelf == tru)
        //{
        //    number = stallScript.number;
        //}
    }

    IEnumerator CD()
    {
        yield return new WaitForSeconds(15f);
        answer = false;
    }
}
