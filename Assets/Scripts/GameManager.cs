using TMPro;
using Image =  UnityEngine.UI.Image;
using Button = UnityEngine.UI.Button;
using UnityEngine;

public class GameManager: MonoBehaviour
{
    [Header("Perguntas")]
    [SerializeField] private PerguntasSO perguntaAtual;
    [SerializeField] private PerguntasSO[] questions;

    [SerializeField] private TextMeshProUGUI textoEnunciado;
    [SerializeField] private GameObject[] alternativaTMP;

    [Header("Sprite")] 
    [SerializeField] private Sprite spriteRespostaCorreta;
    [SerializeField] private Sprite spriteRespostaIncorreta;
    [SerializeField] private Sprite spriteDefault;

    private Timer _timer;
    private int currentQuestionIndex;
    public void Start()
    {
        //
        currentQuestionIndex = 0;
        
        //
        perguntaAtual = questions[currentQuestionIndex];
        
        //
        DisplayQuestion();
        
        _timer = GetComponent<Timer>();
        _timer.RegisMaxTime(OnMaxTimeAchiv);
        textoEnunciado.SetText(perguntaAtual.GetEnunciado());

        string[] alternativas = perguntaAtual.GetAlternativa();
        
        for (int i = 0; i < alternativaTMP.Length; i++)
        {
            TextMeshProUGUI textAlter = alternativaTMP[i].GetComponentInChildren<TextMeshProUGUI>();
            textAlter.SetText(alternativas[i]);
        }
    }

    private void ResetQuest()
    {
        for (int i = 0; i < alternativaTMP.Length; i++)
        {
            Button btn = alternativaTMP[i].GetComponent<Button>();
            btn.enabled = true;

            Image img = alternativaTMP[i].GetComponent<Image>();
            ChangeButtonSprite(img, spriteDefault);
        }
    }

    private void DisplayQuestion()
    {
        textoEnunciado.SetText(perguntaAtual.GetEnunciado());

        string[] alternativas = perguntaAtual.GetAlternativa();

        for (int i = 0; i < alternativaTMP.Length; i++)
        {
            TextMeshProUGUI textAlter = alternativaTMP[i].GetComponentInChildren<TextMeshProUGUI>();
            textAlter.SetText(alternativas[i]);
        }
    }

    
    public void TaCorreta(int alterSelec)
    {
        DisableOptionButton();
        TimeStop();
        Image imgButon;
        
        if (alterSelec == perguntaAtual.GetRespostaCorreta())
        {
            imgButon = alternativaTMP[alterSelec].GetComponent<Image>();
            ChangeButtonSprite(imgButon, spriteRespostaCorreta);
            Debug.Log("Boa");
        }
        else
        {
            imgButon = alternativaTMP[alterSelec].GetComponent<Image>();
            ChangeButtonSprite(imgButon, spriteRespostaIncorreta);

            Image imgbuttoncorreta = alternativaTMP[perguntaAtual.GetRespostaCorreta()].GetComponent<Image>();
            ChangeButtonSprite(imgbuttoncorreta, spriteRespostaCorreta);
            
            Debug.Log("Burro");
        }

        if (currentQuestionIndex < questions.Length - 1)
        {
            currentQuestionIndex++;

            perguntaAtual = questions[currentQuestionIndex];
            
            ResetQuest();
            
            TimeReset();
            
            DisplayQuestion();
        }
        else
            Debug.Log("Não tem mais questões");
       
    }
    
// ----------- Travar as opções e trocar o sprite ----------- //
    public void DisableOptionButton()
    {
        for (int i = 0; i < alternativaTMP.Length; i++)
        {
            Button btn = alternativaTMP[i].GetComponent<Button>();
            btn.enabled = false;
        }
    }

    public void ChangeButtonSprite(Image img, Sprite sprt)
    {
        img.sprite = sprt;
    }
    void TimeStop()
    {
        _timer.Stop();
    }

    void TimeReset()
    {
        _timer.Zerar();
    }
    
    void OnMaxTimeAchiv()
    {
        Debug.Log("Parada");
    }
}
