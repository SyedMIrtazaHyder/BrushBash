using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private PlayerInput playerInput;

    [SerializeField] RectTransform joystick;
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
        Vector2 touchPos = touchPositionAction.ReadValue<Vector2>();

        // Calculate the canvas size in world space
        Vector2 canvasSizeWorld = new Vector2(canvas.rect.width, canvas.rect.height) * canvas.lossyScale;

        // Convert touch position to world space within the canvas
        //Vector2 touchPositionWorld = Camera.main.ScreenToWorldPoint(new Vector3(touchPos.x * canvasSizeWorld.x, touchPos.y * canvasSizeWorld.y, Camera.main.nearClipPlane));
        //Debug.Log(touchPositionWorld.ToString());
        // Convert world space position to local Canvas position
        Vector2 localPosition;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas, touchPos, Camera.main, out localPosition);

        // Calculate the offset between the touch position and the center of the Canvas
        Vector2 centerOffset = canvas.rect.center - canvas.rect.size * 0.5f;

        // Calculate the clamped local position
        Vector2 clampedPosition = new Vector2(
            Mathf.Clamp(localPosition.x + centerOffset.x, 0f, canvas.rect.width),
            Mathf.Clamp(localPosition.y + centerOffset.y, 0f, canvas.rect.height)
        );

        // Set the joystick's anchored position to the clamped local position
        joystick.anchoredPosition = clampedPosition - centerOffset;
    }
}

        //Vector2 touchPos = touchPositionAction.ReadValue<Vector2>();
        ////pos.y = joystick.transform.position.y;
        ////RectTransformUtility.ScreenPointToLocalPointInRectangle(joystick, touchPositionAction.ReadValue<Vector2>(), Camera.main, out Vector2 localPos);
        ////Problem with conversion fix later
        ////joystick.anchoredPosition = new Vector2(pos.x, pos.z);

        ////Vector3 touchPositionWorld = Camera.main.ScreenToWorldPoint(new Vector3(touchPos.x, joystick.transform.position.y, touchPos.y));

        //// Convert world space position to local Canvas position
        ////Vector2 localPosition;
        ///*bool hit = RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas, touchPos, Camera.main, out Vector2 localPosition);
        //if (hit)
        //{
        //    Debug.Log("Hit on " + touchPos.ToString() );
        //}*/

        ////joystick.anchoredPosition = touchPos;

        ////Vector3 touchPositionWorld = Camera.main.ScreenToWorldPoint(new Vector3(touchPos.x, touchPos.y, Camera.main.nearClipPlane));

        //// Convert world space position to local Canvas position
        //Vector2 localPosition;
        //RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas, touchPos, Camera.main, out localPosition);

        //// Calculate the offset between the touch position and the center of the Canvas
        ///*Vector2 centerOffset = canvas.rect.center - canvas.rect.size * 0.5f;

        //// Calculate the clamped local position
        //Vector2 clampedPosition = new Vector2(
        //    Mathf.Clamp(localPosition.x + centerOffset.x, 0f, canvas.rect.width),
        //    Mathf.Clamp(localPosition.y + centerOffset.y, 0f, canvas.rect.height)
        //);*/

        //// Set the Button's anchored position to the clamped local position
        //joystick.anchoredPosition = localPosition;