using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    //public InventoryObjects inventory;
    [SerializeField] private float distance = 50f;
    [SerializeField] private GameObject interactText;
    [SerializeField] private GameObject completeText;
    [SerializeField] private Camera cam;

    void Start()
    {
        completeText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //ObjectsCheck();
    }
    
    
    
    // void ObjectsCheck()
    // {
    //     int layerMask = 1 << 8;
    //     RaycastHit hit;
    //     if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, distance, layerMask))
    //     {
    //         Tool tool = GetComponentInChildren<Tool>();
    //         MineScript mineScript = hit.collider.GetComponent<MineScript>();
    //         if (tool.GetName() == mineScript.toolToUse)
    //         {
    //             interactText.SetActive(true);
    //             RemoveMine(hit);
    //         }
    //         else
    //         {
    //             interactText.SetActive(false);
    //         }
    //     }
    // }
    //
    // void RemoveMine(RaycastHit hit)
    // {
    //     if (Input.GetKeyDown(KeyCode.F))
    //     {
    //
    //         if (hit.collider.tag == "Mine")
    //             {
    //                 Manager.GetManager().AddMinesCount();
    //                 interactText.SetActive(false);
    //                 Destroy(hit.collider.gameObject);
    //             }
    //     }
    // }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            if (other.CompareTag("Mine"))
            {
                Tool currTool = GetComponentInChildren<Tool>();
                MineScript mine = other.gameObject.GetComponent<MineScript>();
                if (currTool.GetName() == mine.toolToUse)
                {
                    interactText.SetActive(true);
                }
            }
            else
            {
                interactText.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            interactText.SetActive(false);
        }
    }

    // private void OnTriggerEnter(Collider other)
    // {
    //     var item = GetComponent<item>();
    //     if (item)
    //     {
    //         inventory.AddItem(item.Item, 1);
    //     }
    //     
    // }
}
