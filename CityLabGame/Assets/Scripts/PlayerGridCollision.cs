using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGridCollision : MonoBehaviour
{
    public GameObject Grid;
    public Material[] material;

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
}