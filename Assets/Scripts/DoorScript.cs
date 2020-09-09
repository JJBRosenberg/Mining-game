using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Animator anim;
    [SerializeField] private BoxCollider doorCol;

    private void Start()
    {
        //anim = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        doorCol.enabled = !anim.GetBool("isOpen");
    }

    public Animator GetAnim()
    {
        return anim;
    }
    
}
