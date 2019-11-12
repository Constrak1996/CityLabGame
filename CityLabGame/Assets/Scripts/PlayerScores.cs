using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScores : MonoBehaviour
{
    public Text redScore;
    public Text blueScore;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        redScore.text = "Red Score: "+ GameBoardStats.redScore;
        blueScore.text = "Blue Score: " + GameBoardStats.blueScore;
    }
}
