using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Addiction : MonoBehaviour
{
    public float addiction;
    public Slider addictionBar;

    void Start()
    {
        addiction = 0f;
        addictionBar.value = addiction;
    }


    void Update()
    {
        addictionBar.value = addiction;
        if(addictionBar.value>=100)
        {
            //Lose
        }
    }
}
