using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private float sanityDecreaseSpeed = 5f;
    [SerializeField] private float additionInrease = 10f;
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
        MusicManager.Instance.StartDrugMode();
    }



    void Update()
    {
        sanity -= Time.deltaTime * sanityDecreaseSpeed;
        healthBar.value = sanity;

        //Lose
        if (sanity <= 0f)
        {

        }

    }

    //private IEnumerator LoseSanity()

    public void TakePill()
    {
        sanity = 100f;
        addiction += additionInrease;
        addictionBar.value = addiction;
        EffectManager.Instance.RestartBlur();
        MusicManager.Instance.RestartDrugMode();

        //Lose
        if(addiction >= 100f)
        {

        }
    }
}
