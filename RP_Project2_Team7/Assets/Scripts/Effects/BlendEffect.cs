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
        float opacity = 10f;
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

    private void ResetBlend()
    {
        foreach (var mat in blendMaterials)
        {
            mat.SetFloat("_Opacity", 10);
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
