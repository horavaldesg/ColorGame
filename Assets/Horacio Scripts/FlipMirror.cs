using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipMirror : MonoBehaviour
{
    Transform rot;

    //Audio
    [FMODUnity.EventRef]
    public string mirrorPhase;

    //public GameObject room1;
    // Start is called before the first frame update
    void Start()
    {
        rot = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /*
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision " + rot.transform.localEulerAngles.y);
        
            rot.rotation = Quaternion.Euler(rot.localEulerAngles.x, rot.localEulerAngles.y - 180, rot.localEulerAngles.z);
            room1.SetActive(!room1.activeSelf);
        
        
    }
    */
    private void OnTriggerEnter(Collider other)
    {
        //rot.rotation = Quaternion.Euler(rot.localEulerAngles.x, rot.localEulerAngles.y - 180, rot.localEulerAngles.z);
        //room1.SetActive(!room1.activeSelf);
        PlayMirror(mirrorPhase);

    }

    void PlayMirror(string path)
    {
        FMOD.Studio.EventInstance MirrorPhase = FMODUnity.RuntimeManager.CreateInstance(path);
        MirrorPhase.start();
        MirrorPhase.release();

    }
}
