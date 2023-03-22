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
    [SerializeField] private TextMeshProUGUI[] textoAlterna;

    public void Start()
    {
        textoEnunciado.SetText(perguntaAtual.GetEnunciado());
        for (int i = 0; i < textoAlterna.Length; i++)
        {
            textoAlterna[i].SetText(perguntaAtual.getAlternativa[i]);
        }
    }
    

}
