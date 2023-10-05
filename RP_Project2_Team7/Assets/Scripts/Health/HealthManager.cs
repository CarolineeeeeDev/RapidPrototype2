using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    private const string _triggerParam = "Result";
    [SerializeField] private OrderManager orderManager;
    //Move these to difficulty SO
    // [SerializeField] private float sanityDecreaseDelay = 0.2f;
    // [SerializeField] private float additionInrease = 10f;
    [SerializeField] private float pillCoolDown = 1f;
    [SerializeField]
    private int urgentPillSanity = 30;
    [SerializeField]
    private int blurStageTwoStartSanity = 30;
    [SerializeField]
    private int blurStageOneStartSanity = 90;
    [SerializeField]
    private int blendStartSanity = 70;
    [SerializeField]
    private int noiseStartSanity = 70;
    [SerializeField]
    private Button pillButton;
    [SerializeField]
    private GameObject pillDisableButton;
    [SerializeField]
    private Sprite urgentPillSprite;
    [SerializeField]
    private Sprite regularPillSprite;
    [SerializeField]
    private Image fillArea;


    private int sanity;
    private float addiction;
    public Slider healthBar;
    public Slider addictionBar;
    private Coroutine sanityDropCoroutine;

    private float BlendCount = 1;


    void Start()
    {
        sanity = 100;
        healthBar.value = sanity;
        addiction = 0f;
        addictionBar.value = addiction;
        sanityDropCoroutine = StartCoroutine(SanityDrop());
    }

    private IEnumerator SanityDrop()
    {
        sanity = 100;
        pillButton.image.sprite = regularPillSprite;
        DifficultyDefinition currentDifficulty = orderManager.CurrentDifficulty;
        while(sanity > 0)
        {
            sanity --;
            healthBar.value = sanity;
            if(sanity == blurStageOneStartSanity)
            {
                EffectManager.Instance.RestartStageOneBlur(currentDifficulty.StageOneblurSpeed);
                EffectManager.Instance.RestartFlash(currentDifficulty.StageOneFlashSpeed, currentDifficulty.StageOneFlashCount);
            }
            if(sanity == blurStageTwoStartSanity)
            {
                EffectManager.Instance.RestartStageTwoBlur(currentDifficulty.StageTwoblurSpeed);
                EffectManager.Instance.RestartFlash(currentDifficulty.StageTwoFlashSpeed, currentDifficulty.StageTwoFlashCount);
            }

            if(sanity == noiseStartSanity)
            {
                MusicManager.Instance.RestartDrugMode(currentDifficulty.NoiseSpeed);
            }
            if(sanity == urgentPillSanity)
            {
                pillButton.image.sprite = urgentPillSprite;
            }
            if(sanity <= 0)
            {
                EndGame();
            }
            yield return new WaitForSeconds(orderManager.CurrentDifficulty.SanityDecreaseDelay);
        }
        yield return null;
    }

    public void TakePill()
    {
        if(sanityDropCoroutine != null)
        {
            StopCoroutine(sanityDropCoroutine);
            sanityDropCoroutine = null;
        }
        sanityDropCoroutine = StartCoroutine(SanityDrop());
        //EffectManager.Instance.StopBlend();
        EffectManager.Instance.StopBlur();
        MusicManager.Instance.StopMusicNoise();
        BlendCount += 0.075f;
        EffectManager.Instance.AddBlend(orderManager.CurrentDifficulty.AddictionIncreaseAmount * orderManager.CurrentDifficulty.BlendSpeed * BlendCount, orderManager.CurrentDifficulty.UIBlendSpeed);

        StartCoroutine(PillCoolDown());

        addiction += orderManager.CurrentDifficulty.AddictionIncreaseAmount;
        addictionBar.value = addiction;
        Debug.Log("CURRENT ADDICTION: " + addiction);
        //Lose
        if(addiction >= 100f)
        {
            EndGame();
        }
    }

    private IEnumerator PillCoolDown()
    {
        if(pillDisableButton == null)
        {
            Debug.Log("Pill disable button not assign!");
            yield break;
        }
        pillDisableButton.SetActive(true);
        yield return new WaitForSeconds(pillCoolDown);
        pillDisableButton.SetActive(false);
    }

    public void EndGame()
    {
        GameFlow.Instance.Control.SetTrigger(_triggerParam);
    }

    private IEnumerator CompleteOrderEffect()
    {
        fillArea.color = Color.green;
        yield return new WaitForSeconds(1);
        fillArea.color = new Color(81f / 255f, 166f / 255f, 1, 1);
    }
    public void CompleteOrder()
    {
        sanity += 5;
        
        StartCoroutine(CompleteOrderEffect());
    }

    
}
