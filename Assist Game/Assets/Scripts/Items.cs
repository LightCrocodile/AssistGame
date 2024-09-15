using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Item : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;
    [SerializeField] public int ItemId;

    private RectTransform recttransform;
    private CanvasGroup canvasGroup;
    private Vector3 originalpos;
    private Transform originalparent;
    private bool validDrop = false;

    private void Awake()
    {
        recttransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Drag started");
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
        originalpos = recttransform.position;
        originalparent = transform.parent;
        validDrop = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Dragging");
        recttransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("Drag ended");
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;

        if (!validDrop)
        {
            recttransform.position = originalpos;
            transform.SetParent(originalparent);
        }
    }

    public void SetValidDrop(bool isvalid)
    {
        validDrop = isvalid;
    }
}
