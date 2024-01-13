/*
JOGO DA ÁGUA: Controle dos status do personagem
Desenvolvido por:     Jhordan Silveira de Borba
E-mail:               jhordandecacapava@gmail.com
Website:              https://sapogithub.github.io
Mais informações:     https://github.com/SapoGitHub/Repositorio-Geral/wiki/Jogo-da-%C3%A1gua
2018
*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class hud : MonoBehaviour {

    [SerializeField]
    private Image conteudo;         //Onde vamos mexer com a imagem que mostra a porcentagem da vida

    [SerializeField]
    private Text valor;             //A mensagem em texto da vida

    [SerializeField]
    private Text ponto_hud;         //A pontuação

    private float preenchido;       //O valor da vida entre 0 e 1
    private float vidatela;         //O valor em texto que vai exibir na tela
    private GameObject objeto;      //Objeto que contém os status do personagem
    private status script;          //Script que contém os status do personagem


    void Start()
    {
        objeto = GameObject.Find("Status");         //Vamos acessar o objeto Status
        script = objeto.GetComponent<status>();     //E seu script
    }
    // Update is called once per frame com uma taxa fixa
    void FixedUpdate () {
        barra();                //Vamos atualiza a barra de vida
        pontuacao();            //Vamos atualizar a pontuação
    }

    //Função para atualizar a barra de vida
    private void barra()
    {
        if(script.fase != 3){
            preenchido = 1 - (script.Vida / 100);       //Convertamos pra escala entre 0 e 1
            if (preenchido != conteudo.fillAmount) {      //Se a vida atual é diferente da salva
                    conteudo.fillAmount = preenchido;    
            }  //Atualizamos

    
            //Vamos configurar pra printar na tela só com uma diferença de 1 ponto
            vidatela = script.Vida - script.Vida % 1;
            valor.text = "" + vidatela;
        }else {
            
        }
       
    }

    //Função para atualizar a pontuação na tela
    private void pontuacao()
    {
        ponto_hud.text = "" + script.Pontos;        //Simplesmente printamos na tela os pontos
    }
}