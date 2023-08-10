using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UITestScript : MonoBehaviour
{
    private PlayerInput playerInput;
    [SerializeField] RectTransform canvas;

    private InputAction touchPositionAction;
    private InputAction touchPressAction;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        touchPositionAction = playerInput.actions.FindAction("JoystickMove");
        touchPressAction = playerInput.actions.FindAction("TouchPress");
    }

    private void OnEnable()
    {
        Debug.Log("Touch Enabled");
        touchPressAction.performed += TouchPressed;
    }

    private void OnDisable()
    {
        Debug.Log("Touch disabled");
        touchPressAction.performed -= TouchPressed;
    }

    private void TouchPressed(InputAction.CallbackContext context)
    {
        Vector2 pos = touchPositionAction.ReadValue<Vector2>();
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas, pos, Camera.main, out Vector2 val);
        Transform joystick = canvas.GetChild(0);
        Debug.Log(pos.ToString() + "->" + val.ToString() + " + " + joystick.position.ToString());
        joystick.position = new Vector2(Mathf.Abs(val.x), Mathf.Abs(val.y));
    }

}
