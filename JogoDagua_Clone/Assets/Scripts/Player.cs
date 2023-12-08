using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Security.AccessControl;
using UnityEngine;

public class Player : MonoBehaviour{

    public float Speed;
    public float JumpForce;

    // Variáveis referentes ao pulo do personagem
    public bool isJumping;

    // Variável para controlar o corpo do jogador
    private Rigidbody2D body;

    // Variável para contrar a animação do player
    private Animator anim;

    private bool Jump_Button;

    private bool Jump_input;
    private bool Right;
    private bool Left;

    public float Horizontal_Input;

    // Start is called before the first frame update
    void Start(){

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
        // Input do teclado
        if (Input.GetButtonDown("Jump") && !isJumping){
            // Criamos um impulso no jogador no sentido do eixo Y.
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

            if(collsion.gameObject.layer == 13){
                //isJumping = true;
                GetComponent<Collider2D>().enabled = false;
                //body.constraints = RigidbodyConstraints2D.;
                print("To na parade");
            }
        }

        // Método padrão da Unity para verificar Colisões
        void OnCollisionExit2D(Collision2D collsion){
            if(collsion.gameObject.layer == 8 || collsion.gameObject.layer == 11){
                isJumping = true;
                print("Não posso pular");
            }

            if(collsion.gameObject.layer == 13){
                //isJumping = true;
                GetComponent<Collider2D>().enabled = true;
                //body.constraints = RigidbodyConstraints2D.None;
                print("Saí da parade");
            }
            
        }
}
