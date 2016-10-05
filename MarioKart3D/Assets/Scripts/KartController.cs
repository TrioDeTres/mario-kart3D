using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable]
public struct WheelData
{
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public bool motor;
    public bool steering;
}

public class KartController : MonoBehaviour
{
    public List<WheelData> wheels;
    public float maxMotorTorque;
    public float maxSteeringAngle;
    public Transform centerOfMass;

    private Rigidbody rigidbody;

    public void Start()
    {
        rigidbody = GetComponent<Rigidbody>();

        foreach (WheelData w in wheels)
        {
            w.leftWheel.ConfigureVehicleSubsteps(1, 12, 15);
            w.rightWheel.ConfigureVehicleSubsteps(1, 12, 15);
        }
    }

    public void FixedUpdate()
    {
        float motor = maxMotorTorque * Input.GetAxis("Vertical");
        float steering = maxSteeringAngle * Input.GetAxis("Horizontal");

        foreach (WheelData w in wheels)
        {
            if (w.steering)
            {
                w.leftWheel.steerAngle = steering;
                w.rightWheel.steerAngle = steering;
            }
            if (w.motor)
            {
                w.leftWheel.motorTorque = motor;
                w.rightWheel.motorTorque = motor;
            }
        }
    }
}