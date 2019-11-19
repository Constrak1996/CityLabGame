using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coloring_Script : MonoBehaviour
{
    [SerializeField]
    private GameObject Grid;
    [SerializeField]
    private Material[] material;

    public bool BlueActivated = false;
    public bool RedActivated = true;

    public bool WaveOfColors = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (WaveOfColors == true)
        {
            if (other.gameObject.tag == "Grid" && RedActivated == true)
            {
                Debug.Log("Colliding, Red");
                Grid.GetComponent<Renderer>().material = material[1];
                StartCoroutine(StanderCD());
            }

            if (other.gameObject.tag == "Grid" && BlueActivated == true)
            {
                Debug.Log("Colliding, Blue");
                Grid.GetComponent<Renderer>().material = material[0];
                StartCoroutine(StanderCD());
            }
            StartCoroutine(WaveOfColorCD());
            WaveOfColors = false;
        }
        
    }
    private IEnumerator StanderCD()
    {
        yield return new WaitForSeconds(15f);
        RedActivated = false;
        BlueActivated = false;
    }

    private IEnumerator WaveOfColorCD()
    {
        yield return new WaitForSeconds(1f);
        WaveOfColors = true;
    }
}
