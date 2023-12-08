using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pensamento : MonoBehaviour
{

    // Use this for initialization
   // [SerializeField]
    //private Text texto;
    public int side;
    void Start()
    {
        transform.SetParent(transform, true);
        


    }
    void Update()
    {
        RectTransform myrect = GetComponent<RectTransform>();
        
        GameObject cima = GameObject.Find("PensamentoC");
        GameObject baixo = GameObject.Find("PensamentoB");
        GameObject player = GameObject.Find("Jogador");
        RectTransform cimaR = cima.GetComponent<RectTransform>();
        RectTransform baixoR = baixo.GetComponent<RectTransform>();
        
        if (player.transform.position.y<= 0.825)// ta na parte de baixo
        {
            myrect.anchorMin = baixoR.anchorMin;
            myrect.anchorMax = baixoR.anchorMax;
            myrect.anchoredPosition = baixoR.anchoredPosition;
            myrect.sizeDelta = baixoR.sizeDelta;

        }
        else
        {
            myrect.anchorMin = cimaR.anchorMin;
            myrect.anchorMax = cimaR.anchorMax;
            myrect.anchoredPosition = cimaR.anchoredPosition;
            myrect.sizeDelta = cimaR.sizeDelta;
        }

    }
}
// Update is called once per frame

	
	
