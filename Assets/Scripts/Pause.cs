using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
                
            }
            else
            {
                
            }
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        player.enabled = false;
        pauseMenu.SetActive(true);
        cameraController.enabled = false;
    }

    void UnpauseGame()
    {
        Time.timeScale
    }
}
