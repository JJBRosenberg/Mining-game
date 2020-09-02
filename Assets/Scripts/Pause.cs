using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private bool isPaused = false;

    [SerializeField] private GameObject pauseMenu;

    [SerializeField] private Player player;

    [SerializeField] private CameraController cameraController;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        cameraController = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            isPaused = !isPaused;
            if (isPaused)
            {
                PauseGame();
            }
            else
            {
                UnpauseGame();
            }
        }
    }

    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        player.enabled = false;
        pauseMenu.SetActive(true);
        cameraController.enabled = false;
    }

    public void UnpauseGame()
    {
        isPaused = false;
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        player.enabled = true;
        pauseMenu.SetActive(false);
        cameraController.enabled = true;
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
