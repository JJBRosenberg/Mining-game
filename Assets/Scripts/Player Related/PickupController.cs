using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Tool toolScript;
    [SerializeField] private Switcher switcher;
    [SerializeField] private BoxCollider col;
    [SerializeField] private Transform player, toolContainer, fpsCam;

    [SerializeField] private float pickupRange = 10f;

    [SerializeField] private bool isEquipped;

    [SerializeField] private static bool slotFull;


    private void Start()
    {
        if (!isEquipped)
        {
            toolScript.enabled = false;
            //rb.isKinematic = false;
            col.isTrigger = false;
        }

        if (isEquipped)
        {
            toolScript.enabled = true;
            //rb.isKinematic = true;
            col.isTrigger = true;
            slotFull = true;
        }
    }

    void Update()
    {
        Vector3 dist = player.position - transform.position;
        if (!isEquipped && dist.magnitude <= pickupRange && Input.GetKeyDown(KeyCode.F) && !slotFull)
        {
            Pickup();
        }
    }
    
    void Pickup()
    {
        isEquipped = true;

        transform.SetParent(toolContainer);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        
        //rb.isKinematic = true;
        col.isTrigger = true;
        
        toolScript.enabled = false;

    }
}
