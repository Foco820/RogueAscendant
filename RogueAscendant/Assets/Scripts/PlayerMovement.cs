using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//玩家移动

public class PlayerMovement : MonoBehaviour
{
    //基础参数
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float rotationSpeed = 120f;
    [SerializeField] float jumpForce = 8f;
    [SerializeField] float springMultiplier = 1.5f;

    Rigidbody rb;
    [SerializeField] InputHandler inputHandler;

    //状态参数
    float currentMoveSpeed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        inputHandler = GetComponent<InputHandler>();

        currentMoveSpeed = moveSpeed;
    }

    private void Update()
    {
        //轴输入 移动和转向
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
            Debug.Log("跳跃触发！");
        }
    }

    private void Sprint()
    {
        currentMoveSpeed = inputHandler.isSprinting ? moveSpeed * springMultiplier : moveSpeed;
        Debug.Log(inputHandler.isSprinting ? "疾跑中.." : "正常移动");
    }
}
