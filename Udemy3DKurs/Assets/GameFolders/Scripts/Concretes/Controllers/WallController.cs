using System.Collections;
using System.Collections.Generic;
using UdemyProject3D.Controllers;
using UdemyProject3D.Managers;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WallController : MonoBehaviour
{
  private void OnCollisionEnter(Collision other)
    {
        PlayerController player = other.collider.GetComponent<PlayerController>();

        if (player != null)
        {
    
        GameManager.Instance.GameOver();

        }
    
    }   
}    
