using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Item_Slot : MonoBehaviour, IDropHandler{ 

    private GameObject obj_status;
    private status script_status;

     private void Start(){
        obj_status = GameObject.Find("Status"); 
        script_status = obj_status.GetComponent<status>();
    }

    [SerializeField] private RectTransform _transform;

    public void OnDrop(PointerEventData eventData){
        eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = _transform.anchoredPosition;
        script_status.win_Condition += 1;
    }
}
