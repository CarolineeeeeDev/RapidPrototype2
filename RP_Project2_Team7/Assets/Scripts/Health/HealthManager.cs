using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    private const string _triggerParam = "Result";
    //TODO: this should set in difficulty SO
    [SerializeField] private float sanityDecreaseDelay = 0.2f;
    [SerializeField] private float additionInrease = 10f;
    [SerializeField] private float pillCoolDown = 1f;
    [SerializeField]
    private int urgentPillSanity = 30;
    [SerializeField]
    private int blurStartSanity = 30;
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


    private int sanity;
    private float addiction;
    public Slider healthBar;
    public Slider addictionBar;
    private Coroutine sanityDropCoroutine;



    void Start()
    {
        sanity = 100;
        healthBar.value = sanity;
        addiction = 0f;
        addictionBar.value = addiction;
        sanityDropCoroutine = StartCoroutine(SanityDrop());
    }



    void Update()
    {
        // //sanity -= Time.deltaTime * sanityDecreaseSpeed;
        // healthBar.value = sanity;
        // //pillButton.spriteState = pillButtonStatus;
        // //Lose
        // if (sanity <= 0f)
        // {
        //     EndGame();
        // }
        // else if (sanity < 30f)
        // {
        //     pillButton.image.sprite = urgentPillSprite;
        // }
        // else
        // {
        //     pillButton.image.sprite = regularPillSprite;
        // }

    }

    private IEnumerator SanityDrop()
    {
        sanity = 100;
        pillButton.image.sprite = regularPillSprite;
        while(sanity > 0)
        {
            sanity --;
            healthBar.value = sanity;
            if(sanity == blurStartSanity)
            {
                EffectManager.Instance.RestartBlur();
            }
            if(sanity == blendStartSanity)
            {
                EffectManager.Instance.RestartBlendTexture();
            }
            if(sanity == noiseStartSanity)
            {
                MusicManager.Instance.RestartDrugMode();
            }
            if(sanity == urgentPillSanity)
            {
                pillButton.image.sprite = urgentPillSprite;
            }
            if(sanity <= 0)
            {
                EndGame();
            }
            yield return new WaitForSeconds(sanityDecreaseDelay);
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
        EffectManager.Instance.StopBlend();
        EffectManager.Instance.StopBlur();
        MusicManager.Instance.StopMusicNoise();

        StartCoroutine(PillCoolDown());

        //TODO: addiction increase calue set in difficulty SO
        addiction += additionInrease;
        addictionBar.value = addiction;
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

}
