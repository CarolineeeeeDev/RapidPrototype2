using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sanity : MonoBehaviour
{
    public float san;
    public Slider healthbar;
    private Coroutine sanityCouroutine;

    void Start()
    {
        san = 100f;
        healthbar.value = san;
        sanityCouroutine = StartCoroutine(LoseSanity());
    }

    void TakePill()
    {
        if(sanityCouroutine != null) { StopCoroutine(sanityCouroutine); }
        sanityCouroutine = StartCoroutine(LoseSanity());
    }

    void Update()
    {
        san -= Time.deltaTime*5f;
        healthbar.value = san;
        if (san<=0)
        {
            //Lose

        }
    }
    private IEnumerator LoseSanity()
    {
        yield return new WaitForSeconds(0.1f);
        san--;
        
        
        yield return 0;
    }
}
