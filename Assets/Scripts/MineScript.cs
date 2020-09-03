using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private bool isInRange;
    [SerializeField] private GameObject interactText;


    // Update is called once per frame

    private void OnTriggerEnter(Collider other)
    {
        isInRange = true;
        interactText.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        isInRange = false;
        interactText.SetActive(false);
    }
}
