using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePlayerGridCollision : MonoBehaviour
{
    public GameObject Grid;
    public Material[] Color;
    private Renderer rend;
    
    void start()
    {
        //rend = GetComponent<Renderer>();
        //rend.enabled = true;
        //rend.sharedMaterial = material[0];
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "BluePlayer")
        {
            Grid.GetComponent<Renderer>().material = Color[0];
            Debug.Log("Collided with blue");
        }

        if (other.gameObject.tag == "RedPlayer")
        {
            Grid.GetComponent<Renderer>().material = Color[1];
        }
    }
}
