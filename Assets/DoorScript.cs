using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject interactText;
    [SerializeField] private bool isInRange;
    [SerializeField] private Animator anim;
    [SerializeField] private bool isOpen;


    private void Update()
    {
        if (isInRange)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                isOpen = !isOpen;
                anim.SetBool("isOpen", isOpen);
                
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        isInRange = true;
        
    }

    private void OnTriggerExit(Collider other)
    {
        isInRange = false;
        
    }
}
