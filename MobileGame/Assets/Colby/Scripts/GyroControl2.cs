using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroControl2 : MonoBehaviour {
    public bool gyroEnabled;
    private Gyroscope gyro;
    float speed = 10f;
    Vector3 dir;
	// Use this for initialization
	void Start () {
        gyroEnabled = EnableGyro();
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
    void Update () {
        dir.y = gyro.attitude.x;
        dir.z = gyro.attitude.y;

        if(dir.sqrMagnitude > 1)
        {
            dir.Normalize();
        }

        dir *= Time.deltaTime;

        transform.Rotate(dir * speed);

	}
}
