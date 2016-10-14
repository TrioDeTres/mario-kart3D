using UnityEngine;

public class KartCameraController : MonoBehaviour {

    public Transform lookAt;

    public float verticalSensitivity = 150.0f;
    public float horizontalSensitivity = 150.0f;

    public float maxYAngle = 45.0f;
    public float minYAngle = 5.0f;

    public float damping = 4.0f;

    private float x;
    private float y;

    public void Awake()
    {
        Vector3 angles = transform.localEulerAngles;
        x = angles.x;
        y = angles.y;
    }

    public void LateUpdate ()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        x += mouseX * horizontalSensitivity * Time.deltaTime;
        y += mouseY * verticalSensitivity * Time.deltaTime;

        y = ClampAngle(y, minYAngle, maxYAngle);

        Quaternion rotation = Quaternion.Euler(y, x, 0);

        Quaternion smothRotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);

        transform.position = smothRotation * new Vector3(0, 0, -15.0f) + lookAt.position;

        transform.LookAt(lookAt);
    }

    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < 180.0f) { 
            angle += 360F;
        }

        if (angle > 180.0f) { 
            angle -= 360F;
        }

        return Mathf.Clamp(angle, min, max);
    }
}
