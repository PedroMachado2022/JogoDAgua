/*
JOGO DA ÁGUA: Estatus
Desenvolvido por:     Jhordan Silveira de Borba
E-mail:               jhordandecacapava@gmail.com
Website:              https://sapogithub.github.io
Mais informações:     https://github.com/SapoGitHub/Repositorio-Geral/wiki/Jogo-da-%C3%A1gua
2018
Atualizado por:     Thayllor Peres Devos dos Santos
E-mail:               thayllordossantos@gmail.com
2019

Atualizado por:     Pedro Machado Araújo
E-mail:             pedro.machado.rs@hotmail.com
2024

*/

using UnityEngine;
using UnityEngine.SceneManagement;

public class status : MonoBehaviour {

    public float Vida;          //Vida di personagem
    public int Pontos;        //Pontuação atual
    public bool Pregos;         //Se temos os pregos
    public bool Caixa;          //Se temos as caixas
    public bool Filtro;         //Se temos o filtro
    public bool Plataforma;     //Se temos a plataforma
    public bool Chave;          //Se temos a chave para trocar de fase
    public int Regador;         //Quantos regadores temos
    public int Ferramentas;     //Quantas ferramentas temos
    public bool alternativo;     //Se vamos usar a skin alternativa
    public int fase;
    [SerializeField]  
    public float dificuldade;     //Nível de dificuldade
    
    public int vazamento;       //Quantidade de itens vazando
    
    public bool perdeu;        //Variável indicando se já perdemos

    public int win_Condition;

    public int lose_Condition;


    public string difi;
    public int jogo;/// (request no banco local para saber em q jogo esta)
    public string criada;
    public string mascote;
    public int abertos;
    

    // Use this for initialization
    void Awake () {//Função chamada quando o objeto é inicializado, antes mesmo da Start

        GameObject destruir = GameObject.Find("Menu");  //Vamos pegar o objeto da cena anterior
       

        if (destruir != null){
                menu script = destruir.GetComponent<menu>();    //Seu scrpit
                Vida = 100;
                Pontos = 0;

                Pregos = false;
                Caixa = false;
                Filtro = false;
                Plataforma = false;
                Chave = false;

                win_Condition = 0;
                lose_Condition = 0;
                
                Regador = 0;
                Ferramentas=0;
                vazamento = 11;
                fase = 1;
                dificuldade=script.dificuldade;             //Carregamos a dificuldade selecionada
                alternativo = script.alternativo;            //A skin selecionada
                perdeu = false;
                difi = script.difi;
                criada = script.criada;
                mascote = script.mascote;
                abertos = 0;
                jogo = script.jogo;

                Object.Destroy(destruir);                   //Destruímos o objeto
                DontDestroyOnLoad(this);  


                
        }
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Vida <= 0 && perdeu == false)
        {

            perdeu = true;
            SceneManager.LoadScene(5);                  //Carregamos a próxima cena
            
        }
        else
        {

            Vida = Vida - 0.005F * dificuldade * vazamento;     //Atualizar a vida de acordo com a dificuldade e a quantidade de itens vazando
            //print("Vida: "+Vida);

        }

    }
}