using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UdemyProject3D.Managers;

namespace UdemyProject3D.UIs
{       


    public class GameOverReturn : MonoBehaviour
    {   
        public void YesClicked  ()
        {
            GameManager.Instance.LoadLevelScene();
        }
    

         public void NoClicked()
        {   
            GameManager.Instance.LoadMenuScene();
        }   
    }
}