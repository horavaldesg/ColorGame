using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InputTextManager : MonoBehaviour
{
    TextMeshProUGUI text;
    public static string inputText;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        text.SetText(inputText);
    }
}
