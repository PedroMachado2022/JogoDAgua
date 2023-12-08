using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ferramentas : MonoBehaviour {


    [SerializeField]
    private Image icone_cor;         //Onde vamos mexer com a imagem que mostra que já pegamos o objeto

    [SerializeField]
    private Image icone;            //Onde vamos mexer com a imagem que mostra que não pegamos o objeto

    [SerializeField]
    private Text texto;             //Quantidade do item em questão

    [SerializeField]
    private string obj;             //Qual objeto pegamos

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (icone.fillAmount == 1)          //Se atualmente 
        {
            icone.fillAmount = 0;           //Escondemos a imagem que diz que não foi pego o objeto
            icone_cor.fillAmount = 1;       //Mostramos a que diz que pegamos o objeto
        }

        gameObject.GetComponent<SpriteRenderer>().enabled = false;      //Desativamos o renderer do atual objeto
        gameObject.GetComponent<BoxCollider2D>().enabled = false;       //Desativamos o BoxCollider2D

        GameObject objeto = GameObject.Find("Status");      //Vamos acesasr o objeto do status
        status script = objeto.GetComponent<status>();      //Acessar o seu script

        if (obj == "Regador")                              //Se o objeto atual é o regador
        {
            script.Regador = script.Regador + 1;          //Registramos que pegamos mais um
            texto.text = "" + script.Regador;             //Printamos na tela    
        }
        else if (obj == "Ferramentas")                  //E fazemos o mesmo com as ferramentas
        {
            script.Ferramentas = script.Ferramentas + 1;
            texto.text = "" + script.Ferramentas;
        }
    }
}
