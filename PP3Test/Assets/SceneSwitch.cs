using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class SceneSwitch : MonoBehaviour
{
    private InputAction next;
    private InputAction prev;
    private InputAction Select;
    PlayerControllsTest playerControll;
    private int currentSceneIndex;


    private void Awake()
    {
        playerControll = new PlayerControllsTest();
    }
    private void OnEnable()
    {
        next = playerControll.APCMisc.ClipStop;
        next.Enable();
        prev = playerControll.APCMisc.Solo;
        prev.Enable();
        Select = playerControll.APCMisc.RecArm;
        Select.Enable();
    }

    private void OnDisable()
    {
        next.Disable();
        prev.Disable();
        Select.Disable();
    }



    // Start is called before the first frame update
    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    private void Update()
    {
        if (next.triggered)
        {
            NextScene();
        }

        if (prev.triggered)
        {
            PreviousScene();
        }
    }
    private void NextScene()
    {
        Debug.Log("nextScene");
        currentSceneIndex++;
        if (currentSceneIndex >= SceneManager.sceneCountInBuildSettings)
        {
            currentSceneIndex = 0;  // Loop back to the first scene if it's the last one
        }
        SceneManager.LoadScene(currentSceneIndex);
    }

    private void PreviousScene()
    {
        currentSceneIndex--;
        if (currentSceneIndex < 0)
        {
            currentSceneIndex = SceneManager.sceneCountInBuildSettings - 1;  // Loop back to the last scene
        }
        SceneManager.LoadScene(currentSceneIndex);
    }
}
