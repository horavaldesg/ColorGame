using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CompletedRoom : MonoBehaviour
{
    public static int completed;
    public static int totalRooms;
    TextMeshProUGUI text;
   
    // Start is called before the first frame update
    void Start()
    {
        completed = 0;
        text = GetComponent<TextMeshProUGUI>();
        text.SetText(completed.ToString("Rooms Completed: 0"));
    }

    // Update is called once per frame
    void Update()
    {
        text.SetText(completed.ToString("Rooms Completed: ## /") + totalRooms.ToString());
    }
}
