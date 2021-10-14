using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SetVolume : MonoBehaviour
{
    //Audio
    public AudioMixer audioMixer;

    // Volumes
    public void SetMasterVolume(float volume)
    {
        audioMixer.SetFloat("MasterVolume", Mathf.Log10(volume) * 20);
    }

    public void SetAmbienceVolume(float volume)
    {
        audioMixer.SetFloat("AmbienceVolume", Mathf.Log10(volume) * 20);
    }

    public void SetNarrativeVolume(float volume)
    {
        audioMixer.SetFloat("NarrativeVolume", Mathf.Log10(volume) * 20);
    }

    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("MusicVolume", Mathf.Log10(volume) * 20);
    }

}
