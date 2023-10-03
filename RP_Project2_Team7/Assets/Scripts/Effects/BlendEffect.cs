using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlendEffect : MonoBehaviour
{
    [SerializeField]
    private List<Material> blendMaterials;

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
    }

    public void AddBlend(float addAmount)
    {
        foreach (var mat in blendMaterials)
        {
            float opacity = mat.GetFloat("_Opacity");
            if(opacity - addAmount >= 0.5)
            {
                mat.SetFloat("_Opacity", opacity - addAmount);
            }
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
