using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pills : MonoBehaviour
{
    public GameObject sanity;
    public GameObject addiction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            sanity.GetComponent<Sanity>().san = 100;
            addiction.GetComponent<Addiction>().addiction += 10f; 
        }

    }

}
