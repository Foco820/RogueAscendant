using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//玩家移动

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float rotationSpeed = 120f;
    [SerializeField] float jumpForce;

    Rigidbody rb;

    InputControl control;

    float moveInput;
    float rotationInput;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        transform.position += transform.forward * moveInput * moveSpeed * Time.deltaTime;
        transform.Rotate(0, rotationInput * rotationSpeed * Time.deltaTime, 0);
    }

    public void Jump(InputAction.CallbackContext ctx)
    {
        if (ctx.phase == InputActionPhase.Performed)
        {
            Debug.Log("飞起来！");
            rb.velocity += Vector3.up * jumpForce;
        }
    }

    public void Move(InputAction.CallbackContext ctx)
    {
        if (ctx.phase == InputActionPhase.Performed)
        {
            Debug.Log("动起来！");
            moveInput = ctx.ReadValue<float>();
        }
    }

    public void Rotate(InputAction.CallbackContext ctx)
    {
        if (ctx.phase == InputActionPhase.Performed)
        {
            Debug.Log("转起来了");
            rotationInput = ctx.ReadValue<float>();
        }
    }
}
