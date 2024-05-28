using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private RectTransform rectTrans;
    public Canvas myCanvas;

    // [SerializeField] GameObject Slot;
    public CanvasGroup canvasGroup;

    public GameObject[] Slot;

    public Vector2 startPosition;

    public int id;

    void Start()
    {
        Slot = GameObject.FindGameObjectsWithTag("Slot");
        
        rectTrans = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();

        startPosition = GetComponent<RectTransform>().anchoredPosition;
    }
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        // Debug.Log("BeginDrag");
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTrans.anchoredPosition += eventData.delta / myCanvas.scaleFactor;
        // Debug.Log("Drag");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        
        // foreach (GameObject obj in Slot)
        // {
        //     if (id == obj.GetComponent<SlotScript>().id)
        //     {
        //         canvasGroup.blocksRaycasts = false;
        //     }

        //     else
        //     {
        //         canvasGroup.blocksRaycasts = true;
        //     }
            
        // }
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // Debug.Log("PointerDown");
    }
}
