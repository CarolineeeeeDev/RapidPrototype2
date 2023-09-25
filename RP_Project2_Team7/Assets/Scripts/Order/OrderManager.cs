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
    private List<DifficultyDefinition> difficulties;
    private DifficultyDefinition currentDifficulty;
    private int currentDifficultyIndex;

    private int correctOrderCount = 0;

    //right order count
    //will reset when upgrade
    //upgrade to next level count => this can move to difficulty definition

    private void Start()
    {
        CustomerOrderUI.SetActive(true);
        MakeCoffeeUI.SetActive(true);
        CustomerResponseUI.SetActive(false);
        InvokeRepeating("SpawnCustomerOrder", 0, 15);
        InvokeRepeating("HideCustomerOrderUI", 5, 15);
        currentDifficulty = difficulties[0];
        currentDifficultyIndex = 1;
    }

    private void InitiateOrder()
    {
        customerOrder.SetOrder( 0, 0, 0);
        currentOrder.SetOrder( 0, 0, 0);
    }

    private int ChooseRandomIndex(List<string> stringArray)
    {
        //UnityEngine.Random.InitState((int)System.DateTime.Now.Ticks);
        return UnityEngine.Random.Range(0, stringArray.Count);
    }
    private int ChooseRandomIndex(string[] stringArray)
    {
        //UnityEngine.Random.InitState((int)System.DateTime.Now.Ticks);
        return UnityEngine.Random.Range(0, stringArray.Length);
    }
    
    private void SpawnCustomerOrder()
    {
        CustomerOrderUI.SetActive(true);
        MakeCoffeeUI.SetActive(true);
        InitiateOrder();
        customerOrder.SetCoffeeStrength(ChooseRandomIndex(currentDifficulty.CoffeeStrength) + 1);
        customerOrder.SetIce(ChooseRandomIndex(currentDifficulty.Ice) + 1);
        customerOrder.SetSugar(ChooseRandomIndex(currentDifficulty.Sugar) + 1);
        orderText.text = GenerateOrderText(currentDifficultyIndex);
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
        bool isCorrect = false;
        switch(currentDifficultyIndex)
        {
            case 1:
            case 2:
            case 3:
                isCorrect = (customerOrder.CoffeeStrength == currentOrder.CoffeeStrength) &&
                            (customerOrder.Ice == currentOrder.Ice) &&
                            (customerOrder.Sugar == currentOrder.Sugar);
                break;
            case 4:
            case 5:
                isCorrect = (customerOrder.CoffeeStrength == currentOrder.CoffeeStrength) &&
                            (customerOrder.Ice == currentOrder.Ice) &&
                            (customerOrder.Sugar == currentOrder.Sugar);
                            //&& extra milk && extra food
                break;
            default:
                break;
        }
        if(isCorrect)
        {
            Debug.Log("Right");
            responseText.text = currentDifficulty.CorrectSentences[ChooseRandomIndex(currentDifficulty.CorrectSentences)];
            correctOrderCount ++;
            if(correctOrderCount == currentDifficulty.UpgradeOrderCount)
            {
                Debug.Log("UPGRADE TO NEXT LEVEL");
                currentDifficultyIndex ++;
                if(difficulties.Count >= currentDifficultyIndex)
                {
                    currentDifficulty = difficulties[currentDifficultyIndex - 1];
                }
                correctOrderCount = 0;
            }
        }
        else
        {
            Debug.Log("Wrong");
            responseText.text = currentDifficulty.WrongSentences[ChooseRandomIndex(currentDifficulty.WrongSentences)];
        }
    }
    private string GenerateOrderText(int difficulty)
    {
        string orderText = "";
        switch(difficulty)
        {
            case 1:
                orderText = currentDifficulty.IntroSentences[ChooseRandomIndex(currentDifficulty.IntroSentences)] +
                            "I would like a " + 
                            coffeeList[ChooseRandomIndex(coffeeList)] +
                            " " + 
                            currentDifficulty.CoffeeStrength[customerOrder.CoffeeStrength - 1] + 
                            ", " + 
                            currentDifficulty.Ice[customerOrder.Ice - 1] +
                            ", with " + 
                            currentDifficulty.Sugar[customerOrder.Sugar - 1] +
                            ". Thank you!";
                break;
            case 2:
                orderText = currentDifficulty.IntroSentences[ChooseRandomIndex(currentDifficulty.IntroSentences)] +
                            "I would like a " +
                            coffeeList[ChooseRandomIndex(coffeeList)] +
                            " " + 
                            currentDifficulty.CoffeeStrength[customerOrder.CoffeeStrength - 1] + 
                            ", " + 
                            currentDifficulty.Ice[customerOrder.Ice - 1] +
                            ", with " + 
                            currentDifficulty.Sugar[customerOrder.Sugar - 1] +
                            ". Thank you!";
                break;
            case 3:
                orderText = currentDifficulty.IntroSentences[ChooseRandomIndex(currentDifficulty.IntroSentences)] +
                            "I would like a " +
                            coffeeList[ChooseRandomIndex(coffeeList)] +
                            " " + 
                            currentDifficulty.CoffeeStrength[customerOrder.CoffeeStrength - 1] + 
                            ", " + 
                            currentDifficulty.Ice[customerOrder.Ice - 1] +
                            ", with " + 
                            currentDifficulty.Sugar[customerOrder.Sugar - 1] +
                            ". Thank you!";
                break;
            case 4:
                orderText = currentDifficulty.IntroSentences[ChooseRandomIndex(currentDifficulty.IntroSentences)] +
                            "I would like a " + 
                            coffeeList[ChooseRandomIndex(coffeeList)] +
                            " " + 
                            currentDifficulty.CoffeeStrength[customerOrder.CoffeeStrength - 1] + 
                            ", " + 
                            currentDifficulty.Ice[customerOrder.Ice - 1] +
                            ", with " + 
                            currentDifficulty.Sugar[customerOrder.Sugar - 1] +
                            //Extra Milk
                            ", and " + 
                            //Extra food
                            ". Thank you!";
                break;
            case 5:
                orderText = currentDifficulty.IntroSentences[ChooseRandomIndex(currentDifficulty.IntroSentences)] +
                            "I would like a " +
                            coffeeList[ChooseRandomIndex(coffeeList)] +
                            " " + 
                            currentDifficulty.CoffeeStrength[customerOrder.CoffeeStrength - 1] + 
                            ", " + 
                            currentDifficulty.Ice[customerOrder.Ice - 1] +
                            ", with " + 
                            currentDifficulty.Sugar[customerOrder.Sugar - 1] +
                            //Extra Milk
                            ", and " + 
                            //Extra food
                            ". Thank you!";
                break;
            default:
                break;
            
        }
        return orderText;
    }


}
