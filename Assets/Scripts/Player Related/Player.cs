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
    [SerializeField] private GameObject completeText;
    [SerializeField] private Camera cam;

    void Start()
    {
        completeText.SetActive(false);
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
            Debug.Log("YES");
            RemoveMine(hit);
        } else
        {
            Debug.Log("NOPE");
        }
    }

    void RemoveMine(RaycastHit hit)
    {

        Debug.Log("here 0");
        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("here 1");
            if (hit.collider.tag == "Mine")
            {
                Debug.Log("here 2");
                Manager.GetManager().AddMinesCount();
                interactText.SetActive(false);
                Destroy(hit.collider.gameObject);
                completeText.SetActive(true);
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
