using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class Scenes : MonoBehaviour
{
   public void StartGame()
   {
        SceneManager.LoadScene("Main");
   }

    public void OpenMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
