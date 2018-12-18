using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public void menu()
    {
        SceneManager.LoadScene(0);
    }

    public void Scene1()
    {
   
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
