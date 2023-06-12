using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Dragging : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public bool isDraggable = true;

    public Transform parentAfterDrag;
    [SerializeField] private Image image;


    private void Start()
    {
        image = GetComponent<Image>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Drag");
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isDraggable)
        {
            transform.position = Input.mousePosition;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("Drag 3");
        transform.SetParent(parentAfterDrag);
        image.raycastTarget = true;
    }














    //private Vector3 mousePositionsOffset;

    //private Vector3 GetMouseWorldPosition()
    //{
    //    return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //}

    //private void OnMouseDown()
    //{
    //    if (isDraggable)
    //    {
    //        mousePositionsOffset = gameObject.transform.position - GetMouseWorldPosition();
    //    }
    //}

    //private void OnMouseDrag()
    //{
    //    if (isDraggable)
    //    {
    //        transform.position = GetMouseWorldPosition() + mousePositionsOffset;
    //    }
    //}
}
