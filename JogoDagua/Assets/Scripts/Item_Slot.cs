/*
Desenvolvido por:     Pedro Machado Araújo
E-mail:               pedro.machado.rs@hotmail.com
GitHUB:               PedroMachado2022
2024
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// Script responsável pela parte de receber os itens da mecânica "Drag and Drop".
public class Item_Slot : MonoBehaviour, IDropHandler{ 

    [SerializeField] private RectTransform _transform;
    private GameObject obj_status;
    private status script_status;

     private void Start(){

        // Acessamos o Objeto "Status" dentro da cena
        obj_status = GameObject.Find("Status"); 

        // Acessamos o script "status" dentro do objeto "Status"
        script_status = obj_status.GetComponent<status>();
    }

    
    // Função da unity que recebe o item da mecanica "Drag and Drop"
    public void OnDrop(PointerEventData eventData){

        // Pegamos o objeto que será arrastado pelo mouse
        GameObject draggedObject = eventData.pointerDrag;
        
        // Verificamos se ele não é nulo
        if (draggedObject != null){

            // Pegamos o transform do mesmo 
            RectTransform draggedTransform = draggedObject.GetComponent<RectTransform>();

            // Verificamos se não é nulo (evitar erros)
            if (draggedTransform != null){

                // Verificamos se o item de destino tem a tag desejada
                if (gameObject.CompareTag("Caixa_Reservatorio")){

                    // Verificamos se o item sendo arrastado tem a tag desejada
                    if (draggedObject.CompareTag("Caixa")){
                        
                        // Colocamos os dois transforms exatamente no mesmo ponto, para dar a aparência de encaixe. (itens precisam ter o mesmo tamanho)
                        draggedTransform.anchoredPosition = _transform.anchoredPosition;

                        // Adicionamos 1 ponto na nossa condição de vitória (6 itens encaixados);
                        script_status.win_Condition += 1;

                    }
                }
                
                // Verificamos se o item de destino tem a tag desejada
                else if (gameObject.CompareTag("Plataforma_Reservatorio")){
                    
                    // Verificamos se o item sendo arrastado tem a tag desejada
                    if (draggedObject.CompareTag("Plataforma")){

                        // Colocamos os dois transforms exatamente no mesmo ponto, para dar a aparência de encaixe. (itens precisam ter o mesmo tamanho)
                        draggedTransform.anchoredPosition = _transform.anchoredPosition;

                        // Adicionamos 1 ponto na nossa condição de vitória (6 itens encaixados);
                        script_status.win_Condition += 1;
                    }
                }

                // Verificamos se o item de destino tem a tag desejada
                else if (gameObject.CompareTag("Cano1_Reservatorio")){

                    // Verificamos se o item sendo arrastado tem a tag desejada
                    if (draggedObject.CompareTag("Canos")){

                        // Colocamos os dois transforms exatamente no mesmo ponto, para dar a aparência de encaixe. (itens precisam ter o mesmo tamanho)
                        draggedTransform.anchoredPosition = _transform.anchoredPosition;

                        // Adicionamos 1 ponto na nossa condição de vitória (6 itens encaixados);
                        script_status.win_Condition += 1;
                    }
                } 

                // Verificamos se o item de destino tem a tag desejada
                else if (gameObject.CompareTag("Cano2_Reservatorio")){

                    // Verificamos se o item sendo arrastado tem a tag desejada
                    if (draggedObject.CompareTag("Cano 2")){

                        // Colocamos os dois transforms exatamente no mesmo ponto, para dar a aparência de encaixe. (itens precisam ter o mesmo tamanho)
                        draggedTransform.anchoredPosition = _transform.anchoredPosition;

                        // Adicionamos 1 ponto na nossa condição de vitória (6 itens encaixados);
                        script_status.win_Condition += 1;
                    }
                }
                
                // Verificamos se o item de destino tem a tag desejada
                else if (gameObject.CompareTag("Cano3_Reservatorio")){

                    // Verificamos se o item sendo arrastado tem a tag desejada
                    if (draggedObject.CompareTag("Cano 3")){

                        // Colocamos os dois transforms exatamente no mesmo ponto, para dar a aparência de encaixe. (itens precisam ter o mesmo tamanho)
                        draggedTransform.anchoredPosition = _transform.anchoredPosition;

                        // Adicionamos 1 ponto na nossa condição de vitória (6 itens encaixados);
                        script_status.win_Condition += 1;
                    }
                }
                
                // Verificamos se o item de destino tem a tag desejada
                else if (gameObject.CompareTag("Filtro_Reservatorio")){

                    // Verificamos se o item sendo arrastado tem a tag desejada
                    if (draggedObject.CompareTag("Filtro")){

                        // Colocamos os dois transforms exatamente no mesmo ponto, para dar a aparência de encaixe. (itens precisam ter o mesmo tamanho)
                        draggedTransform.anchoredPosition = _transform.anchoredPosition;

                        // Adicionamos 1 ponto na nossa condição de vitória (6 itens encaixados);
                        script_status.win_Condition += 1;
                    }
                }
            }
        }
    }
}
