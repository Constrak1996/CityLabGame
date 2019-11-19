using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mono.Data.Sqlite;
using System.Data;

public class ChangeQuizText : MonoBehaviour
{
    bool answer = false;
    [SerializeField]
    int number;

    // Start is called before the first frame update
    void Start()
    {
        string conn = "URI=file:" + Application.dataPath + "/Database.s3db"; //Path to database.
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.
        IDbCommand dbcmd = dbconn.CreateCommand();
        
            string sqlQuery = "SELECT * " + "FROM questions";  //linjen til hvilken data vi vil tilgå fra hvor
            dbcmd.CommandText = sqlQuery;
            IDataReader reader = dbcmd.ExecuteReader();
            while (reader.Read())
            {
                int ID = reader.GetInt32(0);
                string question_text = reader.GetString(1);
                int anwser_correct = reader.GetInt32(2);
                int anwser_incorrect = reader.GetInt32(3);

                Debug.Log("ID =" + ID + "Question =" + question_text + "correct =" + anwser_correct + "incorrect = " + anwser_incorrect);

                Text quizText = GameObject.Find("Canvas/Quiz Spørgsmål").GetComponent<Text>();
                quizText.text = question_text;
              Text answerText1 = GameObject.Find("Canvas/Svar 1/Text").GetComponent<Text>();
              answerText1.text = "";
              Button answer1 = GameObject.Find("Canvas/Svar 1").GetComponent<Button>();
                 answer1.onClick.AddListener(Answer1OnClick);
               Text answerText2 = GameObject.Find("Canvas/Svar 2/Text").GetComponent<Text>();
                answerText2.text = "";
                Button answer2 = GameObject.Find("Canvas/Svar 2").GetComponent<Button>();
                answer2.onClick.AddListener(Answer2OnClick);
              Text answerText3 = GameObject.Find("Canvas/Svar 3/Text").GetComponent<Text>();
              answerText3.text = "";
                    Button answer3 = GameObject.Find("Canvas/Svar 3").GetComponent<Button>();
                answer3.onClick.AddListener(Answer3OnClick);
            }
        
       
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
