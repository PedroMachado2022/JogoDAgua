/*
JOGO DA ÁGUA: Controle das interações a porta final
Desenvolvido por:     Jhordan Silveira de Borba
E-mail:               jhordandecacapava@gmail.com
Website:              https://sapogithub.github.io
Mais informações:     https://github.com/SapoGitHub/Repositorio-Geral/wiki/Jogo-da-%C3%A1gua
2018
]*
Atualizado por:     Thayllor Peres Devos dos Santos
E-mail:               thayllordossantos@gmail.com
2019
*/

using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class vitoria : MonoBehaviour
{

    private GameObject obj_status;  //Para acessar o status
    private status script_status;
    public GameObject bd;
    public Mybdscript script_bd;

    //Função para marcar que entramos dentro
    private void Start()
    {
        obj_status = GameObject.Find("Status");     //Vamos acesasr o objeto do status
        script_status = obj_status.GetComponent<status>();
        //bd = GameObject.Find("Mybd");           //Pegamos o GameObject do botão
        //script_bd = bd.GetComponent<Mybdscript>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    { 
        //Se temos a chave
        if (script_status.Chave == true)
        {
            script_bd.Salvar();
            if (Application.internetReachability != NetworkReachability.NotReachable)
            {
                //tem internet
                
                script_bd.EnviarProBanco();
            }
            if (script_status.fase == 1)
            {
                string datahora = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");


                //(              int user_id,   string dificuldade,    int finalizado,     int pontos      ,       int problemas              ,     int abertos      ,     string mascote    ,   string created     ,         string modified               )
                script_bd.Insert_in_jogo(script_bd.idjogo,   0      ,   script_status.difi,          1       , script_status.Pontos,   11-  script_status.vazamento, script_status.abertos, script_status.mascote , script_status.criada , datahora);
                script_status.Chave = false;
                script_status.Vida = 100;
                script_status.vazamento = 8;
                script_status.Regador = 0;
                script_status.Ferramentas = 0;
                script_status.fase = 2;

                SceneManager.LoadScene(3);  //Carregamos a próxima cena
            }
            else
            {
                script_bd.Salvar();
                if (Application.internetReachability != NetworkReachability.NotReachable)
                {
                    //tem internet
                    
                    script_bd.EnviarProBanco();
                }
                SceneManager.LoadScene(4);  //Carregamos a final
            }
            
        }
    }
}