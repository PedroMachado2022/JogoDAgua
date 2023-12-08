/*
JOGO DA ÁGUA: Controle do personagem
Desenvolvido por:     Jhordan Silveira de Borba
E-mail:               jhordandecacapava@gmail.com
Website:              https://sapogithub.github.io
Mais informações:     https://github.com/SapoGitHub/Repositorio-Geral/wiki/Jogo-da-%C3%A1gua
2018
 Alterado por Thayllor P D dos Santos
*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Classe principal
public class jogador : MonoBehaviour
{
    public Rigidbody2D myrigidbody;    //Acessamos o elemento RigidBody2D do objeto
    private Animator minhanimacao;      //Acessamos o elemento Animator do objeto
    private bool estanochao;            //Indica se estamos no chão
    private bool pulo;                  //Indica se deve pular
    private bool setanaparede;          //Indica se está colidindo com a parede
    private bool olhandodireita;        //Se estamos indo para a direita
    float horizontal;                   //Valor de movimento na horizontal
    private GameObject estats;          //Gameobject das estatísticas
    status script;
//Script com os valores das estatísticas
    [SerializeField]
    private LayerMask chao = 8;

    [SerializeField]                    //Permitir o controle pelo Unity
    private float forcapulo;            //Definimos a força do pulo

    [SerializeField]
    private float velocidade;           //Velocidade do personagem
    [SerializeField]
    private float difi;
    private int fase;


   
            //A camada do chão que vamos detectar colisão

     //Use this for initialization
    void Start()
    {
        olhandodireita = true;                          //Começamos olhando para a direita

        myrigidbody = GetComponent<Rigidbody2D>();      //Pegamos o componente do objeto

        minhanimacao = GetComponent<Animator>();        //Pegamos o componente do animator

        estats = GameObject.Find("Status");
        
       script = estats.GetComponent<status>();
        if (script.alternativo == true)                  //Se vamos usar a skin alternativa
        {
            minhanimacao.SetLayerWeight(1, 1);
        }
        difi = script.dificuldade;
        fase = script.fase;
    }

    // Update is called once per frame com uma taxa fixa
    void FixedUpdate()
    {
        /*if (fase == 1)
        {
            forcapulo = 3;
            velocidade = 50;
        }
        if (fase == 2)
        {
            forcapulo = 3;
            velocidade = 60;
        */
        horizontal = Input.GetAxis("Horizontal"); //Recebemos os valores de entrada no eixo horizontal
        entrada();                                      //Checamos entradas pelo teclado
        checa_botao();                                  //Checamos as entradas pelos botões
        flip(horizontal);                               //Checamos se precisamos inverter o sprite
        estanochao = tanochao();                        //Vamos checar se o personagem está no chão
        movimento(horizontal);                          //Vamos aplicar o movimento
       reset();                                        //Resetamos os valores
    }

    //Função para fazer o controle do movimento do personagem
    private void movimento(float horizontal)
    {
        if ((pulo == true)&&(estanochao== true))
        {
            myrigidbody.velocity = new Vector2(myrigidbody.velocity.x, 0);
            myrigidbody.AddForce(new Vector2(0, 100)*forcapulo);//E aplicamos uma força na vertical
        }

        myrigidbody.velocity = new Vector2(horizontal * velocidade * difi, myrigidbody.velocity.y); //Aplicamos uma velocidade na horizontal que depende da velocidade
        minhanimacao.SetFloat("velocidade", Mathf.Abs(horizontal));                          //Passamos o valor absoluto da horizontal pro parâmetro da animação
    }

    //Função para checar as entradas pelo teclado
    private void entrada()
    {
        if (Input.GetKeyDown(KeyCode.Space))        //Se teclou enter
        { pulo = true; }                            //Pulamos
    }
    
    //Função para inverer o sprite
    private void flip(float horizontal)
    {
        if (horizontal > 0 && !olhandodireita || horizontal < 0 && olhandodireita) //Se estamos nos movendo para um lado e olhando para o outro
        {
            olhandodireita = !olhandodireita;       //Salvamos para onde estamos olhando agora
            Vector3 escala = transform.localScale;  //Pegamos a escala do elemento Transform do nosso objeto
            escala.x *= -1;                         //Multiplicamos por -1
            transform.localScale = escala;          //E registramos
        }
    }
    
    //Função para checar se está no chão=[

    private bool tanochao()
    {
        Vector2 posisao = transform.position;
        Vector2 fim = posisao;
        
        if (fase == 1)
        {
            fim.y -= 0.35f;
        }
        else if (fase==2)
        {
            fim.y -= 0.9f;
        }
        bool hit = Physics2D.Linecast(posisao, fim, chao);
        return hit;
    }
    
    //Função para resetar os valores
    private void reset()
    {
        pulo = false;           //Resetamos o pulo
    }

    private void checa_botao()
    {
        //Vamos checar o botão do pulo
        GameObject botao = GameObject.Find("Pulo");
        botao script = botao.GetComponent<botao>();
        if (script.pressionado)
        {
            pulo = true;
        }

        //Vamos checar o botão da esquerda
        botao = GameObject.Find("Esquerda");
        script = botao.GetComponent<botao>();
        if (script.pressionado == true)
        {
            horizontal = -1;
        }

        //Vamos checar o botão da direita
        botao = GameObject.Find("Direita");
        script = botao.GetComponent<botao>();
        if (script.pressionado == true)
        {
            horizontal = 1;
            
        }
    }
}