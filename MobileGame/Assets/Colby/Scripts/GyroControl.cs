using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroControl : MonoBehaviour {
    public bool gyroEnabled;
    private Gyroscope gyro;
    public GameObject Cube;
    private Quaternion rotation;
    public float speed = 10f;
    private Vector3 ourForwardVec;
    private Quaternion wantedRotation;

    // Use this for initialization
    void Start()
    {

        // cubeParent = new GameObject("cube parent");
        // cubeParent.transform.position = transform.position;
        //transform.SetParent(cubeParent.transform);

        ourForwardVec = new Vector3(0, 0, 1);

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

        //if(Cube.transform.rotation.x  < 87f && Cube.transform.rotation.x > -87f)
        //{
        //    Vector3 newVector = new Vector3(gyro.attitude.x, 0, 0);

        //    wantedRotation = Quaternion.Euler(newVector) + Cube.transform.rotation;
        //}
        //if (Cube.transform.rotation.y < 87f && Cube.transform.rotation.y > -87f)
        //{
        //    Vector3 newVector2 = new Vector3(0, gyro.attitude.y, 0);

        //    wantedRotation = (Quaternion.Euler(newVector2) * speed) + Cube.transform.rotation.eulerAngles;
        //}


        //    Cube.transform.rotation = Quaternion.Euler(wantedRotation);

        if (gyroEnabled)
        {
            //transform.rotation = gyro.attitude;
            //if (gyro.attitude.x > .1f)
            //{
            //    Cube.transform.Rotate(Vector3.up * Time.deltaTime * -speed);
            //}
            //if (gyro.attitude.x < -.1f)
            //{
            //    Cube.transform.Rotate(Vector3.up * Time.deltaTime * speed);
            //}
            //if (gyro.attitude.y > .1f)
            //{
            //    Cube.transform.Rotate(Vector3.right * Time.deltaTime * speed);
            //}
            //if (gyro.attitude.y < -.1f)
            //{
            //    Cube.transform.Rotate(Vector3.right * Time.deltaTime * -speed);
            //}
            Cube.transform.rotation = gyro.attitude;

        }

       
    }

}