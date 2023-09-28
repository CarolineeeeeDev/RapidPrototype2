using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlendEffect : MonoBehaviour
{
    [SerializeField]
    private List<Material> blendMaterials;

    private Coroutine blendTextureCoroutine;

    [SerializeField]
    private float opacityDecreaseSpeed;

    public void StartBlendTexture()
    {
        blendTextureCoroutine = StartCoroutine(BlendTextureCoroutine());
    }
    public void RestartBlendTexture()
    {
        if(blendTextureCoroutine != null)
        {
            StopCoroutine(blendTextureCoroutine);
            blendTextureCoroutine = null;
        }
        blendTextureCoroutine = StartCoroutine(BlendTextureCoroutine());
    }

    private IEnumerator BlendTextureCoroutine()
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

    private void OnDestroy() 
    {
        foreach (var mat in blendMaterials)
        {
            mat.SetFloat("_Opacity", 10);
        }
    }
}
