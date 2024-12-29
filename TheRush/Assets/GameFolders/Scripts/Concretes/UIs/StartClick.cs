using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UdemyProject3D.Managers;

namespace UdemyProject3D.UIs
{
    public class StartClick : MonoBehaviour
    {
        public void StartClicked()
        {
            GameManager.Instance.LoadLevelScene(1);
        }
    }
}