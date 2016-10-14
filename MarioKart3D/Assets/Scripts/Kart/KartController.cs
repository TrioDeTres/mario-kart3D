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
    public List<AudioSource> soundEffects;

    private Rigidbody rigidbody;
    private float m_OldRotation;

    private bool breakWheels;

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

        isBreaking();

        foreach (WheelData w in wheels)
        {
            //Steering
            if (w.steering)
            {
                w.leftWheel.steerAngle = steering;
                w.rightWheel.steerAngle = steering;
            }

            //Torque
            if (w.motor)// && !breakWheels)
            {

                w.leftWheel.motorTorque = motor;
                w.rightWheel.motorTorque = motor;
            }
            else {
                w.leftWheel.motorTorque = 0;
                w.rightWheel.motorTorque = 0;
            }
        }

        SteerinController();
        soundPlayer(motor);
    }

    private void SteerinController()
    {
        if (Mathf.Abs(m_OldRotation - transform.eulerAngles.y) < 10f)
        {
            var turnadjust = (transform.eulerAngles.y - m_OldRotation) * 1.0f;
            Quaternion velRotation = Quaternion.AngleAxis(turnadjust, Vector3.up);
            rigidbody.velocity = velRotation * rigidbody.velocity;
        }


        m_OldRotation = transform.eulerAngles.y;

        wheels[0].rightWheel.attachedRigidbody.AddForce(-transform.up * 100 *
                                                     wheels[0].rightWheel.attachedRigidbody.velocity.magnitude);

        wheels[0].leftWheel.attachedRigidbody.AddForce(-transform.up * 100 *
                                                     wheels[0].leftWheel.attachedRigidbody.velocity.magnitude);
    }

    private void isBreaking()
    {
        if ( Input.GetKey(KeyCode.Space)) {
            breakWheels = true;
            foreach (WheelData w in wheels)
            {
                w.leftWheel.brakeTorque = 50.0f;
                w.rightWheel.brakeTorque = 50.0f;
            }
        }
        else {
            breakWheels = false;
        }
        
    }

    private void soundPlayer(float motor)
    {
        if (!breakWheels)
        {
            if (motor > 0.3)
            {
                soundEffects[0].Play();

                //StopSounds
                soundEffects[1].Stop();
                soundEffects[2].Stop();
                soundEffects[3].Stop();
            }
            else if (motor > 0.0)
            {
                soundEffects[1].Play();

                //stopSounds
                soundEffects[0].Stop();
                soundEffects[2].Stop();
                soundEffects[3].Stop();
            }
            else if (motor < 0)
            {
                soundEffects[1].Play();

                //StopSound
                soundEffects[0].Stop();
                soundEffects[2].Stop();
                soundEffects[3].Stop();
            }
        }
        else {
            soundEffects[3].Play();

            //StopSound
            soundEffects[0].Stop();
            soundEffects[1].Stop();
            soundEffects[2].Stop();
        }
    }
}