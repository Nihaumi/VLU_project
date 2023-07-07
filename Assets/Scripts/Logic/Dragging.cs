using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

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
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        image.raycastTarget = false;
        if (image.transform.GetChild(0).GetComponent<Image>())
        {
            image.transform.GetChild(0).GetComponent<Image>().raycastTarget = false;
            image.transform.GetChild(1).GetComponent<Image>().raycastTarget = false;
        }
        else
        {
            image.transform.GetChild(0).GetComponent<TextMeshPro>().raycastTarget = false;
        }

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
        transform.SetParent(parentAfterDrag);
        image.raycastTarget = true;
        if (image.transform.GetChild(0).GetComponent<Image>())
        {
            image.transform.GetChild(0).GetComponent<Image>().raycastTarget = true;
            image.transform.GetChild(1).GetComponent<Image>().raycastTarget = true;
        }
        else
        {

            image.transform.GetChild(0).GetComponent<TextMeshPro>().raycastTarget = true;
        }
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
