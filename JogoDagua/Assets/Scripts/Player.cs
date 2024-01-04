using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Security.AccessControl;
using UnityEngine;

public class Player : MonoBehaviour{

    public float Speed;
    
    // Variável para controlar o corpo do jogador
    private Rigidbody2D body;

    // Variável para contrar a animação do player
    private Animator anim;
   
    private bool Right;
    private bool Left;

    public float Horizontal_Input;


    private status statusScript;

    public string mascoteValue;

    // ------------------ VARIÁVEIS PARA CONTROLAR O PULO DO PERSONAGEM ------------------ \\
    // Força do pulo
    public float JumpForce;

    // Se está pulando
    public bool isJumping;
    // Se pode pular

    // Entrada do pulo pelo botão "pular" da tela (mobile)
    private bool Jump_input;



    // Start is called before the first frame update
    void Start(){

        GameObject statusObject = GameObject.Find("Status");
        anim = GetComponent<Animator>();

        if (statusObject != null) {
           
            statusScript = statusObject.GetComponent<status>();
            mascoteValue = statusScript.mascote;
            //print(mascoteValue);
            if (mascoteValue == "humanoide"){
                print(mascoteValue);
                anim.SetLayerWeight(1, 1f);
            }
             else {
                // Se não for "humanoide", pode ajustar o peso da camada para zero ou outro valor desejado
                anim.SetLayerWeight(1, 0f);
            }
            
        }
        // Iniciamos a variável recebendo os valores do corpo do player na Unity
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        
    }

    // Update is called once per frame
    void Update(){
        Move();
        Jump();
    }
 
    // Função que contra o movimento do jogador.
    void Move()
    {   

        Vector3 movement = new Vector2(Horizontal_Input, 0f);
        
        body.velocity = new Vector2(movement.x * Speed, body.velocity.y);


        // Direita
        if (Right){
            // Animação e direção da imagem do jogador
            anim.SetBool("running", true);
            transform.eulerAngles = new Vector2(0f, 0f);     
        }

        // Esquerda
        else if (Left){
            // Animação e direção da imagem do jogador
            anim.SetBool("running", true);
            transform.eulerAngles = new Vector2(0f, 180f);
        }
        else{
            anim.SetBool("running", false);
        }

    }   

    public void MoveRightTrue(){
        Right = true;
        Horizontal_Input = 1;
    }

    public void MoveRightFalse(){
        Right = false;
        Horizontal_Input = 0;
    }


    public void MoveLeftTrue(){
        Left = true;
        Horizontal_Input = -1;
    }

    public void MoveLeftFalse(){
        Left = false;
        Horizontal_Input = 0;
    }

    // Função que verifica quando o jogador clica no botão de pular
    public void Veri_Jump(){
        // Tratamento para o pulo acontecer apenas uma vez (Evitar pulo duplo e pulo infinito)
        if (!isJumping){
            Jump_input = true;
        }
    }

    // Verificamos se a função Jump foi ativada
    public void Jump()
    {
        if (Input.GetButtonDown("Jump") && !isJumping){
    
            body.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);

        }
        
        // Input da tela
        if (Jump_input && !isJumping){
            // Criamos um impulso no jogador no sentido do eixo Y.
            body.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
            // Retiramos a condição de pulo do player para o pulo acontecer apenas uma vez (Evitar pulo duplo e pulo infinito)
            Jump_input = false;
        
        }
    }

    // Método padrão da Unity para verificar Colisões
    void OnCollisionEnter2D(Collision2D collsion){
            if(collsion.gameObject.layer == 8 || collsion.gameObject.layer == 11){
                isJumping = false;   
            }
        }

    // Método padrão da Unity para verificar Colisões
    void OnCollisionExit2D(Collision2D collsion){
            if(collsion.gameObject.layer == 8 || collsion.gameObject.layer == 11){
                isJumping = true;
            }
        }
}
