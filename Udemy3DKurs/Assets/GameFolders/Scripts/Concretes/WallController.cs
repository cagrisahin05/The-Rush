using System.Collections;
using System.Collections.Generic;
using UdemyProject3D.Controllers;
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    }
    
}
