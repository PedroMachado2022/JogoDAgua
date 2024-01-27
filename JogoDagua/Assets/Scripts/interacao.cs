/*
JOGO DA ÁGUA: Controle das interações com objetos sem ferramentas
Desenvolvido por:     Jhordan Silveira de Borba
E-mail:               jhordandecacapava @gmail.com
Website:              https://sapogithub.github.io
Mais informações:     https://github.com/SapoGitHub/Repositorio-Geral/wiki/Jogo-da-%C3%A1gua
2018
*
Atualizado por:     Thayllor Peres Devos dos Santos
E-mail:               thayllordossantos@gmail.com
2019
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class interacao : MonoBehaviour
{
    private bool dentro;        //Variável para indicar se estamos dentro do objeto
    private Animator animator;  //Onde vamos guardar a componente correspondente
    private GameObject obj_botao_ação;      //Onde vamos guardar o GameObject do botão
    private bool acao;          //Variável que nos diz se vamos utilizar a ação
    private botao script_botao_ação;        //Para acessar as variáveis do nosso botão
    private GameObject obj_status;  //Para acessar o status
    private status script_status;      //Para acessar as variáveis do script
    private GameObject obj_pensamento;    //GameObject do pensamento
    private bool regador;
    private bool ja_criado;
    private bool usou_nuvem;
    private string momento_decriação;
    private string datahora;
    public GameObject bd;
    public Mybdscript script_bd;


    [SerializeField]
    private Text texto;         //Texto do pensamento

    [SerializeField]
    private string item;

    [SerializeField]
    private int id_ação;

    //Função para marcar que entramos dentro
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((item == "Nuvem") && (usou_nuvem == true))
        {
            //faz nada
        }
           //Colocamos o pensamento na tela
        else if ((item == "Nuvem") && (usou_nuvem == false))
        {
            obj_pensamento.GetComponent<Image>().enabled = true;
            texto.text = "Fazer Chuver?";
        }
        else if (animator.GetBool("desligado") == true)              //Se estava desligado
        {
            obj_pensamento.GetComponent<Image>().enabled = true;
            if (item == "Chuveiro")                             //E for o chuveiro
            { texto.text = "Abrir o chuveiro?"; }

            else if (item == "Máquina")
            { texto.text = "Ligar máquina?"; }

            else if (item == "Tanque")
            { texto.text = "Abrir torneira?"; }

            else if (item == "Pia")
            { texto.text = "Abrir torneira?"; }

            else if (item == "Torneira")
            { texto.text = "Abrir torneira"; }

            else if (item == "Cano")
            { texto.text = "Quebrar Canos"; }

            else if (item == "Jardineiro")
            { texto.text = "Trocar por Mangueira"; }


        }
        else                                                    //Se estava ligado
        {
            obj_pensamento.GetComponent<Image>().enabled = true;
            if (item == "Chuveiro")
            { texto.text = "Fechar chuveiro?"; }

            else if (item == "Máquina")
            { texto.text = "Desligar máquina?"; }

            else if (item == "Tanque")
            { texto.text = "Fechar torneira?"; }

            else if (item == "Pia")
            { texto.text = "Fechar torneira?"; }

            else if (item == "Torneira")
            { texto.text = "Fechar torneira?"; }

            else if (item == "Canos")
            { texto.text = "Concertar Canos?"; }

            else if (item == "Jardineiro")
            { texto.text = "Trocar por Regador"; }

        }

        script_botao_ação.dentro = true;    //Avisamos o botão
        dentro = true;          //E nosso código atual
    }

    //Função para marcar que saímos de dentro
    private void OnTriggerExit2D(Collider2D collision)
    {
        texto.text = "";                                //Limpamos a mensagem
        obj_pensamento.GetComponent<Image>().enabled = false;     //Removemos o pensamento
        script_botao_ação.dentro = false;                           //Mesma coisa da função anterior
        dentro = false;                                 //Registramos
    }

    private void Start()
    {
        ja_criado = false;
        animator = GetComponent<Animator>();    //Pegamos a componente correspondente
        obj_botao_ação = GameObject.Find("Ação");           //Pegamos o GameObject do botão
        script_botao_ação = obj_botao_ação.GetComponent<botao>();       //E o script do botão
        obj_status = GameObject.Find("Status");     //Vamos acesasr o objeto do status

        script_status = obj_status.GetComponent<status>(); //Acessar o seu script
        obj_pensamento = GameObject.Find("Pensamento");
        //bd = GameObject.Find("Mybd");           //Pegamos o GameObject do botão
        //script_bd = bd.GetComponent<Mybdscript>();
        usou_nuvem = false;
    }

    void Update()
    {
        

        //Se estamos dentro
        if (dentro == true)
        {
            //Se devemos aplicar a ação
            if (acao == true || script_botao_ação.acao == true)           //Se teclou enter ou tinha pressionado o botão de ação na tela
            {
                datahora = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                //print(datahora);
                if ((item == "Nuvem")&&(usou_nuvem==false))
                {
                    script_status.Vida = 100;
                    animator.SetBool("usando", true);
                    usou_nuvem = true;
                }
                else if (animator.GetBool("desligado") == true)              //Se estava desligado
                {
                    if (item == "Chuveiro")
                    { texto.text = "Fechar chuveiro?"; }
                    else if (item == "Máquina")
                    { texto.text = "Desligar máquina?"; }
                    else if ((item == "Tanque") || (item == "Pia") || (item == "Torneira"))
                    { texto.text = "Fechar torneira?"; }
                    else if (item == "Jardineiro")
                    { texto.text = "Trocar por Regador?"; }


                    script_botao_ação.acao = acao = false;                          //Desativamos o botão
                    animator.SetBool("desligado", false);               //Ligamos
                    script_status.Pontos -=   12;                 //Diminuimos 12 pontos
                    script_status.vazamento +=   1;            //Anotamos que temos mais um item vazando
                    script_status.abertos += 1;

                    if (script_status.Pontos < 0)                              //Se ficou negativo
                    { script_status.Pontos = 0; }                              //Zeramos
                    

                    //(int jogo_id, int fase, int pontos, int vida, int objeto_id, string objeto, string acao, string intencao, string created, string modified)
                    //script_bd.Insert_in_jogadas(script_status.jogo, script_status.fase, script_status.Pontos, Convert.ToInt32(script_status.Vida), id_ação, item, "abriu", "ruim", momento_decriação,datahora);

                }
                else                                                    //Se estava ligado
                {
                    if (item == "Chuveiro")
                    { texto.text = "Abrir chuveiro?"; }
                    else if (item == "Máquina")
                    { texto.text = "Ligar máquina?"; }
                    else if ((item == "Tanque") || (item == "Pia") || (item == "Torneira"))
                    { texto.text = "Abrir torneira?"; }
                    else if (item == "Jardineiro")
                    { texto.text = "Trocar por Mangueira?"; }

                    script_botao_ação.acao = acao = false;                          //Desativamos o botão
                    animator.SetBool("desligado", true);                //Desligamos
                    script_status.Pontos = script_status.Pontos + 10;                 //Somamos 10 pontos
                    script_status.vazamento = script_status.vazamento - 1;            //Anotamos que temos menos um item vazando

                    //////////conexão
                    // if (ja_criado == false)
                    // {
                        
                    //     momento_decriação = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    //     script_bd.Insert_in_jogadas(script_status.jogo, script_status.fase, script_status.Pontos, Convert.ToInt32(script_status.Vida), id_ação, item, "fechou", "boa",
                    //     momento_decriação, momento_decriação);
                    //     ja_criado = true;

                    // }
                    // else
                    // {
                    //                      //(int jogo_id, int fase, int pontos, int vida, int objeto_id, string objeto, string acao, string intencao, string created, string modified)
                    //     script_bd.Insert_in_jogadas(script_status.jogo, script_status.fase, script_status.Pontos, Convert.ToInt32(script_status.Vida), id_ação, item, "fechou", "boa",
                    //      momento_decriação, String.Format("{0:u}", datahora));
                    // }
                }
            }
        }
    }
}


