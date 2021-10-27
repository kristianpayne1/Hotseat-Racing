using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance {get; private set;}
    public InputController InputController {get; private set;}
    public CanvasManager CanvasManager {get; private set;}

    public CameraFollow cameraScript;
    private Car carController;

    public bool trackFinished {get; set;}
    public bool startRace {get; set;}

    void Start() {
        trackFinished = false;
        startRace = true;
        carController.startEngine();
    }

    void Awake() {
        Instance = this;
        InputController = GetComponentInChildren<InputController>();
        CanvasManager = GetComponentInChildren<CanvasManager>();
        carController = GetComponentInChildren<Car>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!trackFinished && !startRace) {
            cameraScript.stopFollowing = false;
            InputController.disableControls = false;
            if (Input.GetKey(KeyCode.R)) {
                CanvasManager.TimeMonitor.timer = 0f;
            }
        } else {
            cameraScript.stopFollowing = true;
            InputController.disableControls = true;
        }
        if (InputController.ThrottleInput == 1f) Debug.Log("throttle");
        carController.Steer = InputController.SteerInput;
        carController.Throttle = InputController.ThrottleInput;
        carController.Brake = InputController.BrakeInput;
    }
}
