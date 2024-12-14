using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;


namespace   UdemyProject3D.Controllers
{


    public class PlayerController : MonoBehaviour
    {


   // Roketin hareket hızı
    
   [SerializeField] float thrustSpeed = 1f ;
     [SerializeField] float rotateSpeed = 1f ;
    Rigidbody rb;
    
    void Start()
    {
       rb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
           if(Input.GetKey(KeyCode.Space))
        {
           rb.AddRelativeForce(Vector3.up *    thrustSpeed * Time.deltaTime );
        }
      
    }
     void  ProcessRotation()
    {
            if(Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotateSpeed);
        }
        else if(Input.GetKey(KeyCode.D))
        {
           ApplyRotation(-rotateSpeed);
        }
    }

    public void ApplyRotation(float rotationThisFrame)
    {
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
    }



}
}



