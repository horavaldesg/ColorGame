using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentWall : MonoBehaviour
{
    public Vector3 parentRotation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        parentRotation = this.transform.rotation.eulerAngles;
        Debug.Log(gameObject.transform.localEulerAngles);
    }
}
