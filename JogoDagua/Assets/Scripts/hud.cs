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
using Unity.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

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


    private GameObject Casa;
    private vitoria Script_Vitoria;
   

    private GameObject Layer;
    private GameObject Layer_MAP3;
    private GameObject Layer_MAP1;

    void Start()
    {
        objeto = GameObject.Find("Status");         //Vamos acessar o objeto Status
        script = objeto.GetComponent<status>();     //E seu script

        Layer_MAP3 = GameObject.FindGameObjectWithTag("Layer_MAP3");
        Layer_MAP1 = GameObject.FindGameObjectWithTag("Layer_MAP1");

        if (script.fase < 3){
            Casa = GameObject.Find("Casa");
            Script_Vitoria = Casa.GetComponent<vitoria>();
            Layer = GameObject.Find("Layer");
            if (Layer != null){
                print("Achamos a layer");
                Layer.SetActive(false);
            }
        } else {

        } 
    }
    // Update is called once per frame com uma taxa fixa
    void Update () {
        barra();                //Vamos atualiza a barra de vida
        pontuacao();            //Vamos atualizar a pontuação

        if(script.fase != 3){
            if (Script_Vitoria.Testezinho == true){
                if (Layer != null){   
                    Layer.SetActive(true);
                }
            }
        }
        
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

    public void teste(){
        if (script.fase == 1){
            SceneManager.LoadScene(3);
            Time.timeScale = 1f;
            script.fase = 2;
        }

        else if (script.fase == 2){
            SceneManager.LoadScene(4);
            Time.timeScale = 1f;
            script.fase = 3;
        }

        
    }

    public void Continue(){
        Time.timeScale = 1f;
        if (script.fase == 3){
            Layer_MAP3.SetActive(false);
        }
        if (script.fase == 1){
            Layer_MAP1.SetActive(false);
        }
            
    }
}