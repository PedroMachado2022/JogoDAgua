using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fundinho : MonoBehaviour {
    private Rigidbody2D rigid_player;
    private Rigidbody2D myRB;
    private GameObject alvo;

    // Use this for initialization
    void Start()
    {
        alvo = GameObject.Find("Jogador");
        rigid_player = alvo.GetComponent<Rigidbody2D>();
        myRB = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    { 
        if((alvo.transform.position.x >= -5.8)  && (alvo.transform.position.x <= 85.2))
        {
            myRB.velocity = (rigid_player.velocity / 4) * (new Vector2(1, 0));
        }
        else
        {
            myRB.velocity = new Vector2(0, 0);
        }
    }
}
