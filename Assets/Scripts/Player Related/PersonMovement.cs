using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    private CharacterController cc;
    // Start is called before the first frame update
    private void Awake()
    {
        cc = GetComponent<CharacterController>();
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

        Vector3 forward = transform.forward * vertical * speed * Time.deltaTime;
        Vector3 right = transform.right * horizontal * speed * Time.deltaTime;

        bool isSprinting = Input.GetKey(KeyCode.LeftShift);
        speed = 5f;
        if (isSprinting)
        {
            speed = 10f;
        }

        cc.Move(forward + right);
    }
    
}
