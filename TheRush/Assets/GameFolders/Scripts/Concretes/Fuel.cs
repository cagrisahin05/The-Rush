using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UdemyProject3D.Fuel
{
public class RocketFuel : MonoBehaviour
{
    [SerializeField] float _maxFuel = 100f;
    [SerializeField] float _currentFuel;
    [SerializeField] ParticleSystem _particle;

    private void Awake()
    {
        _currentFuel = _maxFuel;
        // Partikül sistemini başlangıçta durduruyoruz
        _particle.Stop();
    }

    void Update()
    {
        // Space tuşuna basıldığında partikül sistemini başlat
        if (Input.GetKey(KeyCode.Space) && _currentFuel > 0f)
        {
            if (!_particle.isPlaying)  // Partikül sistemi zaten oynuyorsa tekrar başlatma
            {
                _particle.Play();
            }
        }
        else
        {
            // Space tuşu bırakıldığında partikül sistemi durdur
            if (_particle.isPlaying)
            {
                _particle.Stop();
            }
        }
    }

    // Yakıtı azaltan fonksiyon
    public void FuelDecrease(float decrease)
    {
        _currentFuel -= decrease;
        _currentFuel = Mathf.Max(_currentFuel, 0f);

        // Yakıt sıfıra düştüğünde partikül sistemini durdur
        if (_currentFuel == 0f && _particle.isPlaying)
        {
            _particle.Stop();
        }
    }
            public float GetCurrentFuel()
        {
            return _currentFuel;
        }

}
}