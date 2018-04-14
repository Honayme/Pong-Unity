using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundVolume : MonoBehaviour {

    public Slider volumeSlider;
    public AudioSource volumeAudioMenu;
    public AudioSource volumeAudioBackground;


    public void VolumeController()
    {
        volumeAudioMenu.volume = volumeSlider.value;
        volumeAudioBackground.volume = volumeSlider.value;
    }

    public void Update()
    {
        VolumeController();
    }

}
