using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation_Script : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private Transform player;
    private Vector3 playersPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.Find("Players").transform;
        playersPosition = new Vector3(player.position.x, player.position.y, player.position.z);
        transform.RotateAround(playersPosition, speed);
    }
}
