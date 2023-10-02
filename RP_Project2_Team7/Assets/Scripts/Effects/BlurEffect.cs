using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class BlurEffect : MonoBehaviour
{
    [SerializeField] 
    private Material blurMaterial;
    // [SerializeField]
    // private float blurSpeed = 0.001f;
    [SerializeField]
    private float maxBlur = 0.2f;

    private float blurAmountX;
    private float blurAmountY;

    private Coroutine blurCoroutine;

    private void Update() 
    {
        // //Test
        // {
        //     if (Input.GetKeyDown(KeyCode.T))
        //     {
        //         ModifyUIBlur(blurSpeed, blurSpeed);
        //     }
        //     if (Input.GetKeyDown(KeyCode.R))
        //     {
        //         ResetBlur();
        //     }
        //     if (Input.GetKeyDown(KeyCode.S))
        //     {
        //         if(blurCoroutine != null ) 
        //         { 
        //             ResetBlur();
        //             StopCoroutine(blurCoroutine); 
        //         }
        //         blurCoroutine = StartCoroutine(StartBlurCoroutine());
        //     }
        //     if (Input.GetKeyDown(KeyCode.P))
        //     {
        //         if(blurCoroutine != null ) 
        //         { 
        //             ResetBlur();
        //             StopCoroutine(blurCoroutine); 
        //         }
        //     }
        // }
    }

    private void Awake() 
    {
        ResetBlur();
    }

    public void StartBlur(float blurSpeed)
    {
        blurCoroutine = StartCoroutine(StartBlurCoroutine(blurSpeed));
    }

    public void RestartBlur(float blurSpeed)
    {
        if(blurCoroutine != null ) 
        { 
            ResetBlur();
            StopCoroutine(blurCoroutine);
            blurCoroutine = null; 
        }
        StartBlur(blurSpeed);
    }

    private IEnumerator StartBlurCoroutine(float blurSpeed)
    {
        while(true)
        {
            ModifyUIBlur(blurSpeed);
            yield return new WaitForSeconds(0.05f);
        }
    }

    private void ModifyUIBlur(float blurXToAdd)
    {
        
        float x = blurMaterial.GetFloat("_BlurAmountX");
        var add = math.min(x + blurXToAdd, maxBlur);
        blurMaterial.SetFloat("_BlurAmountX", add);
    }

    public void StopBlur()
    {
        if(blurCoroutine != null ) 
        { 
            ResetBlur();
            StopCoroutine(blurCoroutine);
            blurCoroutine = null; 
        }
    }

    private void ResetBlur()
    {
        blurMaterial.SetFloat("_BlurAmountX", 0);
    }

    private void OnDestroy() 
    {
        ResetBlur();
    }

}
