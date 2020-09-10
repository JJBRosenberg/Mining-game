using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float sensitivity;

    [SerializeField] private GameObject player;
    [SerializeField] private Animator cameraAnimator;
    
    private float yAxisClamp; // just so it reaches a limit at top and bottom

    private PersonMovement playerScript;
    // Start is called before the first frame update
    

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        playerScript = GetComponentInParent<PersonMovement>();
        cameraAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        cameraAnimator.SetBool("isWalking", playerScript.IsMoving);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Look();
    }


    void Look()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * sensitivity * Time.fixedDeltaTime;
        float mouseY = Input.GetAxisRaw("Mouse Y") * sensitivity * Time.fixedDeltaTime;

        yAxisClamp += mouseY;


        if (yAxisClamp >= 90f)
        {
            yAxisClamp = 90f;
            mouseY = 0f;
        }

        else if (yAxisClamp <= -90f)
        {
            yAxisClamp = -90f;
            mouseY = 0f;
        }

        transform.Rotate(Vector3.left * mouseY);

        player.transform.Rotate(Vector3.up * mouseX);


    }
}
