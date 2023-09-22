using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoffeeOrder
{
    private int coffeeStrength;
    private int ice;
    private int sugar;

    public int CoffeeStrength => coffeeStrength;
    public int Ice => ice;
    public int Sugar => sugar;

    public void SetCoffeeStrength(int newCoffeeStrength)
    {
        coffeeStrength = newCoffeeStrength;
    }

    public void SetIce(int newIce)
    {
        ice = newIce;
    }
    public void SetSugar(int newSugar)
    {
        sugar = newSugar;
    }
    public void SetOrder( int newCoffeeStrength, int newIce, int newSugar)
    {
        coffeeStrength = newCoffeeStrength;
        ice = newIce;
        sugar = newSugar;
    }
}

public class OrderManager : MonoBehaviour
{
    [SerializeField] private GameObject CustomerOrderUI;
    [SerializeField] private GameObject MakeCoffeeUI;
    [SerializeField] private GameObject CustomerResponseUI;
    //Order Information List
    //Difficulty One
    [SerializeField]
    private string[] coffeeList = { "Americano", "Black Coffee","Cappuccino","Espresso","Latte", "Macchiato", "Mocha", "Cold Coffee Variety" };
    [SerializeField]
    private string[] coffeeStrengthList = { "1", "2", "3", "4" };
    [SerializeField]
    private string[] iceList = { "Iced","Extra Iced","Hot","Extra Hot" };
    [SerializeField]
    private string[] sugarList = { "one","two","three","four" };
    //private string[] milkList
    //private string[] foodList

    //Current Order
    private CoffeeOrder currentOrder=new CoffeeOrder();


    //Customer Order
    [SerializeField] private TextMeshProUGUI orderText;
    [SerializeField] private TextMeshProUGUI responseText;

    private CoffeeOrder customerOrder=new CoffeeOrder();//CustomerOrderInformation

    private void Start()
    {
        CustomerOrderUI.SetActive(true);
        MakeCoffeeUI.SetActive(true);
        CustomerResponseUI.SetActive(false);
        InvokeRepeating("SpawnCustomerOrder", 0, 15);
        InvokeRepeating("HideCustomerOrderUI", 5, 15);
    }

    private void InitiateOrder()
    {
        customerOrder.SetOrder( 0, 0, 0);
        currentOrder.SetOrder( 0, 0, 0);
    }

    private int ChooseRandomIndex(string[] stringArray)
    {
        UnityEngine.Random.InitState((int)System.DateTime.Now.Ticks);
        return UnityEngine.Random.Range(0, stringArray.Length);
    }
    
    private void SpawnCustomerOrder()
    {
        CustomerOrderUI.SetActive(true);
        MakeCoffeeUI.SetActive(true);
        InitiateOrder();
        customerOrder.SetCoffeeStrength(ChooseRandomIndex(coffeeStrengthList)+1);
        customerOrder.SetIce(ChooseRandomIndex(iceList)+1);
        customerOrder.SetSugar(ChooseRandomIndex(sugarList)+1);
        orderText.text = "Hello there. I would like a "+coffeeList[ChooseRandomIndex(coffeeList)] +" with a strength of "+ coffeeStrengthList[customerOrder.CoffeeStrength-1] +", "
            + iceList[customerOrder.Ice-1] +", with "+ sugarList[customerOrder.Sugar - 1] +" sugar.Thank you!";
    }

    //Current Order UI interaction
    public void SetCurrentCoffeeStrength(int currentCoffeeBean)
    {
        currentOrder.SetCoffeeStrength(currentCoffeeBean);
    }
    public void SetCurrentIce(int currentIce)
    {
        currentOrder.SetIce(currentIce);
    }
    public void SetCurrentSugar(int currentSugar)
    {
        currentOrder.SetSugar(currentSugar);
    }

    //Order-related functions
    
    private void HideCustomerOrderUI()
    {
        CustomerOrderUI.SetActive(false);
    }


    public void CheckCoffee()
    {
        MakeCoffeeUI.SetActive(false);
        CustomerResponseUI.SetActive(true);
        if ((customerOrder.CoffeeStrength==currentOrder.CoffeeStrength)&&(customerOrder.Ice==currentOrder.Ice)&&(customerOrder.Sugar==currentOrder.Sugar))//Check coffee bean, ice, sugar
        {
            Debug.Log("Right");
            responseText.text = "Thank you very much!";
        }
        else
        {
            Debug.Log("Wrong");
            responseText.text = "This is not what I ordered!";
        }
    }


}
