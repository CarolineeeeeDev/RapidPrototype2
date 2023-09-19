using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField]
    private AudioClip musicBase;
    [SerializeField]
    private AudioClip musicNormal;
    [SerializeField]
    private AudioClip musicNoise;

    [SerializeField]
    private Sanity sanity;

    private AudioSource baseAudioSource;
    private AudioSource normalAudioSource;
    private AudioSource noiseAudioSource;

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

    private void PlayMusic(AudioSource sourceToPlay)
    {
        if(sourceToPlay.clip == null) { return; }

        sourceToPlay.Play();
    }

    private void Update() 
    {
        float newSpeed = 2 - (sanity.san * 0.01f);
        if(newSpeed <= 1.25f) { newSpeed = 1; }
        baseAudioSource.pitch = newSpeed;
        normalAudioSource.pitch = newSpeed;
        noiseAudioSource.pitch = newSpeed;

        float newVolume = 0.75f - (sanity.san * 0.01f);
        normalAudioSource.volume = 1 - newVolume;
        noiseAudioSource.volume = newVolume;
    }

   /*  private void AddSpeed(float speedToAdd)
    {
        baseAudioSource.pitch += speedToAdd;
        normalAudioSource.pitch += speedToAdd;
        noiseAudioSource.pitch += speedToAdd;
    }

    private IEnumerator DrugMode(float length)
    {
        
        yield return null;
    } */
}
