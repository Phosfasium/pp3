using UnityEngine;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Multimedia;
using Melanchall.DryWetMidi.Common;

public class LightController : MonoBehaviour
{
    [SerializeField]
    private OutputDevice outputDevice;
    [SerializeField]
    private InputDevice inputDevice;

    int[][] GridMapping = {
        new int[] { 0, 8, 16, 24, 32, 40, 48, 56 },
        new int[] { 1, 9, 17, 25, 33, 41, 49, 57 },
        new int[] { 2, 10, 18, 26, 34, 42, 50, 58 },
        new int[] { 3, 11, 19, 27, 35, 43, 51, 59 },
        new int[] { 4, 12, 20, 28, 36, 44, 52, 60 },
        new int[] { 5, 13, 21, 29, 37, 45, 53, 61 },
        new int[] { 6, 14, 22, 30, 38, 46, 54, 62 },
        new int[] { 7, 15, 23, 31, 39, 47, 55, 63 }
    };

    int[] FaderMapping = { 48, 49, 50, 51, 52, 53, 54, 55, 56 };
    int[] SideButtonMapping = { 82, 83, 84, 85, 86, 87, 88, 89 };
    int[] LowerButtonMapping = { 64, 65, 66, 67, 68, 69, 70, 71 };
    int[] ShiftButtonMapping = { 98 };

    void Start()
    {
        // Open output device
        outputDevice = OutputDevice.GetByName("APC MINI");
        outputDevice.EventSent += OnMidiEventSent;

        // Open input device
        inputDevice = InputDevice.GetByName("APC MINI");
        inputDevice.EventReceived += OnMidiEventReceived;
        inputDevice.StartEventsListening();
    }

    void OnMidiEventSent(object sender, MidiEventSentEventArgs e)
    {
        Debug.Log("MIDI Event Sent: " + e.Event);
    }

    void OnMidiEventReceived(object sender, MidiEventReceivedEventArgs e)
    {
        Debug.Log("MIDI Event Received: " + e.Event);
        // Handle incoming MIDI messages here
    }

    public void SetGridButtonLED(int x, int y, int color)
    {
        if (x < 0 || x >= 8 || y < 0 || y >= 8)
            throw new System.ArgumentException("Invalid grid coordinates");

        int note = GridMapping[x][y];
        var noteOnEvent = new NoteOnEvent((SevenBitNumber)note, (SevenBitNumber)color);
        outputDevice.SendEvent(noteOnEvent);
    }

    public void SetFader(int faderId, int value)
    {
        if (faderId < 0 || faderId >= FaderMapping.Length)
            throw new System.ArgumentException("Invalid fader ID");

        int control = FaderMapping[faderId];
        var controlChangeEvent = new ControlChangeEvent((SevenBitNumber)control, (SevenBitNumber)value);
        outputDevice.SendEvent(controlChangeEvent);
    }

    void OnDestroy()
    {
        inputDevice.EventReceived -= OnMidiEventReceived;
        inputDevice.Dispose();

        outputDevice.EventSent -= OnMidiEventSent;
        outputDevice.Dispose();
    }
}
