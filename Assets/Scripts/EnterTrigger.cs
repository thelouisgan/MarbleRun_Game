using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterTrigger : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Capsule"))
        {
            print("Hi Bogget cap cap!");

        }
    }


}
