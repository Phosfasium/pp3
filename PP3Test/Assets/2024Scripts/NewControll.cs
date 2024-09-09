using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewControll : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed = 5f;
    private Transform sizeChange;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnReset(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            transform.position = new Vector2(0,0);
        }
    }
}
