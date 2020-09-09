using UnityEngine;

public class openingScreen : MonoBehaviour
    
{
    [SerializeField] public Canvas instructionCanvas;
    [SerializeField] public Canvas HUD;
    [SerializeField] private Player player;
    [SerializeField] private CameraController cameraController;
    void Awake()
    {
        instructionCanvas.gameObject.SetActive(true);
        HUD.gameObject.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        cameraController = player.GetComponentInChildren<CameraController>();
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        player.enabled = false;
        cameraController.enabled = false;

    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Debug.Log("hi");
            instructionCanvas.gameObject.SetActive(false);
            HUD.gameObject.SetActive(true);
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            player.enabled = true;
            cameraController.enabled = true;
        }
    }
    
}