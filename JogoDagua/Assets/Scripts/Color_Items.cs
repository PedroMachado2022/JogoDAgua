using UnityEngine;
using UnityEngine.UI;

public class Color_Items : MonoBehaviour
{
    public float novoAlpha = 0.5f; // Defina o valor desejado para o canal alpha

    void Start()
    {
        // Encontrar o Canvas chamado "Reservatório"
        Canvas reservatorioCanvas = GameObject.Find("Reservatório").GetComponent<Canvas>();

        // Verificar se o Canvas foi encontrado
        if (reservatorioCanvas != null)
        {
            // Encontrar a imagem chamada "Suporte" dentro do Canvas
            Image suporteImage = reservatorioCanvas.transform.Find("Suporte").GetComponent<Image>();

            // Verificar se a imagem foi encontrada
            if (suporteImage != null)
            {
                // Modificar o canal alpha da cor da imagem
                Color corAtual = suporteImage.color;
                corAtual.a = novoAlpha;
                suporteImage.color = corAtual;
            }
            else
            {
                Debug.LogError("Imagem chamada 'Suporte' não encontrada dentro do Canvas.");
            }
        }
        else
        {
            Debug.LogError("Canvas chamado 'Reservatório' não encontrado.");
        }
    }
}
