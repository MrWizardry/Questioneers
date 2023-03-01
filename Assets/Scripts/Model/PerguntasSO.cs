using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(
    menuName = "NewQuest",
    fileName = "Pergunta-"

)]

public class PerguntasSO : ScriptableObject
{
    [TextArea(2,6)]
    [SerializeField] private string enunciado;
    [SerializeField] private string[] alternativas;
    [SerializeField] private int respostaCorreta;
    [SerializeField] private string id;
}
