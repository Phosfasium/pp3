using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class food : MonoBehaviour
{

    public BoxCollider2D playArea;
    public Snake Snake;
    public bool positionIsValid;
    private Vector3 newPosition;

    private void Start()
    {
        RandomizePosition();
    }

    public void RandomizePosition()
    {
        Bounds bounds = this.playArea.bounds;
        do
        {

        
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        newPosition = new Vector3(Mathf.Round(x), Mathf.Round(y), 0.0f);

        positionIsValid = true;
            foreach (Transform segment in Snake._segments)
            {
                if (segment.position == newPosition)
                {
                    positionIsValid = false;
                    break;
                }
            }
        } while (!positionIsValid);

        this.transform.position = newPosition;
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            RandomizePosition();

        }
        
    }

}