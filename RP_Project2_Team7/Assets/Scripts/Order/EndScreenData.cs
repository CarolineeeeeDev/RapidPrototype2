using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class EndScreenData : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI countText;
    void Start()
    {
        countText.text = "You finished "+Convert.ToString(GameObject.Find("CorrectOrderData").GetComponent<CorrectOrderData>().CorrectOrderCount)+" orders";
    }

    
}
