using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public TimeMonitor TimeMonitor {get; set;}

    // Start is called before the first frame update
    void Start()
    {
        TimeMonitor = GetComponentInChildren<TimeMonitor>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
