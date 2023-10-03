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

    public void RestartStageOneBlur(float blurSpeed)
    {
        if(blurEffect == null) { return; }
        blurEffect.RestartStageOneBlur(blurSpeed);
    }
    public void RestartStageTwoBlur(float blurSpeed)
    {
        if(blurEffect == null) { return; }
        blurEffect.RestartStageTwoBlur(blurSpeed);
    }

    public void StopBlur()
    {
        blurEffect.StopBlur(false);
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
