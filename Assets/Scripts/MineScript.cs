using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class MineScript : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private bool isInRange;
    [SerializeField] public string toolToUse;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject interactText;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (isInRange)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Tool tool = player.GetComponentInChildren<Tool>();
                if (tool.GetName() == toolToUse)
                {
                    interactText.SetActive(false);
                    Manager.GetManager().AddMinesCount();
                    Destroy(gameObject);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        isInRange = false;
    }
}
