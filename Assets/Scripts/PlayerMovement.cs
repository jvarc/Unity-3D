using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int speed = 1;
    public int rotatoSpeed = 1;
    public int jumpForce = 1;

    private Rigidbody physics;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        physics = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical   = Input.GetAxis("Vertical");

        transform.Translate(new Vector3 (horizontal, 0.0f, vertical) * Time.deltaTime * speed);

        float rotationY = Input.GetAxis("Mouse X");

        transform.Rotate(new Vector3(0.0f, rotationY * Time.deltaTime * rotatoSpeed, 0.0f));

        if (Input.GetKeyDown(KeyCode.Space)) Jump();
    }

    private void Jump()
    {
        physics.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
    }
}
