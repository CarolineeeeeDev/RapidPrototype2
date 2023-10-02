using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
#region singleton
    public static MusicManager Instance;
    private void Awake() 
    {
        if(Instance == null) { Instance = this;}
        else { Destroy(this); }     
    }
#endregion
    
    [SerializeField]
    private AudioClip musicBase;
    [SerializeField]
    private AudioClip musicNormal;
    [SerializeField]
    private AudioClip musicNoise;
    //[SerializeField]
    //private float noiseIncreaseSpeed = 0.05f;
    [SerializeField]
    private AudioSource sfxSource;

    [SerializeField]
    private AudioClip clickButtonSound;
    [SerializeField]
    private AudioClip selectSound;

    private AudioSource baseAudioSource;
    private AudioSource normalAudioSource;
    private AudioSource noiseAudioSource;

    private Coroutine drugModeCoroutine;
    private void Start() 
    {
        baseAudioSource = gameObject.AddComponent<AudioSource>();
        baseAudioSource.Stop();
        baseAudioSource.loop = true;
        baseAudioSource.playOnAwake = false;
        if(musicBase != null) { baseAudioSource.clip = musicBase; }

        normalAudioSource = gameObject.AddComponent<AudioSource>();
        normalAudioSource.Stop();
        normalAudioSource.loop = true;
        normalAudioSource.playOnAwake = false;
        if(musicNormal != null) { normalAudioSource.clip = musicNormal; }
        

        noiseAudioSource = gameObject.AddComponent<AudioSource>();
        noiseAudioSource.Stop();
        noiseAudioSource.loop = true;
        noiseAudioSource.volume = 0;
        noiseAudioSource.playOnAwake = false;
        if(musicNoise != null) { noiseAudioSource.clip = musicNoise; }

        PlayMusic(baseAudioSource);
        PlayMusic(normalAudioSource);
        PlayMusic(noiseAudioSource);
        
    }

    public void PlayClickButton()
    {
        PlaySoundEffect(clickButtonSound);
    }

    public void PlySelectSound()
    {
        PlaySoundEffect(selectSound);
    }

    private void PlaySoundEffect(AudioClip clip)
    {
        if(clip == null) { return; }
        sfxSource.PlayOneShot(clip);
    }

    private void PlayMusic(AudioSource sourceToPlay)
    {
        if(sourceToPlay.clip == null) { return; }

        sourceToPlay.Play();
    }

    public void StartDrugMode(float noiseIncreaseSpeed)
    {
       drugModeCoroutine = StartCoroutine(DrugMode(noiseIncreaseSpeed));
    }

    public void StopMusicNoise()
    {
        baseAudioSource.pitch = 1;
        normalAudioSource.pitch = 1;
        noiseAudioSource.pitch = 1;

        normalAudioSource.volume = 1;
        noiseAudioSource.volume = 0;

        if(drugModeCoroutine != null)
        {
            StopCoroutine(drugModeCoroutine);
            drugModeCoroutine = null;
        }
    }

    public void RestartDrugMode(float noiseIncreaseSpeed)
    {
        StopMusicNoise();
        StartDrugMode(noiseIncreaseSpeed);
    }
    private IEnumerator DrugMode(float noiseIncreaseSpeed)
    {
        var san = 100;
        yield return new WaitForSeconds(2f);
        while(san >= 0)
        {
            float newSpeed = 2 - (san * 0.01f);
            baseAudioSource.pitch = newSpeed;
            normalAudioSource.pitch = newSpeed;
            noiseAudioSource.pitch = newSpeed;

            float newVolume = 0.75f - (san * 0.01f);
            normalAudioSource.volume = 1 - newVolume;
            noiseAudioSource.volume = newVolume;
            san--;
            yield return new WaitForSeconds(1 / noiseIncreaseSpeed);
        }
        yield return null;
    } 
}
