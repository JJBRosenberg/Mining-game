using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update

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
            interactText.SetActive(true);
            Debug.Log("this works");
            RemoveMine(hit);
            OpenDoor(hit);
        }
        else
        {
            interactText.SetActive(false);
        }
    }

    void RemoveMine(RaycastHit hit)
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (hit.collider.tag == "Mine")
            {
                Destroy(hit.collider.gameObject);
            }
        }
    }

    void OpenDoor(RaycastHit hit)
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (hit.collider.tag == "Door")
            {
                Animator anim = hit.collider.gameObject.GetComponent<Animator>();
                anim.SetTrigger("OpenClose");
            }
        }
    }

}
