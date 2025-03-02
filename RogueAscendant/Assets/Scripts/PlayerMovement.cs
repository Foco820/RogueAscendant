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

    //状态变量
    Rigidbody rb;
    float currentMoveSpeed;

    InputControl controls;
    InputAction moveAction;
    InputAction rotationAction;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        controls = new InputControl();

        moveAction = controls.Player.Move;
        rotationAction = controls.Player.Rotate;

        currentMoveSpeed = moveSpeed;
    }

    private void Update()
    {
        float moveInput = moveAction.ReadValue<float>();
        float rotationInput = rotationAction.ReadValue<float>();

        //轴输入 移动和转向
        transform.position += transform.forward * moveInput * currentMoveSpeed * Time.deltaTime;
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
            Debug.Log("飞起来！");
            rb.velocity += Vector3.up * jumpForce;
        }
    }

    public void Sprint(InputAction.CallbackContext ctx)
    {
        if (ctx.phase == InputActionPhase.Started)
        {
            Debug.Log("勇敢勇敢我的朋友");
            currentMoveSpeed = moveSpeed * springMultiplier;
        }
        else if (ctx.phase == InputActionPhase.Canceled)
        {
            Debug.Log("照在心里那片天空");
            currentMoveSpeed = moveSpeed;
        }
    }
}
