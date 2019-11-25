using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Text.RegularExpressions;
using System.Linq;
using System.IO;
using System;

public class NameHandlerScript : MonoBehaviour
{
    string accPattern = "^([a-zA-Z]{3,})+$";
    // ^ is to check from the start of the string
    // [a-zA-Z] checks all letters form 'a' to 'z', in both lower and upper case
    // {3,} checks if the letter is minimum 3 long ({min, max})
    // ( ) around the 2 above is to make sure they are calculated as a unit
    // $ checks the string all the way to the end, otherwise it just checks til it finds what its looking for
    Regex rgx;

    [SerializeField]
    TextAsset txt;


    [SerializeField]
    InputField nickName;
    [SerializeField]
    Text errorText;

    public static string ChoName { get; private set; }




    public void OnClick()
    {
        if (nickName.text != "")    //we dont like empty texts >.>... okay this could be removed, its just here for the added comment at the end xD
        {
            rgx = new Regex(accPattern);
            nickName.text = Regex.Replace(nickName.text, @"\s", "");    //space remover

            if (rgx.IsMatch(nickName.text))
            {
                string name = CurseChecker(nickName.text);  //CurseChecker is the profanity filter, so after this, just send "name" wherever you want it xD
                //errorText.text = name;  //irrelevant, just using it to check if it works xD
                //save 'name' somewhere
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else
            {
                errorText.text = "No special characters please";
            }

        }
        else
        {
            errorText.text = "at least write something >.>";
        }

        ///--------------------------
        ///Filter
        ///--------------------------
        
        string CurseChecker(string str)
        {
            ChoName = str;

            string[] matches = Regex.Split(txt.text, "\r\n?|\n", RegexOptions.Singleline);

            foreach (string word in matches)
            {
                Match mash = Regex.Match(ChoName, word, RegexOptions.IgnoreCase);
                if (mash.Success)
                {
                    ChoName = Regex.Replace(ChoName, word, "***", RegexOptions.IgnoreCase);
                }
            }

            return ChoName;
        }
    }
}
