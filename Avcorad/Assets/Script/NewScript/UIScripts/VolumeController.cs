using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider bgmslider;
    public Slider sfxslider;
    public void SetBgmvolume()
    {
        audioMixer.SetFloat("MusicVolume", Mathf.Log10(bgmslider.value)*20);
    }
    public void SetSfxVolume()
    {
        audioMixer.SetFloat("SfxVolume", Mathf.Log10(sfxslider.value) * 20);
    }
}
