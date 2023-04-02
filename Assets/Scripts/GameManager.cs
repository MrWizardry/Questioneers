using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class GameManager: MonoBehaviour
{
    [SerializeField] private PerguntasSO perguntaAtual;
    
    [SerializeField] private TextMeshProUGUI textoEnunciado;
    [SerializeField] private GameObject[] alternativaTMP;

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
        if (alterSelec == perguntaAtual.GetRespostaCorreta())
        {
            Debug.Log("parabens");
        }
        else
            Debug.Log("seu merda, lixo, burro");
        
        Debug.Log("Corno FDP" + alterSelec);
    }
}
