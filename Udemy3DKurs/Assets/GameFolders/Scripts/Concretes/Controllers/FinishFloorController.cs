using System.Collections;
using System.Collections.Generic;
using UdemyProject3D.Controllers;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishFloorController : MonoBehaviour
{
    [SerializeField] GameObject _firework;
    [SerializeField] GameObject _finishlight;

    private void Start()
    {
        _firework.SetActive(false);
        _finishlight.SetActive(false);
    }
    private void OnCollisionEnter(Collision other)
    {
        PlayerController player = other.collider.GetComponent<PlayerController>();

        if (player == null) return;
       
       if (other.GetContact(0).normal.y == -1)
       {
            _firework.gameObject.SetActive(true);
            _finishlight.gameObject.SetActive(true);
       }
       else
       {
        //Gitti
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
       }
    }
}
