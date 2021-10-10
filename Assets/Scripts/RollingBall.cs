using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RollingBall : MonoBehaviour
{

    public float ballSpeed;
    public float myX = 0;
    public float myY = 0;
    public float myZ = 0;

    private float loadedX, loadedY, loadedZ = 0;

    //Declaring Jump variable
    public int nbJumps = 0;


    // Update is called once per frame
    void Update()
    {
        //

        float xSpeed = Input.GetAxis("Horizontal");
        float ySpeed = Input.GetAxis("Vertical");
        Rigidbody body = GetComponent<Rigidbody>();
        GetComponent<Rigidbody>().maxAngularVelocity = 10f;
        myX = body.transform.position.x;
        myY = body.transform.position.y;
        myZ = body.transform.position.z;


        Vector3 dir = Camera.main.transform.forward;
        Vector3 hor = Camera.main.transform.right;
        Vector3 fixed_dir = Camera.main.transform.rotation * dir;


        //transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, Camera.main.transform.localEulerAngles.y, transform.localEulerAngles.z); 
        //body.AddForce(new Vector3(xSpeed, 0, ySpeed)* ballSpeed * Time.deltaTime);
        //body.AddTorque(new Vector3(ySpeed, 0, -xSpeed) * ballSpeed * Time.deltaTime);

        //body.AddForce((fixed_dir*ySpeed)* ballSpeed * Time.deltaTime);

        body.AddForce((fixed_dir * ySpeed + hor * xSpeed) * ballSpeed * Time.deltaTime);


        if (Input.GetKeyDown(KeyCode.Space) && nbJumps < 2)
        {
            body.AddForce(new Vector3(0, 500f, 0));
            //jump here
            nbJumps = nbJumps + 1;
            Debug.Log("Jump Initiated!");


        }

        if (GetComponent<Collider>().gameObject.tag == "Untagged")
        {
            Debug.Log("tags");
            nbJumps = 0;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {

            PlayerPrefs.SetFloat("SavedX", myX);
            PlayerPrefs.SetFloat("SavedY", myY);
            PlayerPrefs.SetFloat("SavedZ", myZ);
            Debug.Log("Saving file: X= " + myX + ", Y= " + myY + ", Z= " + myZ);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            nbJumps = 0;
        }


        if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("L Pressed");
            if (PlayerPrefs.HasKey("SavedX"))
            {
                loadedX = PlayerPrefs.GetFloat("SavedX");
                loadedY = PlayerPrefs.GetFloat("SavedY");
                loadedZ = PlayerPrefs.GetFloat("SavedZ");
                Debug.Log("Loaded file: X= " + loadedX + ", Y= " + loadedY + ", Z= " + loadedZ);
                Vector3 loadedVector = new Vector3(loadedX, loadedY, loadedZ);
                //transform.Translate(loadedX, loadedY, loadedZ, Space.World);
                transform.position = loadedVector;

            }


        }




    }
    //Function to load the game
    void LoadGame()
    {
        float loadedX = 0.0f;
        if (PlayerPrefs.HasKey("SavedFloat"))
        {
            loadedX = PlayerPrefs.GetFloat("SavedFloat");
            Debug.Log("Loaded X -- " + loadedX);
        }

    }

    public void OnCollisionEnter()
    {
        {
            Debug.Log("collision - Wall");
            nbJumps = 0;
        }

    }

}