using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjectWithKeys : MonoBehaviour
{
    Camera cam;
    private void Start()
    {
        cam = Camera.main;
    }
    void Update()
    {
        if (!cam) return;
        Vector3 LookDirection = cam.transform.forward / 50;
        Vector3 TwoDDirection = new Vector3(LookDirection.x, 0, LookDirection.z);
        Vector3 YDirection = new Vector3(0, LookDirection.y, 0);
        print(cam.transform.forward);
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += TwoDDirection;
        }
        //if (Input.GetKey(KeyCode.A))
        //{
        //    transform.position += Quaternion.Euler(0, 90, 0) * TwoDDirection;
        //    cam.transform.position += Quaternion.Euler(0, 90, 0) * TwoDDirection;
        //}
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= TwoDDirection;
        }
        //if (Input.GetKey(KeyCode.D))
        //{
        //    transform.position -= Quaternion.Euler(0, 90, 0) * TwoDDirection;
        //}
        if (Input.GetKey(KeyCode.Space))
        {
            transform.position -= YDirection + (Vector3.down/50);
        }
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            transform.position += YDirection + (Vector3.down / 50);
        }
    }
}
