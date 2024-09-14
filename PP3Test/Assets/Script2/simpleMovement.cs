using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class simpleMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed = 5f;
    //public InputAction ballControll;
    //public InputAction Sliders;
    public PlayerControllsTest playerControll;
    private InputAction move;
    private InputAction Slider;
    private InputAction Slider2;
    private InputAction DeactivateAll;
    private InputAction AllRed;
    private InputAction AllOrange;
    private InputAction AllGreen;
    public AnotherLightScript LightScript;

    


    Vector2 moveDirection = Vector2.zero;
    private float sliderX = 1f;
    private float sliderY = 1f;
    [SerializeField]
    private float Size = 1f;
    //private int activated = 0;

    private void Awake()
    {
        playerControll = new PlayerControllsTest();
    }

    private void OnEnable()
    {
       // ballControll.Enable();
       // Sliders.Enable();
        move = playerControll.APCMovement.MidiMove;
        move.Enable();
        Slider = playerControll.APCSliders.Slider9;
        Slider.Enable();
        Slider2 = playerControll.APCSliders.Slider8;
        Slider2.Enable();
        DeactivateAll = playerControll.APCMisc.Volume;
        DeactivateAll.Enable();
        AllRed = playerControll.APCMisc.Pan;
        AllRed.Enable();
        AllOrange = playerControll.APCMisc.Send;
        AllOrange.Enable();
        AllGreen = playerControll.APCMisc.Device;
        AllGreen.Enable();


    }

    private void OnDisable()
    {
        move.Disable();
        Slider.Disable();
        Slider2.Disable();
        DeactivateAll.Disable();
        AllRed.Disable();
        AllOrange.Disable();
        AllGreen.Disable();
       // ballControll.Disable(); 
      //  Sliders.Disable(); 

    }

    // Update is called once per frame
    void Update()
    {
        //moveDirection = ballControll.ReadValue<Vector2>();
        sliderX = Slider.ReadValue<float>();
        sliderY = Slider2.ReadValue<float>();
        moveDirection = move.ReadValue<Vector2>();
        //activated = DeactivateAll.ReadValue<int>();

        if (DeactivateAll.triggered)
        {
            LightScript.DeactivateAll();
            Debug.Log("deactivate all has triggered");
        }
        if (AllRed.triggered)
        {
            LightScript.AllRed();
        }
        if (AllOrange.triggered)
        {
            LightScript.AllOrange();
        }
        if (AllGreen.triggered)
        {
            LightScript.AllGreen();
        }

        
        transform.localScale = new Vector3(sliderX + Size, sliderY + Size, 1);
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);

    }


}
