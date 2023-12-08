/*
JOGO DA ÁGUA: Controle da tela final
Desenvolvido por:     Jhordan Silveira de Borba
E-mail:               jhordandecacapava@gmail.com
Website:              https://sapogithub.github.io
Mais informações:     https://github.com/SapoGitHub/Repositorio-Geral/wiki/Jogo-da-%C3%A1gua
2018
*
Atualizado por:     Thayllor Peres Devos dos Santos
E-mail:               thayllordossantos@gmail.com
2019
*/

using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class final : MonoBehaviour {

    [SerializeField]
    private Text msg;             //A mensagem em texto de derrota;
    public Text erro;
    public GameObject bd;
    public Mybdscript script_bd;


    // Use this for initialization
    void Start () {
        string datahora = DateTime.Now.ToString("yyyy-MM-dd- HH:mm:ss");
        GameObject status = GameObject.Find("Status");  //Vamos pegar o objeto da cena anterior
        status script_status = status.GetComponent<status>();    //Seu script
        GameObject bd = GameObject.Find("Mybd");           //Pegamos o GameObject do botão
        Mybdscript script_bd = bd.GetComponent<Mybdscript>();



        //                  (   int user_id,   string dificuldade,    int finalizado,     int pontos      ,       int problemas              ,     int abertos            ,     string mascote    ,   string created     , string modified)
        script_bd.Insert_in_jogo(    script_bd.idjogo, 0     , script_status.difi  ,         2        , script_status.Pontos, 11 - script_status.vazamento     , script_status.abertos      , script_status.mascote , script_status.criada , datahora);
        script_bd.Salvar();
        if (Application.internetReachability!=NetworkReachability.NotReachable)
        {
            //tem internet
            
            script_bd.EnviarProBanco();
        }

        if (script_status.perdeu==true)         //Se perdeu
        { 

            msg.text = "Acabou a água! Tente novamente Pontuação: " + script_status.Pontos;
            
        }
        else                            //Se vencemos
        {
            msg.text = "Parabéns você finalizou o jogo! Pontuação: " + script_status.Pontos;
            
        }
        GameObject.Destroy(status);
        GameObject.Destroy(bd);


    }
    private void Update()
    {

        GameObject teste= GameObject.Find("Teste");
        Text tex = teste.GetComponent<Text>();
        tex.text = erro.text;
    }
    public void reinicar()
    {
        SceneManager.LoadScene(1);                  //Carregamos a próxima cena
    }
}
