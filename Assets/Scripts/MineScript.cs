using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineScript : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private bool isInRange;
    [SerializeField] private GameObject interactText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Tool tool = other.gameObject.GetComponentInChildren<Tool>();
            if (tool.GetName() == "Pliers")
            {
                interactText.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactText.SetActive(false);
        }
    }
}
