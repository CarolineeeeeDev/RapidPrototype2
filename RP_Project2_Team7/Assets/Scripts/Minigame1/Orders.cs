using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Orders : MonoBehaviour
{
    //Ice
    public string[] iceList = { "Iced", "Extra Iced", "Hot", "Extra Hot" };
    //Sugar
    public int[] sugarList = { 1, 2, 3, 4 };
    //Name
    private string[] customerNameList = { "James","Mary","Robert","Patricia","John","Jennifer","Michael","Linda","David","Elizabeth","Wiliam","Barbara","Richard","Susan","Joseph","Jessica","Thomas","Sarah","Christopher","Karen"};


    public TextMeshProUGUI customerNameText;
    public TextMeshProUGUI iceText;
    public TextMeshProUGUI sugarText;

    private int randomIce = 1;
    private int randomSugar = 1;
    private int randomCustomerName = 1;

    public int customerIce = 1;
    public int customerSugar = 1;

    void Start()
    {
        
    }

    void Update()
    {
        UnityEngine.Random.InitState((int)System.DateTime.Now.Ticks);
        randomIce = UnityEngine.Random.Range(1, 5);
        randomSugar = UnityEngine.Random.Range(1, 5);
        randomCustomerName = UnityEngine.Random.Range(0, 20);

    }

    private void SpawnOrder()
    {
        customerNameText.text = customerNameList[randomCustomerName];
        customerIce = randomIce;
        iceText.text = iceList[customerIce-1];
        customerSugar = randomSugar;
        sugarText.text = Convert.ToString(sugarList[customerSugar-1]);
    }

    public void StartOrder()
    {
        InvokeRepeating("SpawnOrder", 0f, 10f);
    }

    public void StopInvoke()
    {
        CancelInvoke("SpawnOrder");
        InvokeRepeating("SpawnOrder", 0f, 10f);
    }

    
}
