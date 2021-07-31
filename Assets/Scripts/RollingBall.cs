using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RollingBall : MonoBehaviour
{

    public float ballSpeed;


    // Update is called once per frame
    void Update()
    {
        float xSpeed = Input.GetAxis("Horizontal");
        float ySpeed = Input.GetAxis("Vertical");
        Rigidbody body = GetComponent<Rigidbody>();
        GetComponent<Rigidbody>().maxAngularVelocity = 10f;
        body.AddTorque(new Vector3(xSpeed, 0, ySpeed) * ballSpeed * Time.deltaTime);
    }
}