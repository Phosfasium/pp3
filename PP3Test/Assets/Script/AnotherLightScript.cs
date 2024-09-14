using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Common;
using Melanchall.DryWetMidi.Multimedia;
using System.Linq;

public class AnotherLightScript : MonoBehaviour
{
    // Start is called before the first frame update

    private OutputDevice outputDevice;
    private const string APCMiniName = "APC MINI"; // The exact name of your APC Mini
   

    void Start()
    {
        // Find the APC Mini as the output device
        outputDevice = OutputDevice.GetAll().FirstOrDefault(device => device.Name == APCMiniName);

        if (outputDevice == null)
        {
            Debug.LogError("APC Mini not found!");
            return;
        }
        else
        {
            // deactivate all lights at start of use
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    SetGridButtonLight(i, j, 0);
                }
            }
        }
       
    }

    public void SetGridButtonLight(int x, int y, int color)
    {
        // APC Mini uses notes 0-63 for grid buttons
        int note = GetNoteFromGridPosition(x, y);

        if (note != -1)
        {
            // Send a MIDI Note On message with the color as velocity
            var noteOnEvent = new NoteOnEvent((SevenBitNumber)note, (SevenBitNumber)color);
            Debug.Log(outputDevice);
            Debug.Log(noteOnEvent);
            outputDevice.SendEvent(noteOnEvent);
            //Debug.Log($"Sent Note On: Button ({x},{y}) - Note: {note}, Color: {color}");
        }
        else
        {
           // Debug.LogError($"Invalid grid position ({x},{y})");
        }
    }

    int GetNoteFromGridPosition(int x, int y)
    {
        // This is based on the APCMini.GridMapping, adjust this mapping if needed
        int[,] gridMapping = new int[,]
        {
            { 0, 8, 16, 24, 32, 40, 48, 56 },
            { 1, 9, 17, 25, 33, 41, 49, 57 },
            { 2, 10, 18, 26, 34, 42, 50, 58 },
            { 3, 11, 19, 27, 35, 43, 51, 59 },
            { 4, 12, 20, 28, 36, 44, 52, 60 },
            { 5, 13, 21, 29, 37, 45, 53, 61 },
            { 6, 14, 22, 30, 38, 46, 54, 62 },
            { 7, 15, 23, 31, 39, 47, 55, 63 }
        };

        if (x >= 0 && x < gridMapping.GetLength(0) && y >= 0 && y < gridMapping.GetLength(1))
        {
            return gridMapping[x, y]; // Return the note number corresponding to grid position
        }

        return -1; // Invalid position
    }

    void OnDestroy()
    {
        // Dispose the device on exit
        if (outputDevice != null)
        {
            outputDevice.Dispose();
        }
    }

    public void DeactivateAll()
    {

        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                SetGridButtonLight(i, j, 0);
            }
        }

    }
    public void AllRed()
    {

        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                SetGridButtonLight(i, j, 3);
            }
        }

    }

    public void AllOrange()
    {

        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                SetGridButtonLight(i, j, 5);
            }
        }

    }

    public void AllGreen()
    {

        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                SetGridButtonLight(i, j, 1);
            }
        }

    }
}