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

    private void Start()
    {
        stall = GameObject.FindGameObjectWithTag("StallColoring");
        Grid.GetComponent<Renderer>().material = material[2];
        isNeutral = true;
    }

    private void Update()
    {
        Coloring_Script stallColoring = stall.GetComponent<Coloring_Script>();
        if (stallColoring != null)
        {
            redTaken = stallColoring.RedActivated;
            blueTaken = stallColoring.BlueActivated;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "BluePlayer")
        {
            Grid.GetComponent<Renderer>().material = material[0];
        }

        if (other.gameObject.tag == "RedPlayer")
        {
            Grid.GetComponent<Renderer>().material = material[1];
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
