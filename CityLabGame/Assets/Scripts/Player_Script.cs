using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Script : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private GameObject redPlayer;
    private GameObject bluePlayer;
    private Rigidbody rb;
    private bool isAttached = false;
    float movementX;
    float movementY;

    [SerializeField]
    private float speedH = 2f;
    [SerializeField]
    private float speedW = 2f;

    private float mouseX;
    private float mouseY;
    // Start is called before the first frame update
    void Start()
    {
        redPlayer = GameObject.Find("MoveableRedPlayer");
        bluePlayer = GameObject.Find("MoveableBluePlayer");
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Movement();

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, 0, 0.25f * Time.deltaTime * speed);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, 0, -0.25f * Time.deltaTime * speed);
        }

        if (Input.GetKey(KeyCode.X))
        {
            transform.Translate(0, -0.1f * Time.deltaTime * speed, 0);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            transform.Translate(0, 0.1f * Time.deltaTime * speed, 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(0.25f * Time.deltaTime * speed, 0, 0);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-0.25f * Time.deltaTime * speed, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.SetParent(null);
        }

        mouseX += speedH * Input.GetAxis("Mouse X");
        mouseY -= speedW * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(mouseY, mouseX, 0);
    }

    private void Movement()
    {
        movementX = Input.GetAxisRaw("Horizontal");
        movementY = Input.GetAxisRaw("Vertical");

        rb.velocity = new Vector3(0,0,movementY * Time.deltaTime * speed);
        
        rb.transform.Rotate(0, movementX * Time.deltaTime * speed, 0);

    }
}
