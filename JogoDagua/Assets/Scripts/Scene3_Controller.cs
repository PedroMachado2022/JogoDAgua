// Desenvolvido por Pedro Machado Araújo, 2024.
// GitHUB


// Script utilizado para controlar quais os objetos o player coletou para montar o reservatório.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene3_Controller : MonoBehaviour{

   void Awake(){

    GameObject plataform = GameObject.FindGameObjectWithTag("Plataforma");
    GameObject caixa = GameObject.FindGameObjectWithTag("Caixa");
    GameObject canos = GameObject.FindGameObjectWithTag("Canos");
    GameObject filtro = GameObject.FindGameObjectWithTag("Filtro");
        
    plataform.SetActive(false);
    caixa.SetActive(false);
    canos.SetActive(false);
    filtro.SetActive(false);

   }
    void Start(){

        GameObject objeto = GameObject.Find("Status");      //Vamos acesasr o objeto do status
        status script = objeto.GetComponent<status>();      //Acessar o seu script

        GameObject plataform = GameObject.FindGameObjectWithTag("Plataforma");
        GameObject caixa = GameObject.FindGameObjectWithTag("Caixa");
        GameObject canos = GameObject.FindGameObjectWithTag("Canos");
        GameObject filtro = GameObject.FindGameObjectWithTag("Filtro");
        

        if (script.Plataforma){
                plataform.SetActive(true);
            }

        if (script.Caixa){
                caixa.SetActive(true);
            }

        if (script.Pregos){
                canos.SetActive(true);
            }

        if (script.Filtro){
                filtro.SetActive(true);
            }
    }   

}
