using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float distance = 50f;
    [SerializeField] private GameObject interactText;
    [SerializeField] private AudioClip useSound;
    [SerializeField] private GameObject completeText;
    [SerializeField] private Camera cam;

    private int layerMask;
    private RaycastHit hit;

    void Start()
    {
        layerMask = LayerMask.GetMask("Interactable");
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckForObjects();
    }


    void CheckForObjects()
    {
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, distance, layerMask))
        {
            
            CheckForDistance(hit);
            CheckForInput(hit);
            
        }
        else
        {
            interactText.SetActive(false);
        }
    }

    void CheckForDistance(RaycastHit hit)
    {
        if (hit.collider.CompareTag("Door"))
        {
            interactText.SetActive(true);
        }
            
        else if (hit.collider.CompareTag("Mine"))
        {
            Tool currTool = GetComponentInChildren<Tool>();
            MineScript mine = hit.collider.GetComponent<MineScript>();
            if (currTool.GetName() == mine.toolsToUse[mine.GetNeededToolIndex()])
            {
                interactText.SetActive(true);
            }
            else if (currTool.GetName() != mine.toolsToUse[mine.GetNeededToolIndex()])
            {
                interactText.SetActive(false);
            }
        }
    }

    void CheckForInput(RaycastHit hit)
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (hit.collider.CompareTag("Door"))
            {
                Animator doorAnim = hit.collider.GetComponent<DoorScript>().GetAnim();
                doorAnim.SetBool("isOpen", !doorAnim.GetBool("isOpen"));
            }

            if (hit.collider.CompareTag("Mine"))
            {
                Tool currTool = GetComponentInChildren<Tool>();
                MineScript mine = hit.collider.GetComponent<MineScript>();
                if (interactText.activeInHierarchy)
                {
                    
                    mine.SetToolIndex(mine.GetNeededToolIndex() + 1);

                    AudioManager.audioManager.PlaySound(currTool.GetSound(), transform.position);
                    
                    if (mine.GetNeededToolIndex() == mine.GetLastToolIndex())
                    {
                        Manager.GetManager().RemoveMine(hit.collider.gameObject);
                        Manager.GetManager().AddMinesCount();
                    }
                }
            }
        }
    }
    
}
