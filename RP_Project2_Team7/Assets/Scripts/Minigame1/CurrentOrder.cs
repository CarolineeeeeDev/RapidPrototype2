using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CurrentOrder : MonoBehaviour
{
    public int ice;
    private string[] iceList = { "None","Iced", "Extra Iced", "Hot", "Extra Hot" };
    public int sugar;
    private int customerOrderIce;
    private int customerOrderSugar;
    public GameObject CustomerOrder;
    public TextMeshProUGUI iceText;
    public TextMeshProUGUI sugarText;
    public TextMeshProUGUI checkText;
    void Start()
    {
        ice = 0;
        sugar = 0;
        customerOrderIce = CustomerOrder.GetComponent<Orders>().customerIce;
        customerOrderSugar = CustomerOrder.GetComponent<Orders>().customerSugar;
    }

    
    void Update()
    {
        customerOrderIce = CustomerOrder.GetComponent<Orders>().customerIce;
        customerOrderSugar = CustomerOrder.GetComponent<Orders>().customerSugar;
        iceText.text = "Ice:" + Convert.ToString(iceList[ice]);
        sugarText.text ="Sugar:"+ Convert.ToString(sugar);
    }

    public void RemoveCoffee()
    {
        if ((ice==customerOrderIce)&&(sugar==customerOrderSugar))
        {
            checkText.text = "Right";
            checkText.color = Color.green;
            //No Rewards?
            
        }
        else
        {
            checkText.text = "Wrong";
            checkText.color = Color.red;
            //Sanity--

        }
        ice = 0;
        sugar = 0;
    }

    public void CheckOrder()
    {
        RemoveCoffee();
    }


    public void SetIceOne()
    {
        ice = 1;
    }

    public void SetIceTwo()
    {
        ice = 2;
    }
    public void SetIceThree()
    {
        ice = 3;
    }
    public void SetIceFour()
    {
        ice = 4;
    }

    public void SetSugarOne()
    {
        sugar = 1;
    }

    public void SetSugarTwo()
    {
        sugar = 2;
    }
    public void SetSugarThree()
    {
        sugar = 3;
    }
    public void SetSugarFour()
    {
        sugar = 4;
    }






}
