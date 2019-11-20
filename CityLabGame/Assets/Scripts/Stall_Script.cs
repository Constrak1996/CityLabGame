using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stall_Script : MonoBehaviour
{
    [SerializeField]
    private GameObject quizPanel;
    public bool redActivated = true;
    public bool blueActivated = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "BluePlayer" || other.gameObject.tag == "RedPlayer")
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
