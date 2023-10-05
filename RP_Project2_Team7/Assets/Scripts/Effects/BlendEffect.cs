using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlendEffect : MonoBehaviour
{
    [SerializeField]
    private List<Material> blendMaterials;
    [SerializeField]
    private List<Image> blendImages;

    private Coroutine blendTextureCoroutine;

    //[SerializeField]
    //private float opacityDecreaseSpeed;
    public void RestartBlendTexture(float opacityDecreaseSpeed)
    {
        if(blendTextureCoroutine != null)
        {
            StopCoroutine(blendTextureCoroutine);
            blendTextureCoroutine = null;
        }
        blendTextureCoroutine = StartCoroutine(BlendTextureCoroutine(opacityDecreaseSpeed));
    }

    private IEnumerator BlendTextureCoroutine(float opacityDecreaseSpeed)
    {
        float opacity = 8f;
        while(opacity >= 0.5)
        {
            foreach (var mat in blendMaterials)
            {
                mat.SetFloat("_Opacity", opacity);
            }
            opacity -= opacityDecreaseSpeed;
            Color blueColor = new Color(0,0,5);
            foreach (var img in blendImages)
            {
                
                img.color += blueColor;
            }
            yield return new WaitForSeconds(0.1f);
        }
        yield return null;
    }

    public void ResetBlend()
    {
        foreach (var mat in blendMaterials)
        {
            mat.SetFloat("_Opacity", 8);
        }
        foreach (var img in blendImages)
        {
            img.color = Color.white;
        }
    }

    public void AddBlend(float addAmount, float uiAddAmount)
    {
        foreach (var mat in blendMaterials)
        {
            float opacity = mat.GetFloat("_Opacity");
            if(opacity - addAmount >= 0.5)
            {
                mat.SetFloat("_Opacity", opacity - addAmount);
            }
        }
        foreach (var img in blendImages)
        {
            Color blueColor = img.color;
            blueColor.a = blueColor.a - uiAddAmount;
            img.color = blueColor;
        }
    }

    public void StopBlend()
    {
        ResetBlend();
        if(blendTextureCoroutine != null)
        {
            StopCoroutine(blendTextureCoroutine);
            blendTextureCoroutine = null;
        }
    }

    private void OnDestroy() 
    {
        ResetBlend();
    }
}
