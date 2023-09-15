using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RemainingTime : MonoBehaviour
{
    [SerializeField] float timeRemaining=10f;
    public TextMeshProUGUI timeSpentText;
    public TextMeshProUGUI checkText;
    private bool finishOrder = false;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ResetTime", 10f, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        if(timeRemaining > 0f)
        {
            timeRemaining -= Time.deltaTime;
        }
        timeSpentText.text = Math.Round(timeRemaining,1).ToString("0.0");
    }

    public void SetFinishOrder()
    {
        finishOrder = true;
    }
    public void ResetTime()
    {
        if (!finishOrder)
        {
            checkText.text = "Miss";
            checkText.color = Color.yellow;
        }
        timeRemaining = 10f;
        finishOrder = false;
    }

    public void StopInvoke()
    {
        CancelInvoke("ResetTime");
        InvokeRepeating("ResetTime", 0f, 10f);
    }
}
