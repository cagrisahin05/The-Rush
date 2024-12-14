using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UdemyProject3D.Fuel
{
public class RocketFuel : MonoBehaviour
{
    [SerializeField] float _maxfuel = 100f; 
    [SerializeField] float _currentfuel; 
    [SerializeField] ParticleSystem _particle; 

    private void Awake() 
    {
        _currentfuel = _maxfuel;    
    }

    // Yakıtı arttıran fonksiyon
    public void FuelIncrease(float increase)
    {
        _currentfuel += increase;
        _currentfuel = Mathf.Min(_currentfuel, _maxfuel);  // Yakıtı maksimum seviyeye sınırlamak

        if (_particle.isPlaying)
        {
            _particle.Stop();  // Partikül sistemi durduruluyor
        }
    }

    // Yakıtı azaltan fonksiyon
    public void FuelDecrease(float decrease)
    {
        _currentfuel -= decrease;
        _currentfuel = Mathf.Max(_currentfuel, 0f);  // Yakıtı sıfırın altına düşürmemek için

        if (_particle.isStopped)
        {
            _particle.Play();  // Yakıt azaldığında partikül sistemi başlatılıyor
        }
    }

    // Mevcut yakıt miktarını döndüren fonksiyon
    public float GetCurrentFuel()
    {
        return _currentfuel;
    }

   }
}