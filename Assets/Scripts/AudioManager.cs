using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    [SerializeField] Sound[] musicSounds;
    [SerializeField] AudioSource musicSource;
    
    private void Awake() {
        if(Instance == null)
        {
            Instance =  this;
            DontDestroyOnLoad(gameObject);

        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start() {
        playMusic("Theme");
    }
   
   public void playMusic (string name) {
    Sound s = Array.Find(musicSounds, x => x.name == name);
    if(s == null)
    {
        Debug.Log("Sound not found!");
    }
    else
    {
        musicSource.clip = s.clip;
        musicSource.Play();
    }
   }

   public void toggleMusic(){
    musicSource.mute = !musicSource.mute;
   }
   public void musicVolume (float volume) {
    musicSource.volume = volume;
   }
}