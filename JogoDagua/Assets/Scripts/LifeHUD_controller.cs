using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeHUD_controller : MonoBehaviour{

    public Image rosto;
    private GameObject obj_status;  
    private status script_status;
    void Start(){

        obj_status = GameObject.Find("Status");     //Vamos acesasr o objeto do status
        script_status = obj_status.GetComponent<status>();

        if(script_status.mascote == "humanoide"){
            rosto.sprite = Resources.Load<Sprite>("rosto_alt");
        }else if(script_status.mascote == "gotinha"){
            rosto.sprite = Resources.Load<Sprite>("rosto");
        }
    }

}
