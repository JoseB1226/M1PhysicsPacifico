using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   

    public void PlayGame()
    {
        Debug.Log("PlayGame method is triggered");
        SceneManager.LoadScene("Scenes/M1PacExam");
    }
}
