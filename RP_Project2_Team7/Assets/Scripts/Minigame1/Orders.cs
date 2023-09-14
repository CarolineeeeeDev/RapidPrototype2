using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Orders : MonoBehaviour
{
    //Ice
    public int[] ice = { 1, 2, 3, 4 };
    //Sugar
    public int[] sugar = { 1, 2, 3, 4 };
    //Name
    private string[] customername = { "Amy","Annie","Daniel","Lucy" };
    //Time
    private float[] timespent = { 10f, 15f, 20f, 25f };

    public GameObject customerNameText;
    public GameObject iceText;
    public GameObject sugarText;
    public GameObject timeSpentText;

    private int randomIce = 1;
    private int randomSugar = 1;
    private int randomCustomerName = 1;
    private int randomTimeSpent = 1;

    public int customerIce = 1;
    public int customerSugar = 1;



    void Start()
    {
        InvokeRepeating("SpawnOrder", 0f,5f);
    }


    void Update()
    {
        UnityEngine.Random.InitState((int)System.DateTime.Now.Ticks);
        randomIce = UnityEngine.Random.Range(1, 5);
        randomSugar = UnityEngine.Random.Range(1, 5);
        randomCustomerName = UnityEngine.Random.Range(0, 4);
        randomTimeSpent = UnityEngine.Random.Range(0, 4);
    }

    private void SpawnOrder()
    {
        customerNameText.GetComponent<TextMeshProUGUI>().text = customername[randomCustomerName];
        customerIce = randomIce;
        iceText.GetComponent<TextMeshProUGUI>().text = Convert.ToString(ice[customerIce-1]);
        customerSugar = randomSugar;
        sugarText.GetComponent<TextMeshProUGUI>().text = Convert.ToString(sugar[customerSugar-1]);
        timeSpentText.GetComponent<TextMeshProUGUI>().text = Convert.ToString(timespent[randomTimeSpent]);
        //Debug.Log(randomInt);
    }
}
