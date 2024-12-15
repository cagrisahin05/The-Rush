using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace UdemyProject3D.Managers
{
    

    public class GameManager : MonoBehaviour
    {
        public event System.Action OnGameOver;

        public static GameManager Instance { get; private set; }
        private void Awake() 
        {
           SingletonThisGameObject();
        }
        private void SingletonThisGameObject()
        {
            if (Instance == null)
            {
            Instance = this;  
            DontDestroyOnLoad(this.gameObject);    
            }   
          else
            {
            Destroy(this.gameObject);   
            }  
        }

        public void GameOver() 
        {
            OnGameOver?.Invoke();
            
        }
    }
           

}