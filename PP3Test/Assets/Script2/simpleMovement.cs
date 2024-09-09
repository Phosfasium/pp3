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
    private Transform sizeChange; 
    private InputAction move;
    private InputAction Slider;
    private InputAction Slider2;


    Vector2 moveDirection = Vector2.zero;
    private float sliderX = 1f;
    private float sliderY = 1f;

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

       
    }

    private void OnDisable()
    {
        move.Disable();
        Slider.Disable();
        Slider2.Disable();

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
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
        transform.localScale = new Vector3(sliderX + 1, sliderY + 1, 1);
    }


}
