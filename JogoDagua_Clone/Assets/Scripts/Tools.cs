using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tools : MonoBehaviour{

    private SpriteRenderer sr;
    private BoxCollider2D box;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Verificamos a colisão com o objeto e logo o destruímos
    void OnCollisionEnter2D(Collision2D collision)
{
    int playerLayer = LayerMask.NameToLayer("Player");
    if (collision.gameObject.layer == playerLayer)
    {
        // O objeto colidiu com o jogador
        Debug.Log("Item colidiu com o jogador!");
        // Adicione aqui a lógica para o item quando colide com o jogador
    }
}
}
