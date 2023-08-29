using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource; 
    public AudioClip audioClip;
    // private float globalVolume = 1f;
    [SerializeField] Slider volumeSlider;

    void Start(){
        if(!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
            Load();
        }
        else
        {
            Load();
        }
    }
    
    public void playSound() {
        audioSource.clip = audioClip;
        audioSource.Play();
    }

    public void stopSound(){
        audioSource.Stop();
    }
    public void changeVolume(){

        AudioListener.volume = volumeSlider.value;
        Save();

        
    } 
    private void Load(){
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");

    }
    private void Save(){
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }

}
