using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathZone : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        Destroy(GameObject.FindGameObjectWithTag("Player"));
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene(2);
    }
}
