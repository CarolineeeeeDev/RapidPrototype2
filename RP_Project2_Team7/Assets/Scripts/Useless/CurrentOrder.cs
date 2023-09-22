using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CurrentOrder : MonoBehaviour
{
    //public int ice;//add function
    private int ice;
    //public int Ice-
    private string[] iceList = { "None","Iced", "Extra Iced", "Hot", "Extra Hot" };//public it
    public int sugar;
    public int coffeeBean;
    private int customerOrderIce;
    private int customerOrderCoffeeBean;
    private int customerOrderSugar;
    public GameObject CustomerOrder;
    public TextMeshProUGUI coffeeBeanText;
    public TextMeshProUGUI iceText;
    public TextMeshProUGUI sugarText;
    public TextMeshProUGUI checkText;
    void Start()
    {
        coffeeBean = 0;
        ice = 0;
        sugar = 0;
        customerOrderIce = CustomerOrder.GetComponent<Orders>().customerIce;
        customerOrderSugar = CustomerOrder.GetComponent<Orders>().customerSugar;
        customerOrderCoffeeBean=CustomerOrder.GetComponent<Orders>().customerCoffeeBean;
    }

    
    void Update()
    {
        customerOrderIce = CustomerOrder.GetComponent<Orders>().customerIce;
        customerOrderSugar = CustomerOrder.GetComponent<Orders>().customerSugar;
        customerOrderCoffeeBean = CustomerOrder.GetComponent<Orders>().customerCoffeeBean;
        iceText.text = "Ice:" + Convert.ToString(iceList[ice]);
        sugarText.text ="Sugar:"+ Convert.ToString(sugar);
        coffeeBeanText.text = "Shots:"+Convert.ToString(coffeeBean);
    }

    public void RemoveCoffee()
    {
        if ((coffeeBean == customerOrderCoffeeBean) &&(ice==customerOrderIce)&&(sugar==customerOrderSugar))
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
        coffeeBean = 0;
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

    public void SetCoffeeBeanOne()
    {
        coffeeBean = 1;
    }

    public void SetCoffeeBeanTwo()
    {
        coffeeBean = 2;
    }
    public void SetCoffeeBeanThree()
    {
        coffeeBean = 3;
    }
    public void SetCoffeeBeanFour()
    {
        coffeeBean = 4;
    }






}
