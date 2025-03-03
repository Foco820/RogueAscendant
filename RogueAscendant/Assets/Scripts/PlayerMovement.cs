using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//����ƶ�

public class PlayerMovement : MonoBehaviour
{
    //��������
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float rotationSpeed = 120f;
    [SerializeField] float jumpForce = 8f;
    [SerializeField] float springMultiplier = 1.5f;

    Rigidbody rb;
    [SerializeField] InputHandler inputHandler;

    //״̬����
    float currentMoveSpeed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        inputHandler = GetComponent<InputHandler>();

        currentMoveSpeed = moveSpeed;
    }

    private void Update()
    {
        //������ �ƶ���ת��
        Move();
        Rotate();
        Jump();
        Sprint();
    }

    private void Rotate()
    {
        transform.Rotate(0, inputHandler.rotationInput * rotationSpeed * Time.deltaTime, 0);
    }

    private void Move()
    {
        transform.position += transform.forward * inputHandler.moveInput * currentMoveSpeed * Time.deltaTime;
    }

    private void Jump()
    {
        if (inputHandler.isJumping)
        {
            rb.AddForce(Vector3.up * jumpForce,ForceMode.Impulse);
            Debug.Log("��Ծ������");
        }
    }

    private void Sprint()
    {
        currentMoveSpeed = inputHandler.isSprinting ? moveSpeed * springMultiplier : moveSpeed;
        Debug.Log(inputHandler.isSprinting ? "������.." : "�����ƶ�");
    }
}
