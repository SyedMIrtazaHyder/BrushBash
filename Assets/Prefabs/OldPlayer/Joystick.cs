using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    [SerializeField] private RectTransform background;
    [SerializeField] private RectTransform handle;
    [SerializeField] private float offset;


    private Vector2 inputDirection = Vector2.zero;

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 position = RectTransformUtility.WorldToScreenPoint(null, background.position);
        Vector2 radius = background.sizeDelta / 2f;

        inputDirection = (eventData.position - position) / radius;
        ClampInput();
        MoveHandle();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        inputDirection = Vector2.zero;
        MoveHandle();
    }

    private void MoveHandle()
    {
        handle.anchoredPosition = new Vector2(inputDirection.x * (background.sizeDelta.x / 3), inputDirection.y * (background.sizeDelta.y / 3));
    }

    private void ClampInput()
    {
        inputDirection = Vector2.ClampMagnitude(inputDirection, offset);
    }

    public Vector2 GetInputDirection()
    {
        return inputDirection;
    }
}
