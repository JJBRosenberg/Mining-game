using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public string startGame;
    public string options;
    public string credits;
    public string information;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void NewGame()
    {
        SceneManager.LoadScene(startGame);
    }
    public void Options()
    {
        SceneManager.LoadScene(options);
    }
    public void Credits()
    {
        SceneManager.LoadScene(credits);
    }

    public void Information()
    {
        SceneManager.LoadScene(information);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
