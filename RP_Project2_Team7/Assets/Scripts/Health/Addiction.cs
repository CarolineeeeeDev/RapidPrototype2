using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Addiction : MonoBehaviour
{
    public float addiction;
    public Slider addictionBar;
    // Start is called before the first frame update
    void Start()
    {
        addiction = 0f;
        addictionBar.value = addiction;
    }

    // Update is called once per frame
    void Update()
    {
        addictionBar.value = addiction;
    }
}
