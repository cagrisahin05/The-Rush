using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UdemyProject3D.Managers
{
    

    public class GameManager : MonoBehaviour
    {
        public event System.Action OnGameOver;
        public event System.Action OnMissionSucced;
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
        public void MissionSucced()
        {
            OnMissionSucced?.Invoke();
        }
        public void LoadLevelScene(int levelIndex = 0)
        {
            StartCoroutine(routine: LoadLevelScreenAsync(levelIndex));
        }
        private IEnumerator LoadLevelScreenAsync(int levelIndex)
        {
            yield return SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + levelIndex);
        }
        public void LoadMenuScene()
        {
            StartCoroutine(LoadMenuSceneAsync());
        }
        private IEnumerator LoadMenuSceneAsync()
        {
            yield return SceneManager.LoadSceneAsync("Menu");
            
        }
        public void Exit()
        {
            Debug.Log(message: "Exit process on triggered");
            Application.Quit();
        }
    }
           

}