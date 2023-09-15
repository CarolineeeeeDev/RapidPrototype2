using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sanity : MonoBehaviour
{
    public float san;
    public Slider healthbar; 

    void Start()
    {
        san = 100f;
        healthbar.value = san;
    }

    void Update()
    {
        san -= Time.deltaTime*5f;
        healthbar.value = san;
        if (san<=0)
        {
            //Lose

        }
    }
}
