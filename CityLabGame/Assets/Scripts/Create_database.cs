using Mono.Data.Sqlite;
using SQLite4Unity3d;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Create_database : MonoBehaviour
{
    // Start is called before the first frame update
    string conn = "URI=file:" + Application.dataPath + "/Database.s3db"; //Path to database.
    IDbConnection dbconn;
    void Start()
    { 
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.
        CreateQuestion();
        InsertQuestion();
        CreateCorrect();
        InsertCorrect();
        CreateIncorrect();
        InsertIncorrect();
        DBClose();
    }
    public void CreateQuestion()
    {
        string sql = "CREATE TABLE IF NOT EXISTS Questions ( QID INTEGER Primary Key AUTOINCREMENT , question_text VARCHAR(150), answer_correct_ID INTEGER, answer_incorrect_ID_one INTEGER, answer_incorrect_ID_two INTEGER )"; 

        IDbCommand dbcmd = dbconn.CreateCommand();
        dbcmd.CommandText = sql;
        dbcmd.ExecuteNonQuery();
        dbcmd.Dispose();
        dbcmd = null;
    }
    public void InsertQuestion()
    {
        string sql = "INSERT INTO (question_text, answer_correct_ID, answer_incorrect_ID_one, answer_incorrect_ID_two)('Hvad er den største kilde til CO2-udledning i Aarhus Kommune?','1','1','1')";
        IDbCommand dbcmd = dbconn.CreateCommand();
        dbcmd.CommandText = sql;
        dbcmd.ExecuteNonQuery();
        

        string sql1 = "INSERT INTO (question_text, answer_correct_ID, answer_incorrect_ID_one, answer_incorrect_ID_two)('Hvor mange procent af Aarhus samlede CO2-udledning stammer fra transport?','2','2','2')";
        dbcmd.CommandText = sql1;
        dbcmd.ExecuteNonQuery();

        string sql2 = "INSERT INTO (question_text, answer_correct_ID, answer_incorrect_ID_one, answer_incorrect_ID_two)('Hvor meget er det årlige energiforbrug i Aarhus faldet fra 2009 til 2017?','3','3','3')";
       
        dbcmd.CommandText = sql2;
        dbcmd.ExecuteNonQuery();

        string sql3= "INSERT INTO (question_text, answer_correct_ID, answer_incorrect_ID_one, answer_incorrect_ID_two)('Hvornår har Aarhus Kommune et mål om at være CO2-neutral?','4','4','4')";
   
        dbcmd.CommandText = sql3;
        dbcmd.ExecuteNonQuery();

        string sql4 = "INSERT INTO (question_text, answer_correct_ID, answer_incorrect_ID_one, answer_incorrect_ID_two)('Hvor meget er energiforbruget i de kommunale bygninger reduceret siden 2013?','5','5','5')";
        
        dbcmd.CommandText = sql4;
        dbcmd.ExecuteNonQuery();

        string sql5 = "INSERT INTO (question_text, answer_correct_ID, answer_incorrect_ID_one, answer_incorrect_ID_two)('Hvor mange gadelamper har Aarhus kommune skiftet til LED-lamper?','6','6','6')";
        
        dbcmd.CommandText = sql5;
        dbcmd.ExecuteNonQuery();

        string sql6 = "INSERT INTO (question_text, answer_correct_ID, answer_incorrect_ID_one, answer_incorrect_ID_two)('Hvor mange procent af alt affald afhentet fra private hjem i Aarhus kommune bliver sendt tilgenanvendelse ? ','7','7','7')";
        
        dbcmd.CommandText = sql6;
        dbcmd.ExecuteNonQuery();

        string sql7 = "INSERT INTO (question_text, answer_correct_ID, answer_incorrect_ID_one, answer_incorrect_ID_two)('Hvor mange kilo ikke genanvendeligt affald producere den gennemsnitligt indbygger i Århus kommune omom året?','8','8','8')";
        
        dbcmd.CommandText = sql7;
        dbcmd.ExecuteNonQuery();

        string sql8 = "INSERT INTO (question_text, answer_correct_ID, answer_incorrect_ID_one, answer_incorrect_ID_two)('Hvor lang tid tager det at nedbryde et cigaretskod i naturen?','9','9','9')";
        
        dbcmd.CommandText = sql8;
        dbcmd.ExecuteNonQuery();

        string sql9 = "INSERT INTO (question_text, answer_correct_ID, answer_incorrect_ID_one, answer_incorrect_ID_two)('Hvor lang tid tager det at nedbryde en plastikpose?','10','10','10')";
        
        dbcmd.CommandText = sql9;
        dbcmd.ExecuteNonQuery();
        dbcmd.Dispose();
        dbcmd = null;
    }
    public void CreateCorrect()
    {
        string sql = "CREATE TABLE IF NOT EXISTS Answer_correct(CID INTEGER Primary Key AUTOINCREMENT , answer_text VARCHAR(150))";

        IDbCommand dbcmd = dbconn.CreateCommand();
        dbcmd.CommandText = sql;
        dbcmd.ExecuteNonQuery();
        dbcmd.Dispose();
        dbcmd = null;
    }
    public void InsertCorrect()
    {
        string sql = "INSERT INTO (answer_text)('Transport')";
        IDbCommand dbcmd = dbconn.CreateCommand();
        dbcmd.CommandText = sql;
        dbcmd.ExecuteNonQuery();
        string sql1 = "INSERT INTO (answer_text)('57%')";
        dbcmd.CommandText = sql1;
        dbcmd.ExecuteNonQuery();
        string sql2 = "INSERT INTO (answer_text)('7,2%')";

        dbcmd.CommandText = sql2;
        dbcmd.ExecuteNonQuery();
        string sql3 = "INSERT INTO (answer_text)('2030')";

        dbcmd.CommandText = sql3;
        dbcmd.ExecuteNonQuery();
        string sql4 = "INSERT INTO (answer_text)('ca. 20%')";

        dbcmd.CommandText = sql4;
        dbcmd.ExecuteNonQuery();
        string sql5 = "INSERT INTO (answer_text)('29.000')";

        dbcmd.CommandText = sql5;
        dbcmd.ExecuteNonQuery();
        string sql6 = "INSERT INTO (answer_text)('62%')";

        dbcmd.CommandText = sql6;
        dbcmd.ExecuteNonQuery();
        string sql7 = "INSERT INTO (answer_text)('194 kg')";

        dbcmd.CommandText = sql7;
        dbcmd.ExecuteNonQuery();
        string sql8 = "INSERT INTO (answer_text)('ca. 4 år')";

        dbcmd.CommandText = sql8;
        dbcmd.ExecuteNonQuery();
        string sql9 = "INSERT INTO (answer_text)('ca. 400 år')";

        dbcmd.CommandText = sql9;
        dbcmd.ExecuteNonQuery();
        dbcmd.Dispose();
        dbcmd = null;
    }

    public void CreateIncorrect()
    {
        string sql = "CREATE TABLE Answer_incorrect(IID INTEGER Primary Key AUTOINCREMENT , answer_text_one VARCHAR(150), answer_text_two varchar(150)";

        IDbCommand dbcmd = dbconn.CreateCommand();
        dbcmd.CommandText = sql;
        dbcmd.ExecuteNonQuery();
        dbcmd.Dispose();
        dbcmd = null;
    }
    public void InsertIncorrect()
    {
        string sql = "INSERT INTO (answer_text_one, answer_text_two )('Bygninger','Industri')";
        IDbCommand dbcmd = dbconn.CreateCommand();
        dbcmd.CommandText = sql;
        dbcmd.ExecuteNonQuery();
        string sql1 = "INSERT INTO (answer_text_one, answer_text_two )('77%','97%')";
        dbcmd.CommandText = sql1;
        dbcmd.ExecuteNonQuery();
        string sql2 = "INSERT INTO (answer_text_one, answer_text_two )('28,4%','3,2%')";

        dbcmd.CommandText = sql2;
        dbcmd.ExecuteNonQuery();
        string sql3 = "INSERT INTO (answer_text_one, answer_text_two )('2040','2050')";

        dbcmd.CommandText = sql3;
        dbcmd.ExecuteNonQuery();
        string sql4 = "INSERT INTO (answer_text_one, answer_text_two )('37 %','ca. 10%')";

        dbcmd.CommandText = sql4;
        dbcmd.ExecuteNonQuery();
        string sql5 = "INSERT INTO (answer_text_one, answer_text_two )('17.000','8.000')";

        dbcmd.CommandText = sql5;
        dbcmd.ExecuteNonQuery();
        string sql6 = "INSERT INTO (answer_text_one, answer_text_two )('75%','43%')";

        dbcmd.CommandText = sql6;
        dbcmd.ExecuteNonQuery();
        string sql7 = "INSERT INTO (answer_text_one, answer_text_two )('73 kg','377 kg')";

        dbcmd.CommandText = sql7;
        dbcmd.ExecuteNonQuery();
        string sql8 = "INSERT INTO (answer_text_one, answer_text_two )('ca. 1 år','ca. 10 år')";

        dbcmd.CommandText = sql8;
        dbcmd.ExecuteNonQuery();
        string sql9 = "INSERT INTO (answer_text_one, answer_text_two )('ca. 10 år','ca. 100 år')";

        dbcmd.CommandText = sql9;
        dbcmd.ExecuteNonQuery();
        dbcmd.Dispose();
        dbcmd = null;
    }
    public void DBClose()
    { 
        dbconn.Close();
        dbconn = null;
    }

    // Update is called once per frame
    void Update()
    {
       

    }
}
