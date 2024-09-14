using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class Snake : MonoBehaviour
{
    private Vector2 _moveDirection = Vector2.right;
    private bool _gameOver;
    private InputAction Up;
    private InputAction Down;
    private InputAction Left;
    private InputAction Right;
    private InputAction Reset;
    public List<GameObject> squares;

    [SerializeField]
    public List<Transform> _segments;
    public Transform segmentPrefab;

    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public PlayerControllsTest playerControll;
    public AnotherLightScript LightScript;
    public food Food;
    public GameObject SquarePrefab;

    private void Awake()
    {
        playerControll = new PlayerControllsTest();
    }
    private void OnEnable()
    {
        Up = playerControll.APCMovement.Up;
        Up.Enable();
        Down = playerControll.APCMovement.Down;
        Down.Enable();
        Left = playerControll.APCMovement.Left;
        Left.Enable();
        Right = playerControll.APCMovement.Right;
        Right.Enable();
        Reset = playerControll.APCMisc.Shift;
        Reset.Enable();
    }

    private void OnDisable()
    {
        Up.Disable();
        Down.Disable();
        Left.Disable();
        Right.Disable();
    }

    private void Start()
    {
        _segments = new List<Transform>();
        _segments.Add(this.transform);
    }

    private void Update()
    {
        if (Up.triggered)
        {
            _moveDirection = Vector2.up;
        }
        if (Down.triggered)
        {
            _moveDirection = Vector2.down;
                    }
        if (Left.triggered)
        {
            _moveDirection = Vector2.left;
        }
        if (Right.triggered)
        {
            _moveDirection = Vector2.right;
        }
        if (_gameOver == true)
        {
            if (Reset.triggered)
            {
                for (int j = 0; j < squares.Count; j++)
                {
                    squares[j].GetComponent<SpriteRenderer>().color = Color.white;
                }
                LightScript.DeactivateAll();
                this.transform.position = Vector3.zero;
                Food.RandomizePosition();

            }

        }

    }

    private void FixedUpdate()
    {
        for (int i = _segments.Count - 1; i > 0; i--)
        {
            _segments[i].position = _segments[i - 1].position;
        }

        this.transform.position = new Vector3(
            Mathf.Round(this.transform.position.x) + _moveDirection.x,
            Mathf.Round(this.transform.position.y) + _moveDirection.y,
            0.0f
            );
    }

   

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            LightScript.AllRed();
            gameOver();
        }

        if (other.CompareTag("Yellow"))
        {
            LightScript.AllRed();
            gameOver();
        }

        if (other.CompareTag("Wall"))
        {
            LightScript.AllRed();
            gameOver();

        }

        if (other.CompareTag("Red"))
        {
            Grow();
            Debug.Log("NOMNOMNOM");
        }

    }

    private void Grow()
    {
        Transform segment = Instantiate(this.segmentPrefab);
        segment.position = _segments[_segments.Count - 1].position;

        _segments.Add(segment);
    }

    public void gameOver()
    {
        LightScript.AllRed();
        
        _moveDirection = Vector2.zero;
        _gameOver = true;
        for (int i = 1; i < _segments.Count; i++)
        {
            Destroy(_segments[i].gameObject);
        }

        _segments.Clear();
        _segments.Add(this.transform);
    }
}
