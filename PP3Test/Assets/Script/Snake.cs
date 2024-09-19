using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class Snake : MonoBehaviour
{
    private Vector2 _moveDirection = Vector2.zero;
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

    public Rigidbody2D rb;
    public PlayerControllsTest playerControll;
    public AnotherLightScript LightScript;
    public food Food;
    public GameObject SquarePrefab;
    private bool globalControll = true;

    [Header("gridmovment")]
    public bool TargetReached = true;
    private Transform PlayerTransform;
    public Transform TargetTransform = null;
    private bool xFirst;

    //[Header("Timer")]
    //private float timer = 0;
    //[SerializeField]
    //private float timeUntilMove = 0.5f;


    private void Awake()
    {
        playerControll = new PlayerControllsTest();
        PlayerTransform = transform;

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
        Debug.Log(TargetTransform.position);



        if (globalControll == true)
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
                globalControll = true;
                TargetReached = true;
                TargetTransform = PlayerTransform;
            }

        }


        if (globalControll)
        {
            if (PlayerTransform.position != TargetTransform.position && TargetReached == false )
            {
                if (xFirst)
                {
                    if ((Mathf.Abs(PlayerTransform.position.x - TargetTransform.position.x)) > (Mathf.Abs(PlayerTransform.position.y - TargetTransform.position.y)))
                    {

                        if (PlayerTransform.position.x < TargetTransform.position.x)
                        {

                            _moveDirection = Vector2.right;
                        }
                        else
                        {

                            _moveDirection = Vector2.left;
                        }
                    }
                    else if ((Mathf.Abs(PlayerTransform.position.x - TargetTransform.position.x)) <= (Mathf.Abs(PlayerTransform.position.y - TargetTransform.position.y)))
                    {
                        if (PlayerTransform.position.y < TargetTransform.position.y)
                        {

                            _moveDirection = Vector2.up;

                        }
                        else
                        {

                            _moveDirection = Vector2.down;
                        }
                    }
                }

                else if (!xFirst)
                {
                    if ((Mathf.Abs(PlayerTransform.position.x - TargetTransform.position.x)) >= (Mathf.Abs(PlayerTransform.position.y - TargetTransform.position.y)))
                    {

                        if (PlayerTransform.position.x < TargetTransform.position.x)
                        {

                            _moveDirection = Vector2.right;
                        }
                        else
                        {

                            _moveDirection = Vector2.left;
                        }
                    }
                    else if ((Mathf.Abs(PlayerTransform.position.x - TargetTransform.position.x)) < (Mathf.Abs(PlayerTransform.position.y - TargetTransform.position.y)))
                    {
                        if (PlayerTransform.position.y < TargetTransform.position.y)
                        {

                            _moveDirection = Vector2.up;

                        }
                        else
                        {

                            _moveDirection = Vector2.down;
                        }
                    }
                }
                
            }

        }


        if (PlayerTransform.position == TargetTransform.position)
        {
            TargetReached = true;
            TargetTransform = PlayerTransform;
            //Debug.Log("targetReached");
        }

        //timer += Time.deltaTime;
        //if (timer >= timeUntilMove)
        //{
        //    for (int i = _segments.Count - 1; i > 0; i--)
        //    {
        //        _segments[i].position = _segments[i - 1].position;
        //    }



        //    this.transform.position = new Vector3(
        //    Mathf.Round(this.transform.position.x) + _moveDirection.x,
        //    Mathf.Round(this.transform.position.y) + _moveDirection.y,
        //    0.0f
        //    );

        //    timer = 0;
        //}
    }

    public void setTransform(Transform GridSquareSelected)
    {
        TargetTransform = GridSquareSelected;
        TargetReached = false;
        Debug.Log(TargetTransform.position.x);
        if ((Mathf.Abs(PlayerTransform.position.x - TargetTransform.position.x)) >= (Mathf.Abs(PlayerTransform.position.y - TargetTransform.position.y)))
        {
            xFirst = true;
            
        }
        else
        {
            xFirst = false;
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
        globalControll = false;
        _segments.Clear();
        _segments.Add(this.transform);
    }
}
