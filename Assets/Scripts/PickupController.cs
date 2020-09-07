using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Tool toolScript;
    [SerializeField] private BoxCollider col;
    [SerializeField] private Transform player, toolContainer, fpsCam;
    [SerializeField] private GameObject interactText;
    [SerializeField] private Switcher toolSwitcher;

    [SerializeField] private float pickupRange = 10f;

    [SerializeField] private bool isEquipped, isInRange;

    [SerializeField] private static bool slotFull;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        if (!isEquipped)
        {
            toolScript.enabled = false;
            col.isTrigger = false;
        }

        if (isEquipped)
        {
            toolScript.enabled = true;
            col.isTrigger = true;
            slotFull = true;
        }
    }

    void Update()
    {
        Vector3 dist = player.position - transform.position;


        if (dist.magnitude <= pickupRange)
        {
            isInRange = true;
            if (!isEquipped && Input.GetKeyDown(KeyCode.F) && !slotFull)
            {
                Debug.Log("Added tool: " + toolScript.GetName());
                interactText.SetActive(false);
                Pickup();
            }
        }
        else
        {
            isInRange = false;
        }

        if (isInRange)
        {
            interactText.SetActive(true);
        }
        if (!isInRange)
        {
            interactText.SetActive(false);
        }
    }
    
    void Pickup()
    {
        isEquipped = true;

        transform.SetParent(toolContainer);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        toolSwitcher.SetCurrentToolIndex(toolContainer.childCount-1);
        toolSwitcher.SwitchTool();
        col.isTrigger = true;
        
        toolScript.enabled = false;

    }

    // private void OnTriggerEnter(Collider other)
    // {
    //     isInRange = true;
    //     interactText.SetActive(true);
    // }
    //
    // private void OnTriggerExit(Collider other)
    // {
    //     isInRange = false;
    //     interactText.SetActive(false);
    // }
}
