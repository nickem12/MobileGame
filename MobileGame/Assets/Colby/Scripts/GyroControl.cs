using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroControl : MonoBehaviour {
    public bool gyroEnabled;
    private Gyroscope gyro;
    private GameObject cubeParent;
    private Quaternion rotation;

    // Use this for initialization
    void Start()
    {

        cubeParent = new GameObject("cube parent");
        cubeParent.transform.position = transform.position;
        transform.SetParent(cubeParent.transform);


        gyroEnabled = EnableGyro();

        Debug.Log(gyroEnabled);
    }

    private bool EnableGyro()
    {
        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;

            rotation = new Quaternion(0, 0, 1, 0);

            return true;
        }
        return false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gyroEnabled)
        {
            transform.localRotation = gyro.attitude * rotation;
        }
    }
}