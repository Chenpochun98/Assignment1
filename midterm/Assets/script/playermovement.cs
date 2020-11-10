using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12.0f;
    public float gravity = -9.81f;
    public float jumph = 3.0f;
    public float point = 0.0f;

    public Transform groundcheck;
    public float gruonddist = 0.4f;
    public LayerMask groundmask;

    public Vector3 velocity;
    bool isGround;
    // Update is called once per frame
    void Update()
    {
        isGround = Physics.CheckSphere(groundcheck.position, gruonddist, groundmask);

        if(isGround&&velocity.y<0.0f)
        {
            velocity.y = -2.0f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move*speed*Time.deltaTime);

        if(Input.GetButtonDown("Jump")&&isGround)
        {
            velocity.y = Mathf.Sqrt(jumph * -2.0f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

    
    }
}
