using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlurEffect : MonoBehaviour
{
    [SerializeField] 
    private Material blurMaterial;
    [SerializeField]
    private float blurSpeed = 0.001f;

    private float blurAmountX;
    private float blurAmountY;

    private Coroutine blurCoroutine;

    private void Update() 
    {
        //Test
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                ModifyUIBlur(blurSpeed, blurSpeed);
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                ResetBlur();
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                if(blurCoroutine != null ) 
                { 
                    ResetBlur();
                    StopCoroutine(blurCoroutine); 
                }
                blurCoroutine = StartCoroutine(StartBlur());
            }
            if (Input.GetKeyDown(KeyCode.P))
            {
                if(blurCoroutine != null ) 
                { 
                    ResetBlur();
                    StopCoroutine(blurCoroutine); 
                }
            }
        }
    }

    private IEnumerator StartBlur()
    {
        while(true)
        {
            ModifyUIBlur(blurSpeed, blurSpeed);
            yield return new WaitForSeconds(0.05f);
        }
    }

    public void ModifyUIBlur(float blurXToAdd, float blurYToAdd)
    {
        float x = blurMaterial.GetFloat("_BlurAmountX");
        float y = blurMaterial.GetFloat("_BlurAmountY");
        blurMaterial.SetFloat("_BlurAmountX", x + blurXToAdd);
        blurMaterial.SetFloat("_BlurAmountY", y + blurYToAdd);
    }

    public void ResetBlur()
    {
        blurMaterial.SetFloat("_BlurAmountX", 0);
        blurMaterial.SetFloat("_BlurAmountY", 0);
    }

}
