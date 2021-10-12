using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateRenderTexture : MonoBehaviour
{
    RenderTexture mirrorTexture;
    Camera cam;
    Renderer matRender;
    public RenderTextureFormat textureFormat;
    Shader shader;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponentInChildren<Camera>();
        matRender = GetComponent<Renderer>();

        mirrorTexture = new RenderTexture(1024, 1024, 24, textureFormat);
        mirrorTexture.Create();
       
        cam.targetTexture = mirrorTexture;
        
        matRender.material = new Material(Shader.Find("Standard"));
        matRender.material.mainTexture = mirrorTexture;
        matRender.material.color = Color.white;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
