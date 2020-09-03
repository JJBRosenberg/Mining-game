using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public InventoryObjects inventory;
    [SerializeField] private float distance = 50f;
    [SerializeField] private GameObject interactText;
    [SerializeField] private Camera cam;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        ObjectsCheck();
    }

    void ObjectsCheck()
    {
        int layerMask = 1 << 8;
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, distance, layerMask))
        {
            RemoveMine(hit);
        }
    }

    void RemoveMine(RaycastHit hit)
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (hit.collider.tag == "Mine")
            {
                Manager.GetManager().AddMinesCount();
                interactText.SetActive(false);
                Destroy(hit.collider.gameObject);
                
            }
            
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        var item = GetComponent<item>();
        if (item)
        {
            inventory.AddItem(item.Item, 1);
        }
        
    }
}
