using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sanity : MonoBehaviour
{
    public float san;
    public Slider healthbar; 
    // Start is called before the first frame update
    void Start()
    {
        san = 100f;
        healthbar.value = san;
    }

    // Update is called once per frame
    void Update()
    {
        san -= Time.deltaTime*5f;
        healthbar.value = san;
    }
}
