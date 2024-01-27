/*
Desenvolvido por:     Pedro Machado Araújo
E-mail:               pedro.machado.rs@hotmail.com
GitHUB:               PedroMachado2022
2024
*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// Script simples, serve para trocar a imagem que fica ao lado da vida do personagem, com base na escolha de mascote do jogador.
public class LifeHUD_controller : MonoBehaviour{

    public Image rosto;
    private GameObject obj_status;  
    private status script_status;
    void Start(){

        // Acessamos o Objeto "Status" dentro da cena
        obj_status = GameObject.Find("Status");

        // Acessamos o script "status" dentro do objeto "Status"
        script_status = obj_status.GetComponent<status>();

        // Caso seja o humanoide
        if(script_status.mascote == "humanoide"){
            // Transformamos o sprite no humanoide
            rosto.sprite = Resources.Load<Sprite>("rosto_alt");

        }
        // Caso seja o gotinha
        else if(script_status.mascote == "gotinha"){
            // Transformamos o sprite no gotinha
            rosto.sprite = Resources.Load<Sprite>("rosto");
        }
    }

}
