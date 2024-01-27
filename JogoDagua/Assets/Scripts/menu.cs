/*
JOGO DA ÁGUA: Controle do menu inicial
Desenvolvido por:     Jhordan Silveira de Borba
E-mail:               jhordandecacapava@gmail.com
Website:              https://sapogithub.github.io
Mais informações:     https://github.com/SapoGitHub/Repositorio-Geral/wiki/Jogo-da-%C3%A1gua
2018
*/
/*
 * 
Atualizado por:     Thayllor Peres Devos dos Santos
E-mail:               thayllordossantos@gmail.com
2019
 */

using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement; //Para cuidar do gerenciamento de cenas

public class menu : MonoBehaviour {

    public bool alternativo;        //Se vamos usar a skin alternativa
    public float dificuldade;         //Defini nosso nível de dificuldade
    public string difi;             // string pro bd
    public string criada;
    public string mascote;
    public int jogo;
    public GameObject bd;
    public Mybdscript script_bd;


    public void Start()
    {
        DontDestroyOnLoad(this); //Não queremos que esse objeto seja destruído logo após chamarmos outra cena
        bd = GameObject.Find("Mybd");           //Pegamos o GameObject do botão
        script_bd = bd.GetComponent<Mybdscript>();
        jogo = script_bd.qual_jogo();
        dificuldade = 0.2f;
        difi = "facil";
    }
	
    //Função para chamar quando clicarmos no botão de dificuldade fácil
    public void botao_facil()
    {

        GameObject objeto = GameObject.Find("Fácil");   //Encontramos nosso botão
        Image imagem = objeto.GetComponent<Image>();    //Pegamos o componente Image
        imagem.color = Color.white;                     //E destacamos

        //Fazemos o mesmo com o botão médio, deixando cinza
        objeto = GameObject.Find("Médio");
        imagem = objeto.GetComponent<Image>();
        imagem.color = Color.gray;

        //Fazemos o mesmo com o botão difícil, deixando cinza
        objeto = GameObject.Find("Difícil");
        imagem = objeto.GetComponent<Image>();
        imagem.color = Color.gray;

        dificuldade = 0.2f;
        difi = "facil";
    }

    //Análogo para o botão de dificuldade média
    public void botao_medio()
    {
        GameObject objeto = GameObject.Find("Fácil");
        Image imagem = objeto.GetComponent<Image>();
        imagem.color = Color.gray;


        objeto = GameObject.Find("Médio");
        imagem = objeto.GetComponent<Image>();
        imagem.color = Color.white;

        objeto = GameObject.Find("Difícil");
        imagem = objeto.GetComponent<Image>();
        imagem.color = Color.gray;

        dificuldade = 0.3f;
        difi = "medio";
    }

    //Análogo para o botão de dificuldade difícil
    public void botao_dificil()
    {
        GameObject objeto = GameObject.Find("Fácil");
        Image imagem = objeto.GetComponent<Image>();
        imagem.color = Color.gray;

        objeto = GameObject.Find("Médio");
        imagem = objeto.GetComponent<Image>();
        imagem.color = Color.gray;

        objeto = GameObject.Find("Difícil");
        imagem = objeto.GetComponent<Image>();
        imagem.color = Color.white;

        dificuldade = 0.35f;
        difi = "dificil";
    }

    //E para o botão de skin fazemos a mesma coisa
    public void skin_alternativa()
    {
        GameObject objeto = GameObject.Find("Principal");
        Image imagem = objeto.GetComponent<Image>();
        imagem.color = Color.gray;

        objeto = GameObject.Find("Alternativo");
        imagem = objeto.GetComponent<Image>();
        imagem.color = Color.white;

        alternativo = true;
    }

    //Repetimos o processo pra skin principal
    public void skin_principal()
    {
        GameObject objeto = GameObject.Find("Principal");
        Image imagem = objeto.GetComponent<Image>();
        imagem.color = Color.white;

        objeto = GameObject.Find("Alternativo");
        imagem = objeto.GetComponent<Image>();
        imagem.color = Color.gray;

        alternativo = false;
    }

    //E o botão para começar
    public void comecar()
    {//////////////// request do banco para determinar o id do usuario
        criada = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        int id_do_usuario = 0;
        if (alternativo == true)
        {   
            mascote = "humanoide";
        }
        else 
        {  
            mascote = "gotinha"; 
        }
        if (jogo == 0)
        {
            //                      ( user_id  , dificuldade, finalizado, pontos, problemas, abertos, mascote, created, modified )

            script_bd.Insert_in_jogo(0,id_do_usuario, difi,       0,          0,        22,      18,     mascote, criada, criada);
        }
        else
        {
            
            script_bd.Insert_in_jogo(jogo,id_do_usuario, difi, 0, 0, 22, 18, mascote, criada, criada);
        }
        SceneManager.LoadScene(2); //Carregamos a próxima cena
        Time.timeScale = 0f;
    }
}
