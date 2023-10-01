using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    private const string _triggerParam = "Result";
    [SerializeField] private float sanityDecreaseSpeed = 5f;
    [SerializeField] private float additionInrease = 10f;
    [SerializeField]
    private Button pillButton;
    [SerializeField]
    private Sprite urgentPillSprite;
    [SerializeField]
    private Sprite regularPillSprite;


    private float sanity;
    private float addiction;
    public Slider healthBar;
    public Slider addictionBar;



    void Start()
    {

        sanity = 100f;
        healthBar.value = sanity;
        addiction = 0f;
        addictionBar.value = addiction;
        EffectManager.Instance.StartBlur();
        EffectManager.Instance.StartBlendTexture();
        MusicManager.Instance.StartDrugMode();
    }



    void Update()
    {
        sanity -= Time.deltaTime * sanityDecreaseSpeed;
        healthBar.value = sanity;
        //pillButton.spriteState = pillButtonStatus;
        //Lose
        if (sanity <= 0f)
        {
            EndGame();
        }
        else if (sanity < 30f)
        {
            pillButton.image.sprite = urgentPillSprite;
        }
        else
        {
            pillButton.image.sprite = regularPillSprite;
        }

    }

    //private IEnumerator LoseSanity()

    public void TakePill()
    {
        sanity = 100f;
        addiction += additionInrease;
        addictionBar.value = addiction;
        EffectManager.Instance.RestartBlur();
        EffectManager.Instance.RestartBlendTexture();
        MusicManager.Instance.RestartDrugMode();

        //Lose
        if(addiction >= 100f)
        {
            EndGame();
        }
    }

    public void EndGame()
    {
        GameFlow.Instance.Control.SetTrigger(_triggerParam);
    }

}
