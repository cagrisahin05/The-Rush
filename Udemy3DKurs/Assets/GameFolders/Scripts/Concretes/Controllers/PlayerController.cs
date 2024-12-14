using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UdemyProject3D.Fuel;


namespace   UdemyProject3D.Controllers
{


    public class PlayerController : MonoBehaviour
{


    // Roketin hareket hızı
    
    [SerializeField] float thrustSpeed = 1f ;
         [SerializeField] float rotateSpeed = 1f ;
    Rigidbody rb;
    RocketFuel _fuel;
    
    //Yakıt Tüketimi
    [SerializeField] float thrustFuelConsumption = 1f;  // Her "thrust" için yakıt tüketimi
    [SerializeField] float rotationFuelConsumption = 0.1f; // Her "rotation" için yakıt tüketimi
    
    void Start()
    {
       rb = GetComponent<Rigidbody>();
       _fuel = GetComponent<RocketFuel>();
    }

    
    void Update()
    {
      
        if (_fuel !=null && _fuel.GetCurrentFuel() > 0)
        {
             ProcessThrust();
             ProcessRotation();
        }
    }

    void ProcessThrust()
    {
           if(Input.GetKey(KeyCode.Space))
        {
           rb.AddRelativeForce(Vector3.up *    thrustSpeed * Time.deltaTime );
            _fuel.FuelDecrease(thrustFuelConsumption * Time.deltaTime);
        }
      
    }
     void  ProcessRotation()
    {
            if(Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotateSpeed);
            _fuel.FuelDecrease(rotationFuelConsumption * Time.deltaTime);
        }
        else if(Input.GetKey(KeyCode.D))
        {
           ApplyRotation(-rotateSpeed);
           _fuel.FuelDecrease(rotationFuelConsumption * Time.deltaTime);
        }
    }

    public void ApplyRotation(float rotationThisFrame)
    {
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
    }



}
}



