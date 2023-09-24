using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    public static EffectManager Instance;

    [SerializeField]
    private BlurEffect blurEffect;
    private Coroutine blurCoroutine;

#region singleton
    private void Awake() 
    {
        if(Instance == null) { Instance = this;}
        else { Destroy(this); }     
    }
#endregion

    private void Start() 
    {

        
    }

    public void StartBlur()
    {
        if(blurEffect == null) { return; }
        blurEffect.StartBlur();
    }

    public void RestartBlur()
    {
        if(blurEffect == null) { return; }
        blurEffect.RestartBlur();
    }

}
