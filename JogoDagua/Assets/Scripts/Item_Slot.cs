using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Item_Slot : MonoBehaviour, IDropHandler{ 

    private GameObject obj_status;  //Para acessar o status
    private status script_status;

     private void Start()
    {
        obj_status = GameObject.Find("Status");     //Vamos acesasr o objeto do status
        script_status = obj_status.GetComponent<status>();
        //bd = GameObject.Find("Mybd");           //Pegamos o GameObject do botão
        //script_bd = bd.GetComponent<Mybdscript>();
    }

    [SerializeField] private RectTransform _transform;

    public void OnDrop(PointerEventData eventData){
        eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = _transform.anchoredPosition;
        script_status.win_Condition += 1;
    }
}
