using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGridCollision : MonoBehaviour
{
    public GameObject Grid;
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
        stallScript = GetComponent<Coloring_Script>();
        Grid.GetComponent<Renderer>().material = material[2];
        isNeutral = true;
    }

    private void Update()
    {
        //redTaken = stallScript.RedActivated;
        //blueTaken = stallScript.BlueActivated;
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
            if (other.gameObject.tag == "StallColoring")
            {
                Debug.Log("Colliding, Red (Grid)");
                Grid.GetComponent<Renderer>().material = material[0];
            }

            if (other.gameObject.tag == "StallColoring")
            {
                Debug.Log("Colliding, Blue (Grid)");
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
