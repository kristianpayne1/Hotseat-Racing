using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public Transform centerOfMass;
    public float motorTorque = 100f;
    public float maxSteer = 20f;
    public float brakePower = 300f;
    public float maxVelocity = 30f;
    public bool isRunning = false;

    public float Steer {get; set;}
    public float Throttle {get; set;}
    public float Brake {get; set;}

    private Rigidbody _rigidbody;
    private Transform _transform;
    private Wheel[] wheels;
    private float prevVelocity = 0f;

    public WheelFrictionCurve frontForwardDriftingFriction;
    public WheelFrictionCurve frontSidewaysDriftingFriction;
    public WheelFrictionCurve backForwardDriftingFriction;
    public WheelFrictionCurve backSidewaysDriftingFriction;

    public AudioSource startUpSound;
    public AudioSource engineSound;

    void Start() {
        wheels = GetComponentsInChildren<Wheel>();
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.centerOfMass = centerOfMass.localPosition;
        _transform = GetComponent<Transform>();
    }

    void FixedUpdate() {
        // Debug.Log(_rigidbody.velocity.magnitude);
        if(isRunning)
        {
            foreach (var wheel in wheels)
            {   
                wheel.SteerAngle = Steer * maxSteer;
                wheel.Torque = _rigidbody.velocity.magnitude <= maxVelocity ? Throttle * motorTorque : 0f;
                wheel.Brake = Brake * brakePower;
            }
            prevVelocity = _rigidbody.velocity.magnitude;
        }
    }

    public void startEngine()
    {
        isRunning = true;
        StartCoroutine(startUpEngine());
    }

    IEnumerator startUpEngine()
    {
        startUpSound.Play();
        yield return new WaitForSeconds(2f);
        engineSound.Play();
    }
}
