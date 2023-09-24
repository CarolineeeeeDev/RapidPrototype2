using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
public class CustomerOreder
{
    public int ice;
    //public IceList ice;
    public int sugar;
    public int coffeeBean;
    public string name;

    public CustomerOreder(int ice, int sugar, int coffeeBean, string name)
    {
        this.ice = ice;
        this.sugar = sugar;
        this.coffeeBean = coffeeBean;
        this.name = name;
    }
}
*/

public class OrderGenerator : MonoBehaviour
{
    private CoffeeOrder currentOreder;
    private CoffeeOrder makingOrder;
    private void CreateNewOreder()
    {
        //random int
        //currentOreder = new CoffeeOrder(0,0,0,"Hi");
        //change top right UI
    }

    //Button click
    //change making order

    private void SendCoffee()
    {
        CheckCoffeeWithOrder();
    }

    private void CheckCoffeeWithOrder()
    {
        //currentOreder makingOder are same?
    }
}
