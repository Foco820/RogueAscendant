using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    InputControl controls;
    InputAction moveAction;
    InputAction rotationAction;
    InputAction jumpAction;
    InputAction sprintAction;

    public float moveInput {  get; private set; }
    public float rotationInput {  get; private set; }
    public bool isJumping{  get; private set; }
    public bool isSprinting {  get; private set; }

    private void Awake()
    {
        controls = new InputControl();
        moveAction = controls.Player.Move;
        rotationAction = controls.Player.Rotate;
        jumpAction = controls.Player.Jump;
        sprintAction = controls.Player.Sprint;
    }

    private void Update()
    {
        moveInput = moveAction.ReadValue<float>();
        rotationInput = rotationAction.ReadValue<float>();
    }

    private void OnEnable()
    {
        moveAction.Enable();
        rotationAction.Enable();
        jumpAction.Enable();
        sprintAction.Enable();
    }

    private void OnDisable()
    {
        moveAction.Disable();
        rotationAction.Disable();
        jumpAction.Disable();
        sprintAction.Disable();
    }

    private void LateUpdate()
    {
        isJumping = false; //÷ÿ÷√Ã¯‘æ
    }

    public void OnJump(InputAction.CallbackContext ctx)
    {
        //isJumping = ctx.phase == InputActionPhase.Started;

        if (ctx.phase == InputActionPhase.Started)
        {
            isJumping = true;
            Debug.Log("Ã¯‘æ ‰»Î£°");
        }
    }

    public void OnSprint(InputAction.CallbackContext ctx)
    {

        if (ctx.phase == InputActionPhase.Started)
        {
            isSprinting = true;
        }
        else if (ctx.phase == InputActionPhase.Canceled)
        {
            isSprinting= false;
        }
        Debug.Log(isSprinting ? "º≤≈‹ ‰»Î.." : "’˝≥£ ‰»Î");
    }
}
