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
    [SerializeField] private GameObject ToCoffeeSpotButton;
    [SerializeField] private GameObject cameraManager;
    [SerializeField] private GameObject CorrectOrderData;
    [SerializeField]
    private GameObject missText;
    [SerializeField]
    private GameObject coffeeCanvas;
    [SerializeField] private GameObject healthManager;

    //Order Information List
    //Difficulty One
    [SerializeField]
    private string[] coffeeList = { "Americano", "Black Coffee","Cappuccino","Espresso","Latte", "Macchiato", "Mocha", "Cold Coffee Variety" };

    //Current Order
    private CoffeeOrder currentOrder=new CoffeeOrder();


    //Customer Order
    [SerializeField] private TextMeshProUGUI orderText;
    [SerializeField] private TextMeshProUGUI responseText;
    [SerializeField] private int orderDisplayTime=60;
    private CoffeeOrder customerOrder=new CoffeeOrder();//CustomerOrderInformation
    private bool isOrderFinished;
    [SerializeField] 
    private List<DifficultyDefinition> difficulties;
    private DifficultyDefinition currentDifficulty;
    public DifficultyDefinition CurrentDifficulty => currentDifficulty;
    private int currentDifficultyIndex;
    public int CurrentDifficultyIndex => currentDifficultyIndex;

    private int correctOrderCount = 0;
    private int allCorrectOrderCount = 0;
    //right order count
    //will reset when upgrade
    //upgrade to next level count => this can move to difficulty definition

    private void Start()
    {
        // CustomerOrderUI.SetActive(true);
        // MakeCoffeeUI.SetActive(false);
        // CustomerResponseUI.SetActive(false);
        // InvokeRepeating("SpawnCustomerOrder", 0, orderDisplayTime);
        // InvokeRepeating("HideCustomerOrderUI", 5, orderDisplayTime);
        // currentDifficulty = difficulties[0];
        // currentDifficultyIndex = 1;
        // isOrderFinished = true;
        
    }

    public void StartOrder()
    {
        CustomerOrderUI.SetActive(true);
        MakeCoffeeUI.SetActive(false);
        CustomerResponseUI.SetActive(false);
        InvokeRepeating("SpawnCustomerOrder", 0, orderDisplayTime);
        InvokeRepeating("HideCustomerOrderUI", 5, orderDisplayTime);
        currentDifficulty = difficulties[0];
        currentDifficultyIndex = 1;
        isOrderFinished = true;
    }

    private void InitiateOrder()
    {
        customerOrder.SetOrder( 0, 0, 0, 0);
        currentOrder.SetOrder( 0, 0, 0, 0);
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
        if(!isOrderFinished)
        {
            Instantiate(missText);
            Debug.Log("Miss!");
        }
        isOrderFinished = false;
        cameraManager.GetComponent<CameraManager>().SetPosition(0);
        CustomerOrderUI.SetActive(true);
        MakeCoffeeUI.SetActive(false);
        CustomerResponseUI.SetActive(false);
        InitiateOrder();
        customerOrder.SetCoffeeStrength(ChooseRandomIndex(currentDifficulty.CoffeeStrength) + 1);
        customerOrder.SetIce(ChooseRandomIndex(currentDifficulty.Ice) + 1);
        customerOrder.SetCupSize(ChooseRandomIndex(currentDifficulty.CupSize) + 1);
        customerOrder.SetSugar(ChooseRandomIndex(currentDifficulty.Sugar) + 1);

        orderText.text = GenerateOrderText(currentDifficultyIndex);
    }


    //Current Order UI interaction
    public void SetCurrentCoffeeStrength(int currentCoffeeBean)
    {
        currentOrder.SetCoffeeStrength(currentCoffeeBean);
        MusicManager.Instance.PlySelectSound();
        MusicManager.Instance.PlayStrengthSound();
    }
    public void SetCurrentIce(int currentIce)
    {
        currentOrder.SetIce(currentIce);
        MusicManager.Instance.PlySelectSound();
        MusicManager.Instance.PlayIceSound();
    }
    public void SetCurrentCupSize(int currentCupSize)
    {
        currentOrder.SetCupSize(currentCupSize);
        MusicManager.Instance.PlayCupSound();
        //MusicManager.Instance.PlySelectSound();
    }
    public void SetCurrentSugar(int currentSugar)
    {
        currentOrder.SetSugar(currentSugar);
        MusicManager.Instance.PlySelectSound();
    }

    //Order-related functions
    
    private void HideCustomerOrderUI()
    {
        CustomerOrderUI.SetActive(false);
        ToCoffeeSpotButton.SetActive(true);
    }


    public void CheckCoffee()
    {
        isOrderFinished = true;
        cameraManager.GetComponent<CameraManager>().SetPosition(0);
        MusicManager.Instance.PlySelectSound();
        MusicManager.Instance.PlayFinishCoffeeSound();
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
                            (customerOrder.CupSize == currentOrder.CupSize);
                break;
            case 4:
            case 5:
                isCorrect = (customerOrder.CoffeeStrength == currentOrder.CoffeeStrength) &&
                            (customerOrder.Ice == currentOrder.Ice) &&
                            (customerOrder.CupSize == currentOrder.CupSize)&&
                            (customerOrder.Sugar == currentOrder.Sugar);
                break;
            default:
                break;
        }
        if(isCorrect)
        {
            Debug.Log("Right");
            healthManager.GetComponent<HealthManager>().CompleteOrder();
            allCorrectOrderCount += 1;
            CorrectOrderData.GetComponent<CorrectOrderData>().SetCorrectOrderCount(allCorrectOrderCount);

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
        CancelInvoke("SpawnCustomerOrder");
        CancelInvoke("HideCustomerOrderUI");
        InvokeRepeating("SpawnCustomerOrder", 5, orderDisplayTime);
        InvokeRepeating("HideCustomerOrderUI", 10, orderDisplayTime);
    }
    private string GenerateOrderText(int difficulty)
    {
        string orderText = "";
        switch(difficulty)
        {
            case 1:
                orderText = currentDifficulty.IntroSentences[ChooseRandomIndex(currentDifficulty.IntroSentences)] +
                            "! I would like a " + 
                            coffeeList[ChooseRandomIndex(coffeeList)] +
                            " " + 
                            currentDifficulty.CoffeeStrength[customerOrder.CoffeeStrength - 1] + 
                            ", " + 
                            currentDifficulty.Ice[customerOrder.Ice - 1] +
                            ", " + 
                            currentDifficulty.CupSize[customerOrder.CupSize - 1] +
                            ". Thank you!";
                break;
            case 2:
                orderText = currentDifficulty.IntroSentences[ChooseRandomIndex(currentDifficulty.IntroSentences)] +
                            "! I would like a " +
                            coffeeList[ChooseRandomIndex(coffeeList)] +
                            " " + 
                            currentDifficulty.CoffeeStrength[customerOrder.CoffeeStrength - 1] + 
                            ", " + 
                            currentDifficulty.Ice[customerOrder.Ice - 1] +
                            ", " + 
                            currentDifficulty.CupSize[customerOrder.CupSize - 1] +
                            ". Thank you!";
                break;
            case 3:
                orderText = currentDifficulty.IntroSentences[ChooseRandomIndex(currentDifficulty.IntroSentences)] +
                            "! I would like a " +
                            coffeeList[ChooseRandomIndex(coffeeList)] +
                            " " + 
                            currentDifficulty.CoffeeStrength[customerOrder.CoffeeStrength - 1] + 
                            ", " + 
                            currentDifficulty.Ice[customerOrder.Ice - 1] +
                            ", " + 
                            currentDifficulty.CupSize[customerOrder.CupSize - 1] +
                            ". Thank you!";
                break;
            case 4:
                orderText = currentDifficulty.IntroSentences[ChooseRandomIndex(currentDifficulty.IntroSentences)] +
                            "! I would like a " + 
                            coffeeList[ChooseRandomIndex(coffeeList)] +
                            " " + 
                            currentDifficulty.CoffeeStrength[customerOrder.CoffeeStrength - 1] + 
                            ", " + 
                            currentDifficulty.Ice[customerOrder.Ice - 1] +
                            ", " + 
                            currentDifficulty.CupSize[customerOrder.CupSize - 1] +
                            ", and " +
                            currentDifficulty.Sugar[customerOrder.Sugar - 1]+
                            ". Thank you!";
                break;
            case 5:
                orderText = currentDifficulty.IntroSentences[ChooseRandomIndex(currentDifficulty.IntroSentences)] +
                            "! I would like a " +
                            coffeeList[ChooseRandomIndex(coffeeList)] +
                            " " + 
                            currentDifficulty.CoffeeStrength[customerOrder.CoffeeStrength - 1] + 
                            ", " + 
                            currentDifficulty.Ice[customerOrder.Ice - 1] +
                            ", " + 
                            currentDifficulty.CupSize[customerOrder.CupSize - 1] +
                            ", and " +
                            currentDifficulty.Sugar[customerOrder.Sugar - 1] +
                            ". Thank you!";
                break;
            default:
                break;
            
        }
        return orderText;
    }


}
