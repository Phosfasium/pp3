using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class setTarget : MonoBehaviour
{
    public PlayerControllsTest ButtonPress;
    public InputAction Triggered = null;
    private Transform gridSquare;
    public Snake snakeScript;



    private void Awake()
    {
        ButtonPress = new PlayerControllsTest();
        gridSquare = GetComponent<Transform>();
    }

    private void OnEnable()
    {
        Triggered.Enable();
    }

    private void OnDisable()
    {
        Triggered.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Triggered.triggered)
        {
            Debug.Log("triggered");
            snakeScript.setTransform(gridSquare.transform);
        }
    }
}
