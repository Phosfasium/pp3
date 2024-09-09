using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Multimedia;
using Melanchall.DryWetMidi.Common;

public class ListDevices : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Available Output Devices:");
        foreach (var device in OutputDevice.GetAll())
        {
            Debug.Log("Output device: " + device.Name);
        }

        Debug.Log("Available Input Devices:");
        foreach (var device in InputDevice.GetAll())
        {
            Debug.Log("Input device: " + device.Name);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
