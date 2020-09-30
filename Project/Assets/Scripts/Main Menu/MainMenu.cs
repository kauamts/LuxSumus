using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour
{
    #region GameManager variables
    public GameManager manager;
    #endregion
    #region Texto variables
    public Texto texto;
    #endregion
    #region bool variables
    public bool languageSelected;
    public bool started;
    public bool optionWindow;
    public bool fullScreen;
    public bool selecaoDificuldade;
    #endregion
    #region Rect variables
    public Rect languageChoice;
    public Rect botaoPort;
    public Rect botaoIng;
    public Rect readyCheck;
    public Rect start;
    public Rect newGame;
    public Rect carregarJogo;
    public Rect opcoes;
    public Rect sair;
    public Rect titulo;
    public Rect dificuldade;
    #endregion
    #region Texture variables
    public Texture imagemTitulo;
    public Texture imagemIngles;
    public Texture imagemPortugues;
    #endregion
    #region GUISkin variables
    public GUISkin mainMenuSkin;
    //public GUISkin boxSkin;
    #endregion
    #region GameObject variables
    public GameObject menuBackground;
    #endregion
    // Use this for initialization
	void Start () {
        manager = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<GameManager>();
        texto = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<Texto>();
        menuBackground.SetActive(false);
	
	}
	
	// Update is called once per frame
	void Update () {
        RectPosition();
        languageSelected = manager.languageSelected;
        started = manager.started;

        if (languageSelected && !started)
        {
            if (Input.anyKeyDown)
            {
                manager.started = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }	
	}

    void RectPosition()
    {
        languageChoice = new Rect((Screen.width / 2 - Screen.width / 4), (Screen.height / 8 - Screen.height / 16 + Screen.height / 8), Screen.width / 2, Screen.height / 8);
        botaoIng = new Rect((Screen.width / 2 - Screen.width / 4 + Screen.width / 12), (Screen.height / 2 - Screen.height / 16), Screen.width / 8, Screen.height / 8);
        botaoPort = new Rect((Screen.width / 2 + Screen.width / 8 - Screen.width / 12), (Screen.height / 2 - Screen.height / 16), Screen.width / 8, Screen.height / 8);
        readyCheck = new Rect((Screen.width / 2 - Screen.width / 8), (Screen.height / 2 + Screen.height / 4), Screen.width / 4, Screen.height / 8);
        start = new Rect((Screen.width / 2 - Screen.width / 8), (Screen.height / 2 - Screen.height / 16), Screen.width / 4, Screen.height / 8);
        newGame = new Rect((Screen.width / 2 + Screen.width / 8), (Screen.height / 2), Screen.width / 4, Screen.height / 16);
        carregarJogo = new Rect((Screen.width / 2 + Screen.width / 8), (Screen.height / 2 + Screen.height / 12), Screen.width / 4, Screen.height / 16);
        opcoes = new Rect((Screen.width / 2 + Screen.width / 8), (Screen.height / 2 + Screen.height / 6), Screen.width / 4, Screen.height / 16);
        sair = new Rect((Screen.width / 2 + Screen.width / 8), (Screen.height / 2 + Screen.height / 4), Screen.width / 4, Screen.height / 16);
        titulo = new Rect((Screen.width / 4), (-Screen.height / 5), Screen.width, Screen.height);
        dificuldade = new Rect(Screen.width / 2 - Screen.width / 4, Screen.height / 2 - Screen.height / 8, Screen.width / 2, Screen.height / 4);
    }

    void SelecaoDificuldade(int id)
    {
        //GUI.skin = boxSkin;
        GUILayout.Space(Screen.height / 16);
        GUILayout.BeginHorizontal();
        if (GUILayout.Button(texto.dificuldadeFacil))
        {
            manager.dificuldade = 0;
        }
        GUILayout.Space(Screen.width / 32);
        if (GUILayout.Button(texto.dificuldadeNormal))
        {
            manager.dificuldade = 1;
        }
        GUILayout.Space(Screen.width / 32);
        if (GUILayout.Button(texto.dificuldadeDificil))
        {
            manager.dificuldade = 2;
        }
        GUILayout.EndHorizontal();
        GUILayout.Space(Screen.height / 32);
        GUILayout.BeginHorizontal();
        GUILayout.Space(Screen.width / 8);
        if (GUILayout.Button(texto.comecar))
        {
            PlayerPrefs.SetInt("NewGame", 0);
            PlayerPrefs.SetInt("Dificuldade", manager.dificuldade);
            Application.LoadLevel(2);
        }
        GUILayout.Space(Screen.width / 32);
        if (GUILayout.Button(texto.voltar))
        {
            selecaoDificuldade = false;
        }
        GUILayout.Space(Screen.width / 8);
        GUILayout.EndHorizontal();
        GUILayout.Space(Screen.height / 16);
    }

    void OnGUI()
    {
        GUI.skin = mainMenuSkin;
        GUI.skin.button.fontSize = 28;
        GUI.skin.label.fontSize = 48;
        if (!languageSelected)
        {
            GUI.Label(languageChoice, texto.choose);

            if (GUI.Button(botaoIng, imagemIngles))
            {
                manager.ingles = true;
                manager.portugues = false;
            }

            if (GUI.Button(botaoPort, imagemPortugues))
            {
                manager.portugues = true;
                manager.ingles = false;
            }

            if (GUI.Button(readyCheck, texto.ready) && (manager.portugues || manager.ingles))
            {
                manager.languageSelected = true;
                manager.started = true;
            }
        }

        if (languageSelected && !started)
        {
            //GUI.Label(start, texto.start);
            //menuBackground.SetActive(true);
        }

        if (languageSelected && started)
        {
            //GUI.Label(titulo, imagemTitulo);
            menuBackground.SetActive(true);
            GUI.skin.button.fontSize = 0;
        }

        if (languageSelected && started && !manager.optionWindow && !selecaoDificuldade && !manager.loadWindow)
        {
            //GUI.Label(titulo, imagemTitulo);

            if (GUI.Button(newGame, texto.novoJogo))
            {
                //Application.LoadLevel(1);
                selecaoDificuldade = true;
            }
            GUI.enabled = manager.hasSavedGame;
            if (GUI.Button(carregarJogo, texto.carregarJogo))
            {
                //SaveLoad.Load();
                //Application.LoadLevel(1);
                //PlayerPrefs.SetInt("NewGame", 1);
                manager.loadWindow = true;
                //if (PlayerPrefs.GetInt("NewGame") == 1)
                //{
                    //manager.loading = true;
                    //Application.LoadLevel(2);
                //}
            }
            GUI.enabled = true;
            if (GUI.Button(opcoes, texto.opcoes))
            {
                manager.optionWindow = true;
            }

            if (GUI.Button(sair, texto.sair))
            {
                Application.Quit();
            }
        }

        if (selecaoDificuldade)
        {
            GUI.Window(0, dificuldade, SelecaoDificuldade, texto.dificuldade);
        }
    }
}
