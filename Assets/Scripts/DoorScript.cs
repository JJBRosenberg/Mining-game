using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private bool isInRange;
    [SerializeField] private Animator anim;
    [SerializeField] private bool isOpen;
    [SerializeField] private GameObject interactText;

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
        if (other.gameObject.tag == "Player")
        {
            isInRange = true;
            interactText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        isInRange = false;
        interactText.SetActive(false);
    }
}
