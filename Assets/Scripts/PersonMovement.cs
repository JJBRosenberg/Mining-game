using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonMovement : MonoBehaviour
{
    float speed = 5f;
    private CharacterController cc;
    // Start is called before the first frame update
    private void Awake()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 forward = transform.forward * vertical * speed * Time.deltaTime;
        Vector3 right = transform.right * horizontal * speed * Time.deltaTime;

        cc.Move(forward + right);
    }
}
