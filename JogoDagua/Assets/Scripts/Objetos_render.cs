
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

// Foi necessário criar esse script para corrigir um problema na hora de renderizar os itens coletados da primeira fase, na segunda.

public class Objetos_render : MonoBehaviour
{
    private status script_status;
    private GameObject obj_status;
    private GameObject canos;
    private GameObject canos_cor;

    private GameObject caixa;

    private GameObject caixa_cor;

    public void Start(){

        obj_status = GameObject.Find("Status");     
        script_status = obj_status.GetComponent<status>();
        
        if(script_status.fase == 2){
                if(script_status.Pregos == true){
                    
                    // Encontramos os objetos desejados (icones dos itens coletados e não coletados)
                    canos = GameObject.Find("Pregos");
                    canos_cor = GameObject.Find("Pregos cor");

                    if (canos != null && canos_cor != null){

                        // Verificar se o componente Image está presente
                        Image imageComponent = canos.GetComponent<Image>();
                        Image imageComponent2 = canos_cor.GetComponent<Image>();

                        if (imageComponent != null && imageComponent2 != null){

                            // Aqui apagamos o icone de quando nao possuímos o item e ativamos o icone de quando possuímos.
                            imageComponent.fillAmount = 0;
                            imageComponent2.fillAmount = 1;  

                    } 
        
                }

                if(script_status.Caixa == true){
                    
                    // Encontramos os objetos desejados (icones dos itens coletados e não coletados)
                    caixa = GameObject.Find("Barril");
                    caixa_cor = GameObject.Find("Barril cor");

                    if(caixa != null && caixa_cor != null){

                        // Verificar se o componente Image está presente
                        Image imageComponent = caixa.GetComponent<Image>();
                        Image imageComponent2 = caixa_cor.GetComponent<Image>();

                        if (imageComponent != null && imageComponent2 != null){
                            
                            // Aqui apagamos o icone de quando nao possuímos o item e ativamos o icone de quando possuímos.
                            imageComponent.fillAmount = 0;  
                            imageComponent2.fillAmount = 1;

                        }
                    }
                }
            }

        }
    }
}
