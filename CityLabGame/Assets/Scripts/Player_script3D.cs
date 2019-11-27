using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_script : MonoBehaviour
{
    [SerializeField]
    private float runSpeed;
    [SerializeField]
    private float turnSpeed;
    [SerializeField]
    private Animator animator;

    private bool isJumping;
    private bool turnLeft;
    private bool turnRight;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("walk", runSpeed);
        animator.SetBool("WalkLeft", turnLeft);
        animator.SetBool("WalkRight", turnRight);
        animator.SetBool("IsJumping", isJumping);
        

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, 0, 1 * Time.deltaTime * runSpeed);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, -20 * Time.deltaTime * turnSpeed, 0);
            turnLeft = true;
        }
        else
        {
            turnLeft = false;
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, 0, -1 * Time.deltaTime * runSpeed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, 20 * Time.deltaTime * turnSpeed, 0);
            turnRight = true;
        }
        else
        {
            turnRight = false;
        }
        

        if (Input.GetKey(KeyCode.LeftShift))
        {
            runSpeed = 5;
        }
        else
        {
            runSpeed = 3;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.Translate(0, 1 * Time.deltaTime * 10, 0);
            isJumping = true;
        }
        isJumping = false;
    }
}
