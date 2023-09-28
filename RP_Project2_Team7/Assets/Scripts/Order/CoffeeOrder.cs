using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeOrder
{
    private int coffeeStrength;
    private int ice;
    private int sugar;
    private int cupSize;

    public int CoffeeStrength => coffeeStrength;
    public int Ice => ice;
    public int Sugar => sugar;
    public int CupSize => cupSize;

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
    public void SetCupSize(int newCupSize)
    {
        cupSize = newCupSize;
    }
    public void SetOrder( int newCoffeeStrength, int newIce, int newSugar,int newCupSize)
    {
        coffeeStrength = newCoffeeStrength;
        ice = newIce;
        cupSize=newCupSize;
        sugar = newSugar;
    }
}
