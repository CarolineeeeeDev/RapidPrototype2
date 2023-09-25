using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Order/Difficulty")]
public class DifficultyDefinition : ScriptableObject
{
    [SerializeField]
    private List<string> coffeeStrength;
    public List<string> CoffeeStrength => coffeeStrength;
    [SerializeField]
    private List<string> ice;
    public List<string> Ice => ice;
    [SerializeField]
    private List<string> sugar;
    public List<string> Sugar => sugar;
    [SerializeField]
    private List<string> extraMilk;
    public List<string> ExtraMilk => extraMilk;
    [SerializeField]
    private List<string> extraFood;
    public List<string> ExtraFood => extraFood;

    // [SerializeField]
    // private bool hasRandomOrderChange;
    // public bool HasRandomOrderChange => hasRandomOrderChange;
    // [SerializeField]
    // private bool hasExtraMilk;
    // public bool HasExtraMilk => hasExtraMilk;
    // [SerializeField]
    // private bool hasExtraMilkChange;
    // public bool HasExtraMilkChange => hasExtraMilkChange;
    // [SerializeField]
    // private bool hasExtraFood;
    // public bool HasExtraFood => hasExtraFood;
    // [SerializeField]
    // private bool hasExtraFoodChange;
    // public bool HasExtraFoodChange => hasExtraFoodChange;
}
