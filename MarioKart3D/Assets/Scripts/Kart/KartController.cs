using System.Collections.Generic;
using UnityEngine;

public class KartController : MonoBehaviour
{
    public WheelCollider[] wheels;
    public Transform centerOfMasss;
    public float maxMotorTorque;
    public float maxSteeringAngle;
    public float maxSpeed = 60;

    public List<AudioSource> soundEffects;

    private new Rigidbody rigidbody;
    private bool isBraking;
    private Vector3 initialPosition;
    private float revertTorqueForce;

    public void Start()
    {
        initialPosition = transform.position;
        revertTorqueForce = maxMotorTorque * 2.0f;

        rigidbody = GetComponent<Rigidbody>();

        rigidbody.centerOfMass = centerOfMasss.localPosition;

        foreach (WheelCollider w in wheels)
        {
            w.ConfigureVehicleSubsteps(1000, 1, 1);
        }
    }

    public void Update()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            transform.position = initialPosition;
        }
    }

    public void FixedUpdate()
    {
        float forward = maxMotorTorque * Input.GetAxis("Vertical");
        float steering = maxSteeringAngle * Input.GetAxis("Horizontal");

        float speed = Vector3.Dot(rigidbody.velocity, transform.forward) * 3.6f;

        Debug.Log(speed);

        Brake();

        wheels[0].steerAngle = steering;
        wheels[1].steerAngle = steering;

        if (speed < maxSpeed && forward > 0)
        {
            wheels[0].motorTorque = forward;
            wheels[1].motorTorque = forward;
            wheels[2].motorTorque = forward;
            wheels[3].motorTorque = forward;

        }
        else if (speed > maxSpeed)
        {
            wheels[0].brakeTorque = revertTorqueForce;
            wheels[1].brakeTorque = revertTorqueForce;
            wheels[2].brakeTorque = revertTorqueForce;
            wheels[3].brakeTorque = revertTorqueForce;
            wheels[0].motorTorque = 0;
            wheels[1].motorTorque = 0;
            wheels[2].motorTorque = 0;
            wheels[3].motorTorque = 0;
        }
        else
        {
            wheels[0].motorTorque = 0;
            wheels[1].motorTorque = 0;
            wheels[2].motorTorque = 0;
            wheels[3].motorTorque = 0;
        }

        PlaySounds(forward);
    }

    private void Brake()
    {
        if ( Input.GetKey(KeyCode.Space)) {
            isBraking = true;
            wheels[0].brakeTorque = 2500.0f;
            wheels[1].brakeTorque = 2500.0f;
            wheels[2].brakeTorque = 2500.0f;
            wheels[3].brakeTorque = 2500.0f;
        }
        else {
            isBraking = false;
            wheels[0].brakeTorque = 0.0f;
            wheels[1].brakeTorque = 0.0f;
            wheels[2].brakeTorque = 0.0f;
            wheels[3].brakeTorque = 0.0f;
        }
        
    }

    private void PlaySounds(float motor)
    {
        if (!isBraking)
        {
            if (motor > 0.3)
            {
                soundEffects[0].Play();

                soundEffects[1].Stop();
                soundEffects[2].Stop();
                soundEffects[3].Stop();
            }
            else if (motor > 0.0)
            {
                soundEffects[1].Play();

                soundEffects[0].Stop();
                soundEffects[2].Stop();
                soundEffects[3].Stop();
            }
            else if (motor < 0)
            {
                soundEffects[1].Play();

                soundEffects[0].Stop();
                soundEffects[2].Stop();
                soundEffects[3].Stop();
            }
        }
        else {
            soundEffects[3].Play();

            soundEffects[0].Stop();
            soundEffects[1].Stop();
            soundEffects[2].Stop();
        }
    }
}