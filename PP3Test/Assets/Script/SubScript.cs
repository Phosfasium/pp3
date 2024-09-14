using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SubScript : MonoBehaviour
    
{
    public PlayerControllsTest playerControll;
    public AnotherLightScript LightScript;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void CallDeactivateAll(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            Debug.Log("deactivate all lights");
            LightScript.DeactivateAll();
        }
    }
}
