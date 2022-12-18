using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Botoes_Menu_Inicio : MonoBehaviour
{
    public Button Start;
    public Button Config;
    public Button Quit;
    public VisualElement MenuIni;
    public VisualElement MenuCon;

    private void Awake() {
        var root = GetComponent<UIDocument>();

        Start = root.rootVisualElement.Q<Button>("Start");
        Config = root.rootVisualElement.Q<Button>("Config");
        Quit = root.rootVisualElement.Q<Button>("Sair");

        MenuIni = root.rootVisualElement.Q<VisualElement>("Menu");
        MenuCon = root.rootVisualElement.Q<VisualElement>("Configu");

        Start.clicked += StartPress;
        Config.clicked += ConfigPress;
        Quit.clicked += QuitPress;
    }

    void StartPress()
    {
        Debug.Log("Começou o Jogo");
    }

    void ConfigPress()
    {
        Debug.Log("Abriu as Configs");
    }

    void QuitPress()
    {
        Debug.Log("Saiu do Jogo");
    }
}
