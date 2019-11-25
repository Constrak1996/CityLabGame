using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coloring_Script : MonoBehaviour
{
    
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
    private IEnumerator StanderCD()
    {
        yield return new WaitForSeconds(15f);
        RedActivated = false;
        BlueActivated = false;
    }
}
