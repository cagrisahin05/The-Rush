using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UdemyProject3D.Fuel;
using UdemyProject3D.Managers;


namespace   UdemyProject3D.Controllers
{


    public class PlayerController : MonoBehaviour
    {


            // Roketin hareket hızı
            
            [SerializeField] float thrustSpeed = 1f ;
                [SerializeField] float rotateSpeed = 1f ;
            Rigidbody rb;
            RocketFuel _fuel;
            
            bool _canmove;
            //Yakıt Tüketimi
            [SerializeField] float thrustFuelConsumption = 1f;  // Her "thrust" için yakıt tüketimi
            [SerializeField] float rotationFuelConsumption = 0.1f; // Her "rotation" için yakıt tüketimi
            
            void Start()
            {
            rb = GetComponent<Rigidbody>();
            _fuel = GetComponent<RocketFuel>();
            _canmove = true;
            }

            
            void Update()
            {
                if (!_canmove) return;

                    if (_fuel !=null && _fuel.GetCurrentFuel() > 0)
                    {
                        ProcessThrust();
                        ProcessRotation();
                    }
                }
                private void OnEnable()     
                {
                            if (GameManager.Instance != null)
                            {
                            GameManager.Instance.OnGameOver += HandleOnEventTriggerer;
                            GameManager.Instance.OnMissionSucced += HandleOnEventTriggerer;
                            }
                }

                private void OnDisable()
                {
                
                        if (GameManager.Instance != null)
                        {
                    GameManager.Instance.OnGameOver -= HandleOnEventTriggerer;
                    GameManager.Instance.OnMissionSucced -= HandleOnEventTriggerer;
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
                    rb.freezeRotation = true; // freezing rotation so we can manually rotate
                    transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
                    rb.freezeRotation = false; // unfreezing rotation so the physics system can take over
                }

                private void HandleOnEventTriggerer()
                {
                    _canmove= false;
                    thrustSpeed = 0f;
                    rotateSpeed = 0f;
                    _fuel.FuelDecrease(100f);
                }

        
    }

}



