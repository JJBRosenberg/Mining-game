﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private Camera cam;
    [SerializeField] private Animator cameraAnimator;
    [SerializeField] private bool isMoving;
    
    private Rigidbody rb;

    public bool IsMoving { get => isMoving; private set => isMoving = value; }

    // Start is called before the first frame update
    private void Awake()
    {
        //cameraAnimator = cam.GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (rb.velocity != Vector3.zero)
        {
            IsMoving = true;
        }
        else
        {
            IsMoving = false;
        }
        //cameraAnimator.SetBool("isMoving", isMoving);
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 modifier = new Vector3(horizontal, 0, vertical);
        Vector3 direction = Vector3.ClampMagnitude(modifier, 1);
        
        bool isSprinting = Input.GetKey(KeyCode.LeftShift);
        speed = 5f;
        if (isSprinting)
        {
            speed = 10f;
        }

        Quaternion rot = transform.rotation;
        Vector3 velY = Vector3.up * rb.velocity.y;
        rb.velocity = rot * direction * speed + velY;

    }
    
}
