using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroControl : MonoBehaviour
{
    public bool gyroEnabled;
    private Gyroscope gyro;
    public GameObject Cube;
    private Quaternion rotation;
    public float speed = 10f;
    public float verticalSpeed = 100f;
    private Vector3 ourForwardVec;
    private Quaternion wantedRotation;
    private GameObject theCamera;
    private float ourAngle;
    private Vector3 holdVec;
    private Quaternion holdQuat;

    // Use this for initialization
    void Start()
    {

        // cubeParent = new GameObject("cube parent");
        // cubeParent.transform.position = transform.position;
        //transform.SetParent(cubeParent.transform);
        theCamera = GameObject.FindGameObjectWithTag("MainCamera");

        ourForwardVec = new Vector3(0, 0, 1);

        //gyroEnabled = EnableGyro();

        Debug.Log(gyroEnabled);

        ourAngle = 0.0f;
    }

    public bool EnableGyro()
    {
        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;
            
            rotation = new Quaternion(0, 0, 1, 0);

            Debug.Log("gyro is enabled");
            return true;
        }
        Debug.Log("gyro is not enabled");
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

            //if (Cube.transform.eulerAngles.y < 267f)
            //{
            if (gyro.attitude.x > .3f)
            {
                // Debug.Log("Cube y rotating right ");
                Cube.transform.Rotate(Vector3.up * gyro.attitude.x * Time.deltaTime * speed);
                // theCamera.transform.RotateAround(Vector3.zero, Vector3.up, -gyro.attitude.x * Time.deltaTime * speed);
                //theCamera.transform.LookAt(Vector3.zero);
                // Debug.Log("cube y rotation from right" + Cube.transform.eulerAngles.y);
            }

            //}


            /// if (Cube.transform.eulerAngles.y > 3f)
            /// {

            if (gyro.attitude.x < -.3f)
            {
                // Debug.Log("Cube y rotating left ");
                Cube.transform.Rotate(Vector3.up * gyro.attitude.x * Time.deltaTime * speed);
                //theCamera.transform.RotateAround(Vector3.zero, Vector3.up, -gyro.attitude.x * Time.deltaTime * speed);
                //theCamera.transform.LookAt(Vector3.zero);
                // Debug.Log("cube y rotation from left" + Cube.transform.eulerAngles.y);
            }
            /// }



            if (ourAngle < 87f)
            {
                if (gyro.attitude.y > .1f)
                {
                    ourAngle += gyro.attitude.y * Time.deltaTime * verticalSpeed;

                    Debug.Log("ourAngle " + ourAngle);
                    // Debug.Log("Camera roation x going up " + theCamera.transform.eulerAngles.x);
                    theCamera.transform.RotateAround(Vector3.zero, Vector3.right, gyro.attitude.y * Time.deltaTime * verticalSpeed);
                    theCamera.transform.LookAt(Vector3.zero);
                }
            }


            if (ourAngle > -87f)
            {
                if (gyro.attitude.y < -.2f)
                {
                    ourAngle += gyro.attitude.y * Time.deltaTime * verticalSpeed;

                    Debug.Log("ourAngle " + ourAngle);
                    // Debug.Log("Camera roation x going down " + theCamera.transform.eulerAngles.x);
                    theCamera.transform.RotateAround(Vector3.zero, Vector3.right, gyro.attitude.y * Time.deltaTime * verticalSpeed);
                    theCamera.transform.LookAt(Vector3.zero);
                }

            }


        }

    }
}