/*
JOGO DA ÁGUA: Controle da câmera
Desenvolvido por:     Jhordan Silveira de Borba
E-mail:               jhordandecacapava@gmail.com
Website:              https://sapogithub.github.io
Mais informações:     https://github.com/SapoGitHub/Repositorio-Geral/wiki/Jogo-da-%C3%A1gua
2018
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour {

    [SerializeField]
    private float xMax;         //Posição máxima da câmera no eixo X

    [SerializeField]
    private float yMax;         //Posição máxima da câmera no eixo Y

    [SerializeField]
    private float yMin;         //Posição mínima da câmera no eixo Y

    [SerializeField]
    private float xMin;         //Posição mínima da câmera no eixo X

    private Transform alvo;     //Quem a câmera vai seguir

	// Use this for initialization
	void Start () {
        alvo = GameObject.Find("Jogador").transform;    //Pegamos o elemento Transform do GameObject chamado "Jogador"
	}
	
	// Update is called once per frame depois dos outros updates
	void LateUpdate () {
        //Alteramos a própria posição de acordo com a posição do alvo, dentro dos limites definidos
        transform.position = new Vector3(Mathf.Clamp(alvo.position.x, xMin, xMax), Mathf.Clamp(alvo.position.y, yMin, yMax),transform.position.z);
 	}
}
