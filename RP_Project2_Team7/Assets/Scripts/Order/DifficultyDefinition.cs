using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Order/Difficulty")]
public class DifficultyDefinition : ScriptableObject
{
    [SerializeField]
    private int upgradeOrderCount;
    public int UpgradeOrderCount => upgradeOrderCount;
    [SerializeField]
    private float sanityDecreaseDelay = 0.4f;
    public float SanityDecreaseDelay => sanityDecreaseDelay;
    [SerializeField]
    private float addictionIncreaseAmount = 5;
    public float AddictionIncreaseAmount => addictionIncreaseAmount;
    [Header("Effects")]
    [SerializeField]
    private float stageOneblurSpeed = 0.0002f;
    public float StageOneblurSpeed => stageOneblurSpeed;
    [SerializeField]
    private float stageTwoblurSpeed = 0.001f;
    public float StageTwoblurSpeed => stageTwoblurSpeed;
    [SerializeField]
    private float blendSpeed = 0.4f;
    public float BlendSpeed => blendSpeed;
    [SerializeField]
    [Range(0.1f, 10f)]
    private float noiseSpeed = 0.05f;
    public float NoiseSpeed => noiseSpeed;


    [Header("Random Order")]

    [SerializeField]
    private List<string> coffeeStrength;
    public List<string> CoffeeStrength => coffeeStrength;
    [SerializeField]
    private List<string> ice;
    public List<string> Ice => ice;
    [SerializeField]
    private List<string> cupSize;
    public List<string> CupSize => cupSize;
    [SerializeField]
    private List<string> sugar;
    public List<string> Sugar => sugar;
    [SerializeField]
    private List<string> extraMilk;
    public List<string> ExtraMilk => extraMilk;
    [SerializeField]
    private List<string> extraFood;
    public List<string> ExtraFood => extraFood;

    [Header("Random Sentences")]

    [SerializeField]
    private List<string> introSentences;
    public List<string> IntroSentences => introSentences;
    [SerializeField]
    private List<string> correctSentences;
    public List<string> CorrectSentences => correctSentences;
    [SerializeField]
    private List<string> wrongSentences;
    public List<string> WrongSentences => wrongSentences;

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
