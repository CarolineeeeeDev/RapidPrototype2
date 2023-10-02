using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{

#region singleton
    public static EffectManager Instance;
    private void Awake() 
    {
        if(Instance == null) { Instance = this;}
        else { Destroy(this); }     
    }
#endregion
    [SerializeField]
    private BlurEffect blurEffect;
    [SerializeField]
    private BlendEffect blendEffect;


    private void Start() 
    {

        
    }

    public void RestartBlur(float blurSpeed)
    {
        if(blurEffect == null) { return; }
        blurEffect.RestartBlur(blurSpeed);
    }

    public void StopBlur()
    {
        blurEffect.StopBlur();
    }
    public void RestartBlendTexture(float opacityDecreaseSpeed)
    {
        if(blendEffect == null) { return; }
        blendEffect.RestartBlendTexture(opacityDecreaseSpeed);
    }

    public void StopBlend()
    {
        blendEffect.StopBlend();
    }

}
