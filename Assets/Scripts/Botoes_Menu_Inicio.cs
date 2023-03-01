using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Botoes_Menu_Inicio : MonoBehaviour
{

    public Button Start;
    public Button Config;
    public Button Quit;
    public Button Beck;
    public Toggle Res1;
    public Toggle Res2;
    public VisualElement MenuIni;
    public VisualElement MenuCon;


    private void Awake() 
    {
        var root = GetComponent<UIDocument>();

        Start = root.rootVisualElement.Q<Button>("Start");
        Config = root.rootVisualElement.Q<Button>("Config");
        Quit = root.rootVisualElement.Q<Button>("Sair");
        Beck = root.rootVisualElement.Q<Button>("Voltar");

        Res1 = root.rootVisualElement.Q<Toggle>("19x10");
        Res2 = root.rootVisualElement.Q<Toggle>("12x78");

        MenuIni = root.rootVisualElement.Q<VisualElement>("Menu");
        MenuCon = root.rootVisualElement.Q<VisualElement>("Configu");

        Start.clicked += StartPress;
        Config.clicked += ConfigPress;
        Quit.clicked += QuitPress;
        Beck.clicked += BeckPress;
        //Res1.focusable = Res1Focus;
        //Res2.focusable = Res2Focus;
    }
    void StartPress()
    {
        Debug.Log("Começou o Jogo");
    }

    void ConfigPress()
    {
        MenuIni.style.display = DisplayStyle.None;
        MenuCon.style.display = DisplayStyle.Flex;
        Debug.Log("Abriu as Configs");
    }

    void QuitPress()
    {
        Debug.Log("Saiu do Jogo");
    }

    void BeckPress()
    {  
        MenuIni.style.display = DisplayStyle.Flex;
        MenuCon.style.display = DisplayStyle.None;
    }

    /*void Res1Focus() 
    {   
        Screen.SetResolution(1920,1080, true);
        
        if(Res1.focusable == true )
        {
            Res1.focusable = true;
        }
    }

    void Res2Focus()
    {
        Screen.SetResolution(1280,720, true);
        if(Res2.focusable == false)
        {
            Res2.focusable = true;
        }
    }*/
}
