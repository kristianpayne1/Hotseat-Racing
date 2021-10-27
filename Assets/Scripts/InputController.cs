using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public string inputSteerAxis = "Horizontal";

    public float ThrottleInput {get; set;}
    public float BrakeInput {get; set;}
    public float SteerInput {get; set;}

    public bool disableControls = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!disableControls) {
            PlayerControls();
        } else {
            ThrottleInput = 0f;
            BrakeInput = 0f;
            SteerInput = 0f;
        }
    }

    void PlayerControls()
    {
        Debug.Log("blah");
        if(Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                Debug.Log(touch.position.x);
                if(Input.touchCount == 1) 
                {
                    if (touch.position.x < Screen.width/2)
                    {
                        SteerInput = -1f;
                    } else if (touch.position.x > Screen.width/2) {
                        SteerInput = 1f;
                    }
                    BrakeInput = 0f;
                    ThrottleInput = 1f;
                } else if (Input.touchCount == 2)
                {
                    BrakeInput = 1f;
                    ThrottleInput = 0f;
                }
            } else {
                SteerInput = Input.GetAxis(inputSteerAxis);
                if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D)) {
                    BrakeInput = 1f;
                    ThrottleInput = 0f;
                } else {
                    BrakeInput = 0f;
                    ThrottleInput = 1f;
                }
            }
    }
}
