using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateRenderTexture : MonoBehaviour
{
    public RenderTexture mirrorTexture;
    Camera cam;
    Renderer matRender;
    // Start is called before the first frame update
    void Start()
    {
        //mirrorTexture = new RenderTexture(1024, 1024, 24, RenderTextureFormat.R8);
        //mirrorTexture.Create();
        //var rt = new RenderTexture(1024, 1024, 24);
        /*
        RenderTexture newMirror;
        newMirror = Instantiate(mirrorTexture);
        mirrorTexture = newMirror;
        cam = GetComponentInChildren<Camera>();
        cam.targetTexture = mirrorTexture;

        */
        cam = GetComponentInChildren<Camera>();
        cam.targetTexture = mirrorTexture;
        matRender = this.GetComponent<Renderer>();

        this.matRender.material.SetTexture("Albedo", mirrorTexture);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
