using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame_Script : MonoBehaviour {
    
    private GameObject obj_status;  
    private status script_status;

    private GameObject End_Game;
    

    void Start() {
        obj_status = GameObject.Find("Status");
        script_status = obj_status.GetComponent<status>();
        
        End_Game = GameObject.FindGameObjectWithTag("End_Layer");

        if (End_Game != null) {
            End_Game.SetActive(false);
        }
    }

    void Update() {
        EndGame();
    }

    void EndGame() {
        if (script_status.win_Condition == 6) {
            End_Game.SetActive(true);
        }else{
            
        }
    }
}
