using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drag_Drop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    
    [SerializeField] private RectTransform _transform;

    [SerializeField] private Canvas _canvas;

    public void OnPointerDown(PointerEventData pointerEventData){

            Debug.Log("Foi");
    
    }

    public void OnBeginDrag(PointerEventData eventData){

            Debug.Log("Início");
    }

    public void OnEndDrag(PointerEventData eventData){

            Debug.Log("fim");

    }

    public void OnDrag(PointerEventData eventData){
        
         _transform.anchoredPosition += eventData.delta / _canvas.scaleFactor;
        Debug.Log("Era pra ta se movendo");
    }
}
