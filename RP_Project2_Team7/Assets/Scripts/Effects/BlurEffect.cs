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
    private float stageTwoMaxBlur = 0.2f;
    [SerializeField]
    private float stageOneMaxBlur = 0.0025f;

    private float blurAmountX;
    private float blurAmountY;

    private Coroutine blurCoroutine;
    private Coroutine blurStageTwoCoroutine;

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

    public void StartBlurTwo(float blurSpeed)
    {
        blurCoroutine = StartCoroutine(StartBlurCoroutine(blurSpeed, stageTwoMaxBlur));
    }
    public void StartBlurOne(float blurSpeed)
    {
        blurCoroutine = StartCoroutine(StartBlurCoroutine(blurSpeed, stageOneMaxBlur));
    }

    public void RestartStageOneBlur(float blurSpeed)
    {
        StopBlur(false);
        StartBlurOne(blurSpeed);
    }
    public void RestartStageTwoBlur(float blurSpeed)
    {
        StopBlur(true);
        StartBlurTwo(blurSpeed);
    }

    private IEnumerator StartBlurCoroutine(float blurSpeed, float maxBlur)
    {
        while(true)
        {
            ModifyUIBlur(blurSpeed, maxBlur);
            yield return new WaitForSeconds(0.05f);
        }
    }

    private IEnumerator StartStageTwoBlurCoroutine(float blurSpeed)
    {
        while(true)
        {
            ModifyUIBlur(blurSpeed, stageTwoMaxBlur);
            yield return new WaitForSeconds(0.05f);
        }
    }

    private void ModifyUIBlur(float blurXToAdd, float maxBlur)
    {
        
        float x = blurMaterial.GetFloat("_BlurAmountX");
        var add = math.min(x + blurXToAdd, maxBlur);
        blurMaterial.SetFloat("_BlurAmountX", add);
    }

    public void StopBlur(bool shouldReset)
    {
        if(blurCoroutine != null ) 
        { 
            if(!shouldReset)
            {
                ResetBlur();
            }
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
