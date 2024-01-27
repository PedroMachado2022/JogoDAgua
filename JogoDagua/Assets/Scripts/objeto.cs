/*
JOGO DA ÁGUA: Objetos
Desenvolvido por:     Jhordan Silveira de Borba
E-mail:               jhordandecacapava@gmail.com
Website:              https://sapogithub.github.io
Mais informações:     https://github.com/SapoGitHub/Repositorio-Geral/wiki/Jogo-da-%C3%A1gua
2018
*/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class objeto : MonoBehaviour {

    [SerializeField]
    private Image icone_cor;         //Onde vamos mexer com a imagem que mostra que já pegamos o objeto

    [SerializeField]
    private Image icone;            //Onde vamos mexer com a imagem que mostra que não pegamos o objeto

    [SerializeField]
    private string obj;             //Qual objeto pegamos

    private GameObject obj_status;  //Para acessar o status
   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        icone.fillAmount = 0;           //Escondemos a imagem que diz que não foi pego o objeto
        icone_cor.fillAmount = 1;       //Mostramos a que diz que pegamos o objeto
        gameObject.GetComponent<SpriteRenderer>().enabled = false;      //Desativamos o renderer do atual objeto

        GameObject objeto = GameObject.Find("Status");      //Vamos acesasr o objeto do status
        status script = objeto.GetComponent<status>();      //Acessar o seu script

        if (obj == "Plataforma") {                           //Se o objeto atual é a plataforma
        
            script.Plataforma = true; 
            Debug.Log("Tocamos na plataforma"); 
            Debug.Log(script.Plataforma);
        }                       
        else if (obj=="Filtro")  {                           //O mesmo para o filtro
            
                script.Filtro = true; 
        
        }
        else if (obj == "Canos") {                          //Os pregos
            
                script.Pregos = true; 
        
        }
        else if (obj == "Caixa") {                           //Ou a caixa
         
                script.Caixa = true; 
        
        }                       
        else if (obj=="Chave")  {                            //Ou a chave
         
                script.Chave = true; 
         
        }
    }
}
