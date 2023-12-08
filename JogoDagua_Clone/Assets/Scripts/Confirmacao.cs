using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
public class Confirmacao : MonoBehaviour {
    public GameObject tela;
    public GameObject confirmacao;
    public Text nome;
   
    public void Start() {
        tela = GameObject.Find("Tela");
        confirmacao = GameObject.Find("Confirmacao");
        confirmacao.SetActive(false);

    }
    public void Sim()
    {
        string path = (Application.persistentDataPath + "/Nome.txt");
        File.WriteAllText(path, nome.text);
        File.WriteAllText(Application.persistentDataPath + "/Jogos.txt", "");
        File.WriteAllText(Application.persistentDataPath + "/Jogadas.txt", "");
        File.WriteAllText(Application.persistentDataPath + "/arquivo.txt", "");
        SceneManager.LoadScene(1);
    }
    public void Nao()
    {
        File.Delete(Application.persistentDataPath + "/Nome.txt");
        tela.SetActive(true);
        confirmacao.SetActive(false);
    }
}

