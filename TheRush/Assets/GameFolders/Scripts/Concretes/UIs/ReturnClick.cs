using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UdemyProject3D.Managers;

namespace UdemyProject3D.UIs
{
    public class ReturnClick : MonoBehaviour
    {
        public void ReturnClicked()
        {
            GameManager.Instance.Exit();
        }
    }
    
}
