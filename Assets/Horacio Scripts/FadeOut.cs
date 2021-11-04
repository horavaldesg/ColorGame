using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOut : MonoBehaviour
{
    MeshRenderer meshRenderer;
    Color color;
    float decreaseColorValue = 0;
    float intensity;
    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        color = meshRenderer.material.color;
        //descreaseColorValue = color.a;
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if(decreaseColorValue > -2)
        {
            decreaseColorValue -= Time.deltaTime * 0.01f;
            //color.a = descreaseColorValue;
            decreaseColorValue -= Time.deltaTime * 0.01f;
            meshRenderer.material.SetColor("_EmissionColor", color * decreaseColorValue);
        }

        Debug.Log(decreaseColorValue);
        */
    }
}
