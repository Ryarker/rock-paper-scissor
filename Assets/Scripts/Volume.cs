using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class Volume : MonoBehaviour
    {
    [SerializeField] Slider volumeSlider;
    [SerializeField] Toggle muteToggle;
    [SerializeField] AudioClip audioClip;

    private AudioSource audioSource;
    private bool isAudioPlaying = false;
    private float audioTime;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = audioClip;
        audioSource.loop = true;
        audioSource.playOnAwake = false;

        volumeSlider.value = PlayerPrefs.GetFloat("Volume", 1f);
        audioSource.volume = volumeSlider.value;

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void Update()
    {
        audioSource.volume = volumeSlider.value;

        if (muteToggle.isOn)
        {
            audioSource.volume = 0;
        }

        PlayerPrefs.SetFloat("Volume", volumeSlider.value);

        if (!isAudioPlaying)
        {
            audioSource.time = audioTime;
            audioSource.Play();
            isAudioPlaying = true;
        }
        else
        {
            audioTime = audioSource.time;
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (!isAudioPlaying)
        {
            audioSource.time = audioTime;
            audioSource.Play();
            isAudioPlaying = true;
        }
        else
        {
            audioTime = audioSource.time;
        }
    }
}


