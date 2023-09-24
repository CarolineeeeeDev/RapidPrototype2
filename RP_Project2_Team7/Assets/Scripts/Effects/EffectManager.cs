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
    private Coroutine blurCoroutine;


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
