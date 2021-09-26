using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRenderTexture : MonoBehaviour
{
    Camera camera;
    RenderTexture rt;
    // Start is called before the first frame update
    void Start()
    {
        //var rt = new RenderTexture(1024, 1024, 24, RenderTextureFormat.R8);
        //rt.Create();
        rt = GetComponentInParent<CreateRenderTexture>().mirrorTexture;
        camera = GetComponent<Camera>();
        this.camera.targetTexture = rt;
        Debug.Log(this.gameObject.name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
