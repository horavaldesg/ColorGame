using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VCAController : MonoBehaviour
{
    private FMOD.Studio.VCA vca;
    public string vcaName;

    private Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        vca = FMODUnity.RuntimeManager.GetVCA("vca:/" + vcaName);
        slider = GetComponent<Slider>();
    }

    public void SetVol(float volume)
    {
        vca.setVolume(volume);
    }
}
