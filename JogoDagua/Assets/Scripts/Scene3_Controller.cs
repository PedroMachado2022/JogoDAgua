// Desenvolvido por Pedro Machado Araújo, 2024.
// GitHUB


// Script utilizado para controlar quais os objetos o player coletou para montar o reservatório.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene3_Controller : MonoBehaviour{

    private GameObject plataform;
    private GameObject caixa;

    private GameObject cano1;
    private GameObject cano2;
    private GameObject cano3;

    private GameObject filtro;
    private status script;
    
    

    void Start(){

        plataform = GameObject.FindGameObjectWithTag("Plataforma");
        caixa = GameObject.FindGameObjectWithTag("Caixa");
        cano1 = GameObject.FindGameObjectWithTag("Canos");
        cano2 = GameObject.FindGameObjectWithTag("Cano 2");
        cano3 = GameObject.FindGameObjectWithTag("Cano 3");
        filtro = GameObject.FindGameObjectWithTag("Filtro");

        GameObject objeto = GameObject.Find("Status");
        script = objeto.GetComponent<status>();

        if (script != null) {
            DesativarObjetosComBaseNoStatus(plataform);
            DesativarObjetosComBaseNoStatus(caixa);
            DesativarObjetosComBaseNoStatus(cano1);
            DesativarObjetosComBaseNoStatus(cano2);
            DesativarObjetosComBaseNoStatus(cano3);
            DesativarObjetosComBaseNoStatus(filtro);
        } else {
            //Debug.LogError("Objeto 'Status' ou script 'status' não foi encontrado.");
        }
    } 

    void DesativarObjetosComBaseNoStatus(GameObject objetoDesativar) {
        if (objetoDesativar != null) {
            //Debug.Log(objetoDesativar.name + " Existe.");

            // Verificar se as variáveis do script foram configuradas
            if (script != null) {
                // Desativar o objeto com base na variável do script
                if (!script.Plataforma && objetoDesativar == plataform) {
                    objetoDesativar.SetActive(false);
                    script.lose_Condition += 1;
                }

                if (!script.Caixa && objetoDesativar == caixa) {
                    objetoDesativar.SetActive(false);
                    script.lose_Condition += 1;
                }

                if (!script.Pregos && objetoDesativar == cano1){
                    objetoDesativar.SetActive(false);
                    script.lose_Condition += 1;
                }

                if (!script.Pregos && objetoDesativar == cano2){
                    objetoDesativar.SetActive(false);
                    script.lose_Condition += 1;
                }

                if (!script.Pregos && objetoDesativar == cano3){
                    objetoDesativar.SetActive(false);
                    script.lose_Condition += 1;
                }

                if (!script.Filtro && objetoDesativar == filtro) {
                    objetoDesativar.SetActive(false);
                    script.lose_Condition += 1;
                }
            }
        } else {
            //Debug.Log("Objeto a desativar é nulo.");
        }
    }


    void PrintGameObjectStatus(string gameObjectName, GameObject obj) {
        if (obj == null) {
            Debug.LogError($"O GameObject {gameObjectName} não foi encontrado ou é nulo.");
        } else {
            Debug.Log($"O GameObject {gameObjectName} foi encontrado.");
        }
    }

}
