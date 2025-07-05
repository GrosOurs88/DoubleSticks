using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;

public class InputSystemManager : MonoBehaviour
{
    public InputSystemActions inputs = null;

    [HideInInspector] public InputAction LeftStick;
    [HideInInspector] public InputAction rightStick;
    [HideInInspector] public InputAction buttonA;
    [HideInInspector] public InputAction buttonB;
    [HideInInspector] public InputAction buttonX;
    [HideInInspector] public InputAction buttonY;
    [HideInInspector] public InputAction leftBumper;
    [HideInInspector] public InputAction rightBumper;
    [HideInInspector] public InputAction leftTrigger;
    [HideInInspector] public InputAction rightTrigger;
    [HideInInspector] public InputAction debugButtonUp;
    [HideInInspector] public InputAction debugButtonDown;
    [HideInInspector] public InputAction debugButtonLeft;
    [HideInInspector] public InputAction debugButtonRight;

    public static InputSystemManager instance;

    void Awake()
    {
        instance = this;
        inputs = new InputSystemActions();
    }

    void OnEnable()
    {
        LeftStick = inputs.Player.MoveLeft;
        LeftStick.Enable();

        rightStick = inputs.Player.MoveRight;
        rightStick.Enable();

        buttonA = inputs.Player.Jump;
        buttonA.Enable();
        //buttonA.performed += ButtonA; //I just kept this line to have this specific way of calling an input action

        leftTrigger = inputs.Player.ShootLeft;
        leftTrigger.Enable();

        rightTrigger = inputs.Player.ShootRight;
        rightTrigger.Enable();

        leftBumper = inputs.Player.SuperLeft;
        leftBumper.Enable();

        rightBumper = inputs.Player.SuperRight;
        rightBumper.Enable();

        /*
        buttonX = inputs.Player.XButton;
        buttonX.Enable();

        buttonY = inputs.Player.YButton;
        buttonY.Enable();

        debugButtonUp = inputs.Player.Debug_Up;
        debugButtonUp.Enable();

        debugButtonDown = inputs.Player.Debug_Down;
        debugButtonDown.Enable();

        debugButtonLeft = inputs.Player.Debug_Left;
        debugButtonLeft.Enable();

        debugButtonRight = inputs.Player.Debug_Right;
        debugButtonRight.Enable();
        */
    }

    private void OnDisable()
    {
        LeftStick.Disable();
        rightStick.Disable();
        buttonA.Disable();
        //buttonB.Disable();
        //buttonX.Disable();
        //buttonY.Disable();
        leftTrigger.Disable();
        rightTrigger.Disable();
        leftBumper.Disable();
        rightBumper.Disable();
        //debugButtonUp.Disable();
        //debugButtonDown.Disable();
        //debugButtonLeft.Disable();
        //debugButtonRight.Disable();
    }
}
