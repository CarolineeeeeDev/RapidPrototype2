using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quest1 : MonoBehaviour
{
    public int organizedCup = 0;
    public Button button;

    void Update()
    {
        if (organizedCup==3)
        {
            button.GetComponent<Image>().color = Color.green;
        }
    }
}
