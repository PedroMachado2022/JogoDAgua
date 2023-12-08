/*SCRIPT PARA O CONTROLE DE GAMEOBJECTS Q USAO FERRAMENTA
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
using UnityEngine;
using UnityEngine.UI;
using System;


public class interacao_ferramenta : MonoBehaviour
{

    private bool dentro;        //Variável para indicar se estamos dentro do objeto
    private Animator animator;  //Onde vamos guardar a componente correspondente
    private GameObject obj_botao;      //Onde vamos guardar o GameObject do botão
    private bool acao;          //Variável que nos diz se vamos utilizar a ação
    private botao script_botao;        //Para acessar as variáveis do nosso botão
    private GameObject obj_status;  //Para acessar o status
    private status script_status;      //Para acessar as variáveis do script
    private GameObject obj_pensamento;    //GameObject do pensamento
    public GameObject bd;
    public Mybdscript script_bd;
    public string momento_de_criacao;
    public bool criada;

    [SerializeField]
    private Text texto;         //Texto do pensamento
    [SerializeField]
    public int id_acao;


    [SerializeField]
    private Image icone_com;         //Onde vamos mexer com a imagem que mostra que já pegamos o objeto

    [SerializeField]
    private Image icone_sem;            //Onde vamos mexer com a imagem que mostra que não pegamos o objeto

    [SerializeField]
    private Text qt;             //Quantidade do item em questão

    [SerializeField]
    private string tipo;

    [SerializeField]
    private string item;

    [SerializeField]
    private int id_ação;

    //Função para marcar que entramos dentro
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        obj_pensamento.GetComponent<Image>().enabled = true;
        if (tipo == "Canos")
        {
            if (animator.GetBool("desligado") == true)
            {
                texto.text = "Estragar Canos?";
            }
            else if (script_status.Ferramentas > 0 )
            {
                texto.text = "Concertar Canos?";
            }
            else
            {
                texto.text = "Você não tem ferramentas!";
            }
        }else if(tipo == "Jardineiro")
        {
            if (animator.GetBool("desligado") == true)
            {
                texto.text = "Trocar por mangueira?";
            }
            else if (script_status.Regador > 0)
            {
                texto.text = "Trocar por regador?";
            }
            else
            {
                texto.text = "Você não tem regador!";
            }
        }
        else if(tipo == "Vaso")
        {
            if (animator.GetBool("concertado") == true)              //Se estava concertado
            {
                texto.text = "Estragar o vaso?";
            }
            else if (script_status.Ferramentas > 0)                         //E temos ferramentas
            {
                texto.text = "Arrumar o vaso?";
            }
            else                                                //Mas se não temos
            {
                texto.text = "Você não tem ferramentas!";
            }
                    
            
        }
        script_botao.dentro = true;    //Avisamos o botão
        dentro = true;          //E nosso código atual

    }

    //Função para marcar que saímos de dentro
    private void OnTriggerExit2D(Collider2D collision)
    {
        texto.text = "";                                //Limpamos a mensagem
        obj_pensamento.GetComponent<Image>().enabled = false;     //Removemos o pensamento
        script_botao.dentro = false;                           //Mesma coisa da função anterior
        dentro = false;                                 //Registramos
    }

    private void Start()
    {
        animator = GetComponent<Animator>();    //Pegamos a componente correspondente
        obj_botao = GameObject.Find("Ação");           //Pegamos o GameObject do botão
        script_botao = obj_botao.GetComponent<botao>();       //E o script do botão
        obj_status = GameObject.Find("Status");     //Vamos acesasr o objeto do status
        script_status = obj_status.GetComponent<status>(); //Acessar o seu script
        obj_pensamento = GameObject.Find("Pensamento");
        //bd = GameObject.Find("Mybd");           //Pegamos o GameObject do botão
        //script_bd = bd.GetComponent<Mybdscript>();
    }

    void Update()
    {
        entrada();      //Função para checar as entradas
        
        //Se estamos dentro
        if (dentro == true)
        {
            //Se devemos aplicar a ação
            if (acao == true || script_botao.acao == true)           //Se teclou enter ou tinha pressionado o botão de ação na tela
            {   
                script_botao.acao = acao = false;                          //Desativamos o botão
                
                //Debug.Log("ferramentas=" + script_status.Ferramentas);
               // Debug.Log("tipo=" + tipo);
                if (tipo == "Canos")
                {

                    
                    if ((animator.GetBool("desligado") == false) && (script_status.Ferramentas > 0))//////////////////// concertando
                    {
                        texto.text = ("Quebrar canos?");
                        animator.SetBool("desligado", true);
                        script_status.Pontos = script_status.Pontos + 10;
                        script_status.vazamento = script_status.vazamento - 1;

                        script_status.Ferramentas = script_status.Ferramentas - 1;
                        qt.text = "" + script_status.Ferramentas;
                        if (script_status.Ferramentas == 0)
                        {
                            icone_sem.fillAmount = 1;
                            icone_com.fillAmount = 0;
                            qt.text = "";
                        }
                        if (criada)
                        {
                            script_bd.Insert_in_jogadas(script_status.jogo, script_status.fase, script_status.Pontos, Convert.ToInt32(script_status.Vida), id_ação, item, "fechou", "boa", momento_de_criacao, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        }
                        else
                        {
                            momento_de_criacao = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            criada = true;
                        }
                        script_bd.Insert_in_jogadas(script_status.jogo, script_status.fase, script_status.Pontos, Convert.ToInt32(script_status.Vida), id_ação, item, "fechou", "boa", momento_de_criacao, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));



                    }
                    else if (animator.GetBool("desligado") == true)
                    {
                        texto.text = ("Concertar canos?");
                        animator.SetBool("desligado", false);
                        script_status.Pontos = script_status.Pontos - 12;
                        script_status.vazamento = script_status.vazamento + 1;
                        if (script_status.Pontos < 0)
                        { script_status.Pontos = 0; }

                        script_status.Ferramentas = script_status.Ferramentas + 1;
                        qt.text = "" + script_status.Ferramentas;

                        if (script_status.Ferramentas == 1)
                        {
                            icone_sem.fillAmount = 0;
                            icone_com.fillAmount = 1;
                        }
                        if (criada)
                        {
                            script_bd.Insert_in_jogadas(script_status.jogo, script_status.fase, script_status.Pontos, Convert.ToInt32(script_status.Vida), id_ação, item, "abriu","ruim", momento_de_criacao, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        }
                        else
                        {
                            momento_de_criacao = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            criada = true;
                        }
                        script_bd.Insert_in_jogadas(script_status.jogo, script_status.fase, script_status.Pontos, Convert.ToInt32(script_status.Vida), id_ação, item, "abriu", "ruim", momento_de_criacao, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                    }
                }
                if (tipo == "Jardineiro")/////////////////////////
                {
                    if ((animator.GetBool("desligado") == false) && (script_status.Regador > 0))//////////////////// colocando regador
                    {
                        texto.text = ("Trocar por Mangueira?");
                        animator.SetBool("desligado", true);
                        script_status.Pontos = script_status.Pontos + 10;
                        script_status.vazamento = script_status.vazamento - 1;

                        script_status.Regador = script_status.Regador - 1;
                        qt.text = "" + script_status.Regador;
                        if (script_status.Regador == 0)
                        {
                            icone_sem.fillAmount = 1;
                            icone_com.fillAmount = 0;
                            qt.text = "";
                        }
                        if (criada)
                        {
                            script_bd.Insert_in_jogadas(script_status.jogo, script_status.fase, script_status.Pontos, Convert.ToInt32(script_status.Vida), id_ação, item, "fechou", "boa", momento_de_criacao, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        }
                        else
                        {
                            momento_de_criacao = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            criada = true;
                        }
                        script_bd.Insert_in_jogadas(script_status.jogo, script_status.fase, script_status.Pontos, Convert.ToInt32(script_status.Vida), id_ação, item, "fechou", "boa", momento_de_criacao, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));


                    }
                    else if (animator.GetBool("desligado") == true)
                    {
                        texto.text = ("Trocar por Regador?");
                        animator.SetBool("desligado", false);
                        script_status.Pontos = script_status.Pontos - 12;
                        script_status.vazamento = script_status.vazamento + 1;
                        if (script_status.Pontos < 0)
                        { script_status.Pontos = 0; }

                        script_status.Regador = script_status.Regador + 1;
                        qt.text = "" + script_status.Regador;

                        if (script_status.Regador == 1)
                        {
                            icone_sem.fillAmount = 0;
                            icone_com.fillAmount = 1;
                        }
                        if (criada)
                        {
                            script_bd.Insert_in_jogadas(script_status.jogo, script_status.fase, script_status.Pontos, Convert.ToInt32(script_status.Vida), id_ação, item, "abriu", "ruim", momento_de_criacao, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        }
                        else
                        {
                            momento_de_criacao = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            criada = true;
                        }
                        script_bd.Insert_in_jogadas(script_status.jogo, script_status.fase, script_status.Pontos, Convert.ToInt32(script_status.Vida), id_ação, item, "abriu", "ruim", momento_de_criacao, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                    }
                }
                if (tipo == "Vaso")
                {

                    if (animator.GetBool("concertado") == true)              //Se estava desligado
                    {
                        { texto.text = "Arrumar Vaso?"; }
                        animator.SetBool("concertado", false);               //Ligamos
                        script_status.Pontos = script_status.Pontos - 12;                 //Diminuimos 12 pontos
                        script_status.vazamento = script_status.vazamento + 1;            //Anotamos que temos mais um item vazando
                        if (script_status.Pontos < 0)                              //Se ficou negativo
                        { script_status.Pontos = 0; }                              //Zeramos

                        //Recuperamos a ferramenta então
                        script_status.Ferramentas = script_status.Ferramentas + 1;
                        qt.text = "" + script_status.Ferramentas;
                        //E se tínhamos zero, alteramos o ícone
                        if (script_status.Ferramentas == 1)
                        {
                            icone_sem.fillAmount = 0;           //Escondemos a imagem que diz que não foi pego o objeto
                            icone_com.fillAmount = 1;       //Mostramos a que diz que pegamos o objeto
                        }
                        if (criada)
                        {
                            script_bd.Insert_in_jogadas(script_status.jogo, script_status.fase, script_status.Pontos, Convert.ToInt32(script_status.Vida), id_ação, item, "abriu", "ruim", momento_de_criacao, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        }
                        else
                        {
                            momento_de_criacao = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            criada = true;
                        }
                        script_bd.Insert_in_jogadas(script_status.jogo, script_status.fase, script_status.Pontos, Convert.ToInt32(script_status.Vida), id_ação, item, "abriu", "ruim", momento_de_criacao, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                    }

                    if (animator.GetBool("concertado") == false && script_status.Ferramentas > 0)  //Se estava ligado
                    {
                        texto.text = "Estragar vaso?";
                        animator.SetBool("concertado", true);                //Desligamos
                        script_status.Pontos = script_status.Pontos + 10;                 //Somamos 10 pontos
                        script_status.vazamento = script_status.vazamento - 1;            //Anotamos que temos menos um item vazando

                        //Gastamos a ferramenta
                        script_status.Ferramentas = script_status.Ferramentas - 1;
                        qt.text = "" + script_status.Ferramentas;
                        //Se zerou, mexemos nos ícones
                        if (script_status.Ferramentas == 0)
                        {
                            icone_sem.fillAmount = 1;           //Escondemos a imagem que diz que não foi pego o objeto
                            icone_com.fillAmount = 0;       //Mostramos a que diz que pegamos o objeto
                            qt.text = "";
                        }
                        if (criada)
                        {
                            script_bd.Insert_in_jogadas(script_status.jogo, script_status.fase, script_status.Pontos, Convert.ToInt32(script_status.Vida), id_ação, item, "fechou", "boa", momento_de_criacao, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        }
                        else
                        {
                            momento_de_criacao = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            criada = true;
                        }
                        script_bd.Insert_in_jogadas(script_status.jogo, script_status.fase, script_status.Pontos, Convert.ToInt32(script_status.Vida), id_ação, item, "fechou", "boa", momento_de_criacao, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                    }
                }
            }
        }
}

    //Função para receber as entradas
    public void entrada()
    {
        if (Input.GetKeyDown(KeyCode.Return))     //Se apertamos Enter
        {
            if (dentro == true)                   //E estamos dentro
            { acao = true; }        //Registramos
        }
    }
}