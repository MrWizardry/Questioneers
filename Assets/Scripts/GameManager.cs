using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Image =  UnityEngine.UI.Image;
using Button = UnityEngine.UI.Button;
using UnityEngine;
using UnityEngine.UI;

public class GameManager: MonoBehaviour
{
    [Header("Perguntas")]
    [SerializeField] private PerguntasSO perguntaAtual;
    [SerializeField] private TextMeshProUGUI textoEnunciado;
    [SerializeField] private GameObject[] alternativaTMP;

    [Header("Sprite")] 
    [SerializeField] private Sprite spriteRespostaCorreta;
    [SerializeField] private Sprite spriteRespostaIncorreta;
    
    public void Start()
    {
        textoEnunciado.SetText(perguntaAtual.GetEnunciado());

        string[] alternativas = perguntaAtual.GetAlternativa;
        
        for (int i = 0; i < alternativaTMP.Length; i++)
        {
            TextMeshProUGUI textAlter = alternativaTMP[i].GetComponentInChildren<TextMeshProUGUI>();
            textAlter.SetText(alternativas[i]);
        }
    }

    public void TaCorreta(int alterSelec)
    {
        DisableOptionButton();
        Image imgButon;
        if (alterSelec == perguntaAtual.GetRespostaCorreta())
        {
            imgButon = alternativaTMP[alterSelec].GetComponent<Image>();
            changeButtonSprite(imgButon, spriteRespostaCorreta);
            
        }
        else
        {
            imgButon = alternativaTMP[alterSelec].GetComponent<Image>();
            changeButtonSprite(imgButon, spriteRespostaIncorreta);

            Image imgbuttoncorreta = alternativaTMP[perguntaAtual.GetRespostaCorreta()].GetComponent<Image>();
            changeButtonSprite(imgbuttoncorreta, spriteRespostaCorreta);
            

        }

        Debug.Log("Correto" + alterSelec);
    }

    public void DisableOptionButton()
    {
        for (int i = 0; i < alternativaTMP.Length; i++)
        {
            Button btn = alternativaTMP[i].GetComponent<Button>();
            btn.enabled = false;
        }
    }

    public void changeButtonSprite(Image img, Sprite sprt)
    {
        img.sprite = sprt;
    }
}
