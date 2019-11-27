using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveable_Script : MonoBehaviour
{
    [SerializeField]
    private Transform hands;

    private void OnMouseDown()
    {
            GetComponent<Rigidbody>().useGravity = false;
            this.transform.position = hands.position;
            this.transform.parent = GameObject.Find("Hands").transform;
    }
    private void OnMouseUp()
    { 
            this.transform.parent = null;
            GetComponent<Rigidbody>().useGravity = true;
    }
}
