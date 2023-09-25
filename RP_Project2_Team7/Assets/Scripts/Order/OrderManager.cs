using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    [SerializeField] private GameObject CustomerOrderUI;
    [SerializeField] private GameObject MakeCoffeeUI;
    [SerializeField] private GameObject CustomerResponseUI;
    //Order Information List
    //Difficulty One
    [SerializeField]
    private string[] coffeeList = { "Americano", "Black Coffee","Cappuccino","Espresso","Latte", "Macchiato", "Mocha", "Cold Coffee Variety" };
    // [SerializeField]
    // private string[] coffeeStrengthList = { "1", "2", "3", "4" };
    // [SerializeField]
    // private string[] iceList = { "Iced","Extra Iced","Hot","Extra Hot" };
    // [SerializeField]
    // private string[] sugarList = { "one","two","three","four" };
    //private string[] milkList
    //private string[] foodList

    //Current Order
    private CoffeeOrder currentOrder=new CoffeeOrder();


    //Customer Order
    [SerializeField] private TextMeshProUGUI orderText;
    [SerializeField] private TextMeshProUGUI responseText;

    private CoffeeOrder customerOrder=new CoffeeOrder();//CustomerOrderInformation

    [SerializeField] 
    private DifficultyDefinition startDifficulty;
    private DifficultyDefinition currentDifficulty;

    private void Start()
    {
        CustomerOrderUI.SetActive(true);
        MakeCoffeeUI.SetActive(true);
        CustomerResponseUI.SetActive(false);
        InvokeRepeating("SpawnCustomerOrder", 0, 15);
        InvokeRepeating("HideCustomerOrderUI", 5, 15);
        currentDifficulty = startDifficulty;
    }

    private void InitiateOrder()
    {
        customerOrder.SetOrder( 0, 0, 0);
        currentOrder.SetOrder( 0, 0, 0);
    }

    private int ChooseRandomIndex(List<string> stringArray)
    {
        UnityEngine.Random.InitState((int)System.DateTime.Now.Ticks);
        return UnityEngine.Random.Range(0, stringArray.Count);
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
        customerOrder.SetCoffeeStrength(ChooseRandomIndex(currentDifficulty.CoffeeStrength)+1);
        customerOrder.SetIce(ChooseRandomIndex(currentDifficulty.Ice)+1);
        customerOrder.SetSugar(ChooseRandomIndex(currentDifficulty.Sugar)+1);
        orderText.text = "Hello there. I would like a " + 
                         coffeeList[ChooseRandomIndex(coffeeList)] +
                         " " + 
                         currentDifficulty.CoffeeStrength[customerOrder.CoffeeStrength-1] + 
                         ", " + 
                         currentDifficulty.Ice[customerOrder.Ice-1] +
                         ", with " + 
                         currentDifficulty.Sugar[customerOrder.Sugar - 1] +
                         ". Thank you!";
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
