using System.Collections;
using System.Collections.Generic;
using UdemyProject3D.Controllers;
using Unity.VisualScripting;
using UnityEngine;

public class StartFloorController : MonoBehaviour
{
 
 private void OnCollisionExit(Collision other) 
 {
  PlayerController player = other.collider.GetComponent<PlayerController>();

  if (player != null)
  {
    Destroy(this.gameObject);
  }
 }
}
