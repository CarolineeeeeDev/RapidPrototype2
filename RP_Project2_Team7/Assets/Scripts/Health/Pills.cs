using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pills : MonoBehaviour
{
    public GameObject sanity;
    public GameObject addiction;

    public void PillEffect()
    {
            sanity.GetComponent<Sanity>().san = 100;
            addiction.GetComponent<Addiction>().addiction += 10f; 

    }

}
