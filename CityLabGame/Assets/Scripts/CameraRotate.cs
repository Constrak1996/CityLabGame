using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    [SerializeField]
    private float speedH = 2f;
    [SerializeField]
    private float speedW = 2f;

    private float mouseX;
    private float mouseY;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mouseX += speedH * Input.GetAxis("Mouse X");
        mouseY -= speedW * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(mouseY, mouseX, 0);
    }
}
