/*
 * SCRIPT PARA PARA FAZER TODOS OS OUTROS SAVES E ENVIAR PARA O BANCO
 * Atualizado por:     Thayllor Peres Devos dos Santos
 * E-mail:               thayllordossantos @gmail.com
*/
using System.Collections;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.Networking;


public class Mybdscript : MonoBehaviour
{
    public int idjogo;
    public void Start()
    {
        DontDestroyOnLoad(this);
    }
    public void Insert_in_jogo(int id,int user_id, string dificuldade, int finalizado, int pontos, int problemas, int abertos, string mascote, string created, string modified)
    {
        string path = Application.persistentDataPath + "/Jogos.txt";
        string texto;
        if (!File.Exists(Application.persistentDataPath + "/Jogos.txt"))
        {
            texto = id.ToString() + "," + user_id.ToString() + "," + dificuldade + "," + finalizado.ToString() + "," + pontos.ToString() + "," + problemas.ToString() + "," + abertos.ToString() + "," + mascote + "," + created + "," + modified ;
            File.WriteAllText(path, texto);
        }
        else
        {
            texto = File.ReadAllText(path);
            texto += ","+ id.ToString() + "," + user_id.ToString() + "," + dificuldade + "," + finalizado.ToString() + "," + pontos.ToString() + "," + problemas.ToString() + "," + abertos.ToString() + "," + mascote + "," + created + "," + modified ;
            File.WriteAllText(path, texto);
        }
    }
   
    public void Insert_in_jogadas(int jogo_id, int fase, int pontos, int vida, int objeto_id, string objeto, string acao, string intencao, string created, string modified)
    {
        string path = Application.persistentDataPath + "/Jogadas.txt";
        string texto="";

        if (!File.Exists(Application.persistentDataPath + "/Jogadas.txt"))
        {
            texto += "," + jogo_id.ToString() + "," + fase.ToString() + "," + pontos.ToString() + "," + vida.ToString() + "," + objeto_id.ToString() + "," + objeto + "," + acao + "," + intencao + "," + created + "," + modified;
            File.WriteAllText(path, texto);
        }
        else
        {
            texto = File.ReadAllText(path);
            texto += "," + jogo_id.ToString() + "," + fase.ToString() + "," + pontos.ToString() + "," + vida.ToString() + "," + objeto_id.ToString() + "," + objeto + "," + acao + "," + intencao + "," + created + "," + modified;
            File.WriteAllText(path, texto);
        }
    }
    public int qual_jogo()
    {
        int jogo;
        Numero numerinho = new Numero();
        if (File.Exists(Application.persistentDataPath + "/Numero_Game"))//verificar se o nome existe
        {

            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream(Application.persistentDataPath + "/Numero_Game.sav", FileMode.Open);
            numerinho = bf.Deserialize(fs) as Numero;
            jogo = numerinho.numero;
            idjogo = jogo;
            numerinho.numero += 1;
            fs.Close();
        }
        else
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream(Application.persistentDataPath + "/Numero_Game.sav", FileMode.Create);
            numerinho.numero = 0;
            bf.Serialize(fs, numerinho);
            jogo = 0;
            idjogo = jogo;
            fs.Close();
        }

        return jogo;
    }
    public void EnviarProBanco()// preparanmdo o json pra enviar
    {
        string save = File.ReadAllText(Application.persistentDataPath + "/arquivo.txt");
        string url ="200.132.77.55/salvadados.php";
        StartCoroutine(Enviar(save, url));

    }
    IEnumerator Enviar(string json, string url)
    {
        WWWForm form = new WWWForm();
        form.AddField("arquivo", json);

        using (UnityWebRequest www = UnityWebRequest.Post(url, form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Form upload complete!");
                File.Delete(Application.persistentDataPath + "/Jogos.txt");
                File.Delete(Application.persistentDataPath + "/Jogadas.txt");

            }
        }
    }
    public void Salvar()
    {
        string path = Application.persistentDataPath+ "/arquivo.txt";
        string nome = File.ReadAllText(Application.persistentDataPath + "/Nome.txt");
        string jogos = File.ReadAllText(Application.persistentDataPath + "/Jogos.txt");
        string jogadas = File.ReadAllText(Application.persistentDataPath + "/Jogadas.txt");
        
        //jogos = jogos.Remove(0, 1);
        jogadas = jogadas.Remove(0, 1);
        string banco = nome + "," + jogos + ";" + jogadas + ";";
        File.WriteAllText(path, banco);

    }

}
[Serializable]
public class Numero
{
    public int numero;
}
