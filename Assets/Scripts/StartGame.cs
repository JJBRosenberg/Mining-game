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
    public string tutorial;
    public string tutorialDone;

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

    public void Tutorial()
    {
        SceneManager.LoadScene(tutorial);
    }

    public void OpenURL(string url)
    {
        Application.OpenURL(url);
    }
    
    public void TutorialDone()
    {
        SceneManager.LoadScene(tutorialDone);
    }
}
