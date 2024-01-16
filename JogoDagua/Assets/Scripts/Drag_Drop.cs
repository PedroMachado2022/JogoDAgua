using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drag_Drop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler{

    [SerializeField] private RectTransform _transform;

    [SerializeField] private Canvas _canvas;
    
    [SerializeField] private CanvasGroup _canvasGroup;

    public void OnPointerDown(PointerEventData pointerEventData){

            //Debug.Log("Foi");
    
    }

    public void OnBeginDrag(PointerEventData eventData){

            _canvasGroup.blocksRaycasts = false;
    }

    public void OnEndDrag(PointerEventData eventData){

           _canvasGroup.blocksRaycasts = true;

    }

    public void OnDrag(PointerEventData eventData){
        //Passamos a posição do click para o objeto
         _transform.anchoredPosition += eventData.delta / _canvas.scaleFactor;
    }

}
