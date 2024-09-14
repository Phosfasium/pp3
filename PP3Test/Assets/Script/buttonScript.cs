using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Playables;
using UnityEngine.UI;

public class buttonScript : MonoBehaviour
{
    public int LightX = 0;
    public int LightY = 0;
    public int LightLevel = 0;
    public InputAction ButtonTrigger = null;
    public AnotherLightScript LightScript;
    private bool buttonPressed = false;
    public GameObject newButton;
    public PlayerControllsTest playerControll;
    private InputAction DeactivateAll;
    private InputAction AllRed;
    private InputAction AllOrange;
    private InputAction AllGreen;

    // Start is called before the first frame update
    private void Awake()
    {
        playerControll = new PlayerControllsTest();
    }

    void OnEnable()
    {

        ButtonTrigger.Enable();
        DeactivateAll = playerControll.APCMisc.Volume;
        DeactivateAll.Enable();
        AllRed = playerControll.APCMisc.Pan;
        AllRed.Enable();
        AllOrange = playerControll.APCMisc.Send;
        AllOrange.Enable();
        AllGreen = playerControll.APCMisc.Device;
        AllGreen.Enable();
    }

    void OnDisable()
    {
        ButtonTrigger.Disable();
        DeactivateAll.Disable();
        AllRed.Disable();
        AllOrange.Disable();
        AllGreen.Disable();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        
        if (ButtonTrigger.ReadValue<float>() == 1 && buttonPressed == false )
        {
            buttonPressed = true;
            switch (LightLevel)
            {
                case 0:
                    LightLevel = LightLevel + 1;
                    LightScript.SetGridButtonLight(LightX, LightY, LightLevel);
                    newButton.GetComponent<Image>().color = Color.green;
                    break;
                case 1:
                    LightLevel = LightLevel + 2;
                    LightScript.SetGridButtonLight(LightX, LightY, LightLevel);
                    newButton.GetComponent<Image>().color = Color.red;
                    break;
                case 3:
                    LightLevel = LightLevel + 2;
                    LightScript.SetGridButtonLight(LightX, LightY, LightLevel);
                    newButton.GetComponent<Image>().color = Color.yellow;
                    break;
                case 5:
                    LightLevel = 0;
                    LightScript.SetGridButtonLight(LightX, LightY, LightLevel);
                    newButton.GetComponent<Image>().color = Color.white;
                    break;
            }
            
        }

        if (ButtonTrigger.ReadValue<float>() == 0 && buttonPressed == true)
        {

            buttonPressed = false;
            Debug.Log ("button released");

        }

        if (DeactivateAll.triggered)
        {
            LightLevel = 0;
            LightScript.SetGridButtonLight(LightX, LightY, LightLevel);
            newButton.GetComponent<Image>().color = Color.white;
        }
        if (AllRed.triggered)
        {
            LightLevel = 3;
            LightScript.SetGridButtonLight(LightX, LightY, LightLevel);
            newButton.GetComponent<Image>().color = Color.red;
        }
        if (AllOrange.triggered)
        {
            LightLevel = 5;
            LightScript.SetGridButtonLight(LightX, LightY, LightLevel);
            newButton.GetComponent<Image>().color = Color.yellow;
        }
        if (AllGreen.triggered)
        {
            LightLevel = 1;
            LightScript.SetGridButtonLight(LightX, LightY, LightLevel);
            newButton.GetComponent<Image>().color = Color.green;
        }

    }
    public void mousepressed()
    {
        switch (LightLevel)
        {
            case 0:
                LightLevel = LightLevel + 1;
                LightScript.SetGridButtonLight(LightX, LightY, LightLevel);
                newButton.GetComponent<Image>().color = Color.green;
                break;
            case 1:
                LightLevel = LightLevel + 2;
                LightScript.SetGridButtonLight(LightX, LightY, LightLevel);
                newButton.GetComponent<Image>().color = Color.red;
                break;
            case 3:
                LightLevel = LightLevel + 2;
                LightScript.SetGridButtonLight(LightX, LightY, LightLevel);
                newButton.GetComponent<Image>().color = Color.yellow;
                break;
            case 5:
                LightLevel = 0;
                LightScript.SetGridButtonLight(LightX, LightY, LightLevel);
                newButton.GetComponent<Image>().color = Color.white;
                break;
        }


    }
}
