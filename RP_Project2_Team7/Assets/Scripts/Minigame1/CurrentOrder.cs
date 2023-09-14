using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CurrentOrder : MonoBehaviour
{
    public int coffee;
    public int ice;
    public int sugar;
    private int customerOrderIce;
    private int customerOrderSugar;
    public GameObject CustomerOrder;
    public GameObject coffeeText;
    public GameObject iceText;
    public GameObject sugarText;
    void Start()
    {
        coffee = 0;
        ice = 0;
        sugar = 0;
        customerOrderIce = CustomerOrder.GetComponent<Orders>().customerIce;
        customerOrderSugar = CustomerOrder.GetComponent<Orders>().customerSugar;
    }

    
    void Update()
    {
        customerOrderIce = CustomerOrder.GetComponent<Orders>().customerIce;
        customerOrderSugar = CustomerOrder.GetComponent<Orders>().customerSugar;
        switch (coffee)
        {
            case 0: 
                coffeeText.GetComponent<TextMeshProUGUI>().text = "No coffee";
                break;
            case 1:
                coffeeText.GetComponent<TextMeshProUGUI>().text = "Coffee";
                break;
        }
        iceText.GetComponent<TextMeshProUGUI>().text = Convert.ToString(ice);
        sugarText.GetComponent<TextMeshProUGUI>().text = Convert.ToString(sugar);
    }

    public void RemoveCoffee()
    {
        if ((coffee==1)&&(ice==customerOrderIce)&&(sugar==customerOrderSugar))
        {
            Debug.Log("Yes!");
        }
        else
        {
            Debug.Log("No!");
            if(coffee!=1)
            {
                Debug.Log("No coffee");
            }
            if(ice != customerOrderIce)
            {
                Debug.Log("Ice Error");
                Debug.Log(ice);
                Debug.Log(customerOrderIce);
            }
            if (sugar!=customerOrderSugar)
            {
                Debug.Log("Sugar Error");
                Debug.Log(sugar);
                Debug.Log(customerOrderSugar);
            }
        }
        coffee = 0;
        ice = 0;
        sugar = 0;
    }

    public void CheckOrder()
    {

        RemoveCoffee();
    }

    public void SetCoffee()
    {
        coffee = 1;
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
