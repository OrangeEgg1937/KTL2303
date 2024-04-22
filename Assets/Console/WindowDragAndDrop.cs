using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WindowDragAndDrop : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    [Header("Control Target")]
    [SerializeField] private GameObject target;

    // Position of the gameobject
    private RectTransform rectTransform;
    private Transform transform_pos;
    private bool isUIElement = false;

    public void OnDrag(PointerEventData eventData)
    {
        if (isUIElement)
        {
            rectTransform.anchoredPosition += eventData.delta;
        }
        else
        {
            transform_pos.position += new Vector3(eventData.delta.x, eventData.delta.y, 0);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        return;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        return;
    }

    private void Awake()
    {
        // null check
        if (target == null) { throw new System.ArgumentNullException("target"); }

        // check the game object is a UI element or not
        transform_pos = target.GetComponent<RectTransform>();
        if (transform_pos == null)
        {
            isUIElement = true;
            transform_pos = target.transform;
        }
    }
}
