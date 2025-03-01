using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//����ƶ�

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float rotationSpeed = 120f;
    [SerializeField] float jumpForce;

    Rigidbody rb;

    InputControl controls;
    InputAction moveAction;
    InputAction rotationAction;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        controls = new InputControl();

        moveAction = controls.Player.Move;
        rotationAction = controls.Player.Rotate;
    }

    private void Update()
    {
        float moveInput = moveAction.ReadValue<float>();
        float rotationInput = rotationAction.ReadValue<float>();

        //������ �ƶ���ת��
        transform.position += transform.forward * moveInput * moveSpeed * Time.deltaTime;
        transform.Rotate(0, rotationInput * rotationSpeed * Time.deltaTime, 0);
    }

    private void OnEnable()
    {
        moveAction.Enable();
        rotationAction.Enable();
    }

    private void OnDisable()
    {
        moveAction.Disable();
        rotationAction.Disable();
    }

    public void Jump(InputAction.CallbackContext ctx)
    {
        if (ctx.phase == InputActionPhase.Performed)
        {
            Debug.Log("��������");
            rb.velocity += Vector3.up * jumpForce;
        }
    }
}
