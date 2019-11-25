using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGridCollision : MonoBehaviour
{
    public GameObject Grid;
    private GameObject stall;
    public Material[] material;
    private Coloring_Script stallScript;
    private bool waveOfColors = true;
    private bool redTaken;
    private bool blueTaken;
    private bool isNeutral;
    private bool isBlue;
    private bool isRed;

    public static int redScore;
    public static int blueScore;

    private void Start()
    {
        stall = GameObject.FindGameObjectWithTag("StallColoring");
        Grid.GetComponent<Renderer>().material = material[2];
        isNeutral = true;
    }

    private void Update()
    {
        stallScript = stall.gameObject.GetComponent<Coloring_Script>();
        if (stallScript != null)
        {
            redTaken = stallScript.RedActivated;
            blueTaken = stallScript.BlueActivated;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //If grid is neutral and collide with blueplayer
        if (other.gameObject.tag == "BluePlayer" && isNeutral)
        {
            Grid.GetComponent<Renderer>().material = material[0];

            blueScore += 1;
            isNeutral = false;
            isBlue = true;
            isRed = false;
        }

        //If grid is neutral and collide with redplayer
        if (other.gameObject.tag == "RedPlayer" && isNeutral)
        {
            Grid.GetComponent<Renderer>().material = material[1];

            redScore += 1;
            isNeutral = false;
            isRed = true;
            isBlue = false;
        }

        //if grid is red and colliding with blueplayer
        if (other.gameObject.tag == "BluePlayer" && isRed)
        {
            Grid.GetComponent<Renderer>().material = material[0];

            redScore -= 1;
            blueScore += 1;
            isBlue = true;
            isRed = false;
        }

        //if grid is blue and colliding with redplayer
        if (other.gameObject.tag == "RedPlayer" && isBlue)
        {
            Grid.GetComponent<Renderer>().material = material[1];
            
            redScore += 1;
            blueScore -= 1;
            isBlue = false;
            isRed = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (waveOfColors == true)
        {
            if (other.gameObject.tag == "StallColoring" && blueTaken == true)
            {
                Debug.Log("Colliding, Blue (Grid)");
                Grid.GetComponent<Renderer>().material = material[0];
            }

            if (other.gameObject.tag == "StallColoring" && redTaken == true)
            {
                Debug.Log("Colliding, Red (Grid)");
                Grid.GetComponent<Renderer>().material = material[1];
            }
            StartCoroutine(WaveOfColorCD());
            waveOfColors = false;
        }

    }

    private IEnumerator WaveOfColorCD()
    {
        yield return new WaitForSeconds(1f);
        waveOfColors = true;
    }
}
