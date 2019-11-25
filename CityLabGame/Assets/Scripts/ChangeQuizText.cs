using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mono.Data.Sqlite;
using System.Data;
using System.Text;

public class ChangeQuizText : MonoBehaviour
{
    public bool answer = false;
    int number;
    private GameObject stall;
    [SerializeField]
    private GameObject quiz;
    private Stall_Script stallScript;

    static Encoding enc32 = Encoding.UTF32;

    // Start is called before the first frame update
    void Start()
    {
        stall = GameObject.FindGameObjectWithTag("Stall");
        string conn = "URI=file:" + Application.dataPath + "/Database.s3db"; //Path to database.
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.
        IDbCommand dbcmd = dbconn.CreateCommand();

        string sqlQueryQuestion = $"SELECT Questions.question_text, Answer_incorrect.answer_text_one, Answer_incorrect.answer_text_two, Answer_correct.answer_text FROM Questions,Answer_incorrect, Answer_correct  WHERE QID = {number} AND IID = {number} AND CID = {number};"; //WHERE QID =" + number; 
        dbcmd.CommandText = sqlQueryQuestion;
        IDataReader reader = dbcmd.ExecuteReader();
            while (reader.Read())
            {

            string question = reader.GetString(0);
            byte[] questionByte = enc32.GetBytes(question);
            question = Encoding.UTF32.GetString(questionByte);


            string inccorect_one = reader.GetString(1);
            string inccorect_two = reader.GetString(2);
            string correct = reader.GetString(3);

            Debug.Log(question);

                Text quizText = GameObject.Find("Canvas/Panel/Quiz Spørgsmål").GetComponent<Text>();
                quizText.text = question;
            Text answerText1 = GameObject.Find("Canvas/Panel/Svar 1/Text").GetComponent<Text>();
            answerText1.text = correct;
            Button answer1 = GameObject.Find("Canvas/Panel/Svar 1").GetComponent<Button>();
            answer1.onClick.AddListener(Answer1OnClick);
            Text answerText2 = GameObject.Find("Canvas/Panel/Svar 2/Text").GetComponent<Text>();
            answerText2.text = inccorect_one;
            Button answer2 = GameObject.Find("Canvas/Panel/Svar 2").GetComponent<Button>();
            answer2.onClick.AddListener(Answer2OnClick);
            Text answerText3 = GameObject.Find("Canvas/Panel/Svar 3/Text").GetComponent<Text>();
            answerText3.text = inccorect_two;
            Button answer3 = GameObject.Find("Canvas/Panel/Svar 3").GetComponent<Button>();
            answer3.onClick.AddListener(Answer3OnClick);


        }
    }

    public void Answer1OnClick()
    {
        answer = true;
        Debug.Log("you answer is " + answer);
        StartCoroutine(CD());
    }
    public void Answer2OnClick()
    {
        answer = false;
        Debug.Log("You answer is " + answer);
    }
    public void Answer3OnClick()
    {
        answer = false;
        Debug.Log("You answer is " + answer);
    }

    //Update is called once per frame
    void Update()
    {
        if (answer == true)
        {
            quiz.SetActive(false);
            StartCoroutine(CD());
        }
        stallScript = stall.gameObject.GetComponent<Stall_Script>();

        if (stallScript != null && quiz.activeSelf == true)
        {
            number = stallScript.number;
        }
    }

    IEnumerator CD()
    {
        yield return new WaitForSeconds(15f);
        answer = false;
    }
}
