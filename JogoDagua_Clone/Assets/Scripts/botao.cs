/*
JOGO DA ÁGUA: Controle dos botões
Desenvolvido por:     Jhordan Silveira de Borba
E-mail:               jhordandecacapava@gmail.com
Website:              https://sapogithub.github.io
Mais informações:     https://github.com/SapoGitHub/Repositorio-Geral/wiki/Jogo-da-%C3%A1gua
2018
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;// Required when using Event data.


public class botao : MonoBehaviour, IPointerDownHandler// required interface when using the OnPointerDown method.
{
    public bool acao;           //Variavel que indica se devemos fazer a ação
    public bool pressionado;    //Variável que informa se o botão está sendo pressionado
    public bool dentro;         //Variável pra saber se estamos dentro dos objetos que queremos executar as ações

    private void Start()
    {
        //Vamos configurar todos valores iniciais como falsos
        acao = false;
        pressionado = false;
        dentro = false;
    }

    //Do this when the mouse is clicked over the selectable object this script is attached to.
    public void OnPointerDown(PointerEventData eventData)
    { pressionado = true;   }                       //Registramos
  
    //Função que vamos chamar quando soltar o botão
    public void solta()
    { pressionado = false;  }                       //Registramos também

    //Função que vamos chamar para o botão de ação especificamente
    public void interage()
    {
        if (dentro == true) //Se estamos dentro de um objeto válido
        { acao = true; }    //Então executamos a ação
    }                                
}