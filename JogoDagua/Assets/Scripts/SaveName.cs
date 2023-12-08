/*
 * SCRIPT PARA SALVAR O NOME DO JOGADOR
 * Atualizado por:     Thayllor Peres Devos dos Santos
 * E-mail:               thayllordossantos @gmail.com
*/

using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;


public class SaveName : MonoBehaviour{

    public GameObject tela;
    public GameObject confirmacao;
    [SerializeField]
    public Text nomedameninix;
    public Text aviso;
    

    public void Awake () 
    {
        
        if (File.Exists(Application.persistentDataPath + "/Nome.txt"))
        {
            SceneManager.LoadScene(1);
        }
        tela = GameObject.Find("Tela");
        confirmacao = GameObject.Find("Confirmacao");
    }
    void Start () {//se n existe
        

    }
   

    // Update is called once per frame
    public void PegaNome()
    {
        if (nomedameninix.text == "")
        {
            aviso.text = "Coloque um nome valido por favor :)";
        }
        else
        {
            confirmacao.SetActive(true);
            Confirmacao script_conf =confirmacao.GetComponent<Confirmacao>();
            script_conf.nome.text = nomedameninix.text;
            tela.SetActive(false);
            
        }
    }

}