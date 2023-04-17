using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
   public Slider musicSlider;

   private void Start() {
    if (PlayerPrefs.HasKey("musicVolume"))
    {
        loadVolume();
    }else
    {
        setMusicVolume();
    }
   }

   public void toggleMusic () {
    AudioManager.Instance.toggleMusic();
   }
   public void musicVolume(){
    AudioManager.Instance.musicVolume(musicSlider.value);
   }

   public void setMusicVolume(){
    float volume = musicSlider.value;
    PlayerPrefs.SetFloat("musicVolume", volume);
   }

   private void loadVolume(){
    musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
    setMusicVolume();
   }
}
