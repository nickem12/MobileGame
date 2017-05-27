using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavor : MonoBehaviour
{

    public bool gyroEnabled;
    private Gyroscope gyro;
    private Vector3 movementVector;
    public float speed;

    // Use this for initialization
    void Start()
    {
        gyroEnabled = EnableGyro();

        Debug.Log(gyroEnabled);
    }

    private bool EnableGyro()
    {
        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;

            return true;
        }
        return false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (gyroEnabled)
        {
            if (gyro.attitude.x > .1f)
            {
                transform.RotateAround(Vector3.zero, Vector3.up, gyro.attitude.x * speed);
                transform.LookAt(Vector3.zero);
            }
            if(gyro.attitude.y > .1f)
            {
                transform.RotateAround(Vector3.zero, Vector3.right, gyro.attitude.y * speed);
                transform.LookAt(Vector3.zero);
            }
            if(gyro.attitude.x < -.1f)
            {
                transform.RotateAround(Vector3.zero, Vector3.up, gyro.attitude.x * speed);
                transform.LookAt(Vector3.zero);
            }
            if(gyro.attitude.y < -.1f)
            {
                transform.RotateAround(Vector3.zero, Vector3.right, gyro.attitude.y * speed);
                transform.LookAt(Vector3.zero);
            }
        }
    }
}
