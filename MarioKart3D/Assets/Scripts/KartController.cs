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
    public List<AudioSource> soundEffects;
    //public List<GameObject> frontWheels;

    private Rigidbody rigidbody;
    private bool breakWheels;

    public void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        breakWheels = false;

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

        //isBreaking();

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
            } //else if(breakWheels)
            //{
            //    w.leftWheel.brakeTorque = 0.75f;
            //    w.rightWheel.brakeTorque = 0.75f;
            //}
        }

        soundPlayer(motor);
    }

    private void isBreaking()
    {
        if (Input.GetKey(KeyCode.B))
        {
            breakWheels = true;
        }
        else {
            breakWheels = false;
        }
        
    }

    private void soundPlayer(float motor)
    {
        //if (!breakWheels)
        //{
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
        //}
        //else {
        //    soundEffects[3].Play();

        //    //StopSound
        //    soundEffects[0].Stop();
        //    soundEffects[1].Stop();
        //    soundEffects[2].Stop();
        //}
    }
}