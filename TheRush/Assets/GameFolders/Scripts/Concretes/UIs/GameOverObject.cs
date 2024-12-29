using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UdemyProject3D.Managers;

namespace UdemyProject3D.UIs
{
    
    public class GameOverObject : MonoBehaviour
    {
        [SerializeField] private GameObject _gameOverPanel;

        private void Awake() 
        {
            if (_gameOverPanel.activeSelf)
            {
                _gameOverPanel.SetActive(false);
            }
            
        }
        private void OnEnable()     
        { 
            GameManager.Instance.OnGameOver += HandleOnGameOver;
        }

        private void OnDisable()
        {
           
           GameManager.Instance.OnGameOver -= HandleOnGameOver; 
            
        }

        private void HandleOnGameOver()
        {
            _gameOverPanel.SetActive(true);
        }

    }

}

