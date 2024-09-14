using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seeColour : MonoBehaviour
{
    public AnotherLightScript LightScript;
    public int LightX = 0;
    public int LightY = 0;
    public int LightLevel = 0;
    // Start is called before the first frame update
    private bool isGreen = false;
    private bool isRed = false;
    private bool isYellow = false;

    private void LateUpdate()
    {
        isGreen = false;
        isRed = false;
        isYellow = false;


    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isGreen = true;
           LightScript.SetGridButtonLight(LightX, LightY, 1);
           GetComponent<SpriteRenderer>().color = Color.green;
        }

        if (collision.CompareTag("Red"))
        {
            isRed = true;
            LightScript.SetGridButtonLight(LightX, LightY, 3);
            GetComponent<SpriteRenderer>().color = Color.red;
        }

        if (collision.CompareTag("Yellow"))
        {
            isYellow = true;
            LightScript.SetGridButtonLight(LightX, LightY, 5);
            GetComponent<SpriteRenderer>().color = Color.yellow;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!isGreen && !isRed && !isYellow)
        {
            if (collision.CompareTag("Player"))
            {
                LightScript.SetGridButtonLight(LightX, LightY, 0);
                GetComponent<SpriteRenderer>().color = Color.white;
            }
        }

        if (!isGreen && !isRed && !isYellow)
        {
            if (collision.CompareTag("Red"))
            {
                LightScript.SetGridButtonLight(LightX, LightY, 0);
                GetComponent<SpriteRenderer>().color = Color.white;
            }

        }

        if (!isGreen && !isRed && !isYellow)
        {
            if (collision.CompareTag("Yellow"))
            {
                LightScript.SetGridButtonLight(LightX, LightY, 0);
                GetComponent<SpriteRenderer>().color = Color.white;
            }
        }


    }


}
