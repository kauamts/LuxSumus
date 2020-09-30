using UnityEngine;
using System.Collections;

[System.Serializable]
public class GameManager : MonoBehaviour
{
    #region bool variables
    public bool portugues;
    public bool ingles;
    public bool optionWindow;
    public bool fullScreen;
    public bool som;
    public bool languageSelected;
    public bool started;
    public bool loading;
    public bool hasSavedGame;
    public bool loadWindow;
    #endregion
    #region float variables
    public float volumeSlider;
    #endregion
    #region Rect variables
    public Rect janelaOpcoes;
    public Rect textoResolucao;
    public Rect botaoResolucao600;
    public Rect botaoResolucao768;
    public Rect botaoResolucao720;
    public Rect botaoResolucao1080;
    public Rect textoTelaCheia;
    public Rect botaoTelaCheia;
    public Rect textoVolume;
    public Rect sliderVolume;
    public Rect textoSom;
    public Rect botaoSom;
    public Rect textoQualidade;
    public Rect botaoQualidadeBaixa;
    public Rect botaoQualidadeMedia;
    public Rect botaoQualidadeAlta;
    public Rect botaoQualidadeMuitoAlta;
    public Rect textoLingua;
    public Rect botaoLinguaIngles;
    public Rect botaoLinguaPortugues;
    public Rect botaoVoltar;
    public Rect textoDificuldade;
    public Rect botaoDificuldadeFacil;
    public Rect botaoDificuldadeNormal;
    public Rect botaoDificuldadeDificil;
    public Rect janelaLoading;
    #endregion
    #region AudioListener variables
    public AudioListener listener;
    #endregion
    #region Texto variables
    public Texto texto;
    #endregion
    #region string variables
    public string fullScreenText;
    public string soundText;
    #endregion
    #region GUISkin variables
    public GUISkin optionsSkin;
    #endregion
    #region int variables
    public int dificuldade;
    public int currentScene;
    public int currentResolution;
    #endregion
    #region GameManager variables
    private static GameManager instance;
    public static GameManager Instance
    {
        get { return instance; }
    }
    #endregion
    #region Texture variables
    public Texture loadImage;
    #endregion
    // Use this for initialization
	void Start () {
        som = true;
        ingles = true;
        fullScreen = true;
        languageSelected = false;
        started = false;
        loading = false;
        Screen.SetResolution(1280, 720, fullScreen);
        currentResolution = 2;
        texto = gameObject.GetComponent<Texto>();
        volumeSlider = 1.0f;
        dificuldade = PlayerPrefs.GetInt("Dificuldade");
	}
	
	// Update is called once per frame
	void Update () {
        RectPosition();
        CurrentScene();
        janelaOpcoes = new Rect(0, 0, Screen.width, Screen.height);
        listener = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioListener>();
        AudioListener.volume = volumeSlider;

        if (PlayerPrefs.GetInt("NewGame") == 1)
        {
            hasSavedGame = true;
        }
        else
        {
            hasSavedGame = false;
        }

        if (fullScreen)
        {
            Screen.fullScreen = true;
            fullScreenText = texto.ligado;
        }
        else if (!fullScreen)
        {
            Screen.fullScreen = false;
            fullScreenText = texto.desligado;
        }

        if (!som)
        {
            AudioListener.volume = 0;
            soundText = texto.desligado;
        }
        else if (som)
        {
            AudioListener.volume = volumeSlider;
            soundText = texto.ligado;
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            Application.LoadLevel(4);
        }
	}

    void Awake()
    {
        Object.DontDestroyOnLoad(transform.gameObject);
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
            return;
        }
    }

    void CurrentScene()
    {
        if (Application.loadedLevel == 1)
        {
            currentScene = 1;
        }

        else if (Application.loadedLevel == 3)
        {
            currentScene = 3;
        }

        else if (Application.loadedLevel == 4)
        {
            currentScene = 4;
        }
    }

    void OnGUI()
    {
        GUI.skin = optionsSkin;
        if (currentResolution == 0)
        {
            if (optionWindow)
            {
                GUI.skin.window.fontSize = 48;
            }
            else if (loadWindow)
            {
                GUI.skin.window.fontSize = 24;
            }
        }
        else if (currentResolution == 1)
        {
            if (optionWindow)
            {
                GUI.skin.window.fontSize = 64;
            }
            else if (loadWindow)
            {
                GUI.skin.window.fontSize = 32;
            }
        }
        else if (currentResolution == 2)
        {
            if (optionWindow)
            {
                GUI.skin.window.fontSize = 64;
            }
            else if (loadWindow)
            {
                GUI.skin.window.fontSize = 32;
            }
        }
        else if (currentResolution == 3)
        {
            if (optionWindow)
            {
                GUI.skin.window.fontSize = 96;
            }
            else if (loadWindow)
            {
                GUI.skin.window.fontSize = 48;
            }
        }
        if (optionWindow)
        {
            janelaOpcoes = GUI.Window(0, janelaOpcoes, Options, texto.opcoes);
        }
        if (loadWindow)
        {
            janelaLoading = GUI.Window(0, janelaLoading, Loading, texto.carregarJogo);
        }
    }

    void RectPosition()
    {
        textoResolucao = new Rect(Screen.width / 24 + Screen.width / 28, Screen.height / 22 + Screen.height / 6, Screen.width / 8, Screen.height / 22);
        botaoResolucao600 = new Rect((Screen.width / 24 + Screen.width / 6), Screen.height / 22 + Screen.height / 6, Screen.width / 6, Screen.height / 22);
        botaoResolucao768 = new Rect((Screen.width / 20 + Screen.width / 3), Screen.height / 22 + Screen.height / 6, Screen.width / 6, Screen.height / 22);
        botaoResolucao720 = new Rect((Screen.width / 2 + Screen.width / 17), Screen.height / 22 + Screen.height / 6, Screen.width / 6, Screen.height / 22);
        botaoResolucao1080 = new Rect((Screen.width - Screen.width / 4 - Screen.width / 60), Screen.height / 22 + Screen.height / 6, Screen.width / 6, Screen.height / 22);
        textoTelaCheia = new Rect(Screen.width / 24 + Screen.width / 28, Screen.height / 8 + Screen.height / 8, Screen.width / 6, Screen.height / 22);
        botaoTelaCheia = new Rect(Screen.width / 24 + Screen.width / 6, Screen.height / 8 + Screen.height / 6, Screen.width / 6, Screen.height / 22);
        textoVolume = new Rect(Screen.width / 24 + Screen.width / 28, Screen.height / 6 + Screen.height / 24 + Screen.height / 6, Screen.width / 8, Screen.height / 22);
        sliderVolume = new Rect(Screen.width / 24 + Screen.width / 6, Screen.height / 6 + Screen.height / 24 + Screen.height / 6, Screen.width / 2 + Screen.width / 6, Screen.height / 22);
        textoSom = new Rect(Screen.width / 24 + Screen.width / 28, Screen.height / 6 + Screen.height / 8 + Screen.height / 6, Screen.width / 8, Screen.height / 22);
        botaoSom = new Rect(Screen.width / 24 + Screen.width / 6, Screen.height / 6 + Screen.height / 8 + Screen.height / 6, Screen.width / 6, Screen.height / 22);
        textoQualidade = new Rect(Screen.width / 24 + Screen.width / 28, Screen.height / 3 + Screen.height / 22 + Screen.height / 6, Screen.width / 8, Screen.height / 22);
        botaoQualidadeBaixa = new Rect(Screen.width / 24 + Screen.width / 6, Screen.height / 3 + Screen.height / 22 + Screen.height / 6, Screen.width / 6, Screen.height / 22);
        botaoQualidadeMedia = new Rect(Screen.width / 20 + Screen.width / 3, Screen.height / 3 + Screen.height / 22 + Screen.height / 6, Screen.width / 6, Screen.height / 22);
        botaoQualidadeAlta = new Rect(Screen.width / 2 + Screen.width / 17, Screen.height / 3 + Screen.height / 22 + Screen.height / 6, Screen.width / 6, Screen.height / 22);
        botaoQualidadeMuitoAlta = new Rect(Screen.width - Screen.width / 4 - Screen.width / 60, Screen.height / 3 + Screen.height / 6 + Screen.height / 22, Screen.width / 6, Screen.height / 22);
        textoLingua = new Rect(Screen.width / 24 + Screen.width / 28, Screen.height / 2 - Screen.height / 30 + Screen.height / 6, Screen.width / 8, Screen.height / 20);
        botaoLinguaIngles = new Rect(Screen.width / 24 + Screen.width / 6, Screen.height / 2 - Screen.height / 30 + Screen.height / 6, Screen.width / 6, Screen.height / 20);
        botaoLinguaPortugues = new Rect(Screen.width / 20 + Screen.width / 3, Screen.height / 2 - Screen.height / 30 + Screen.height / 6, Screen.width / 6, Screen.height / 20);
        botaoVoltar = new Rect(Screen.width / 2 - Screen.width / 12, Screen.height / 2 + Screen.height / 8 + Screen.height / 6, Screen.width / 6, Screen.height / 20);
        janelaLoading = new Rect(Screen.width / 2 - Screen.width / 4, Screen.height / 2 - Screen.height / 4, Screen.width / 2, Screen.height / 2);
    }

    void Options(int id)
    {
        GUI.Label(textoResolucao, texto.resolucao);
        if (GUI.Button(botaoResolucao600, "800x600"))
        {
            Screen.SetResolution(800, 600, fullScreen);
            currentResolution = 0;
        }
        if (GUI.Button(botaoResolucao768, "1024x768"))
        {
            Screen.SetResolution(1024, 768, fullScreen);
            currentResolution = 1;
        }
        if (GUI.Button(botaoResolucao720, "1280x720"))
        {
            Screen.SetResolution(1280, 720, fullScreen);
            currentResolution = 2;
        }
        if (GUI.Button(botaoResolucao1080, "1920x1080"))
        {
            Screen.SetResolution(1920, 1080, fullScreen);
            currentResolution = 3;
        }
        GUI.Label(textoTelaCheia, texto.telaCheia);
        fullScreen = GUI.Toggle(botaoTelaCheia, fullScreen, fullScreenText);
        GUI.Label(textoVolume, texto.volume);
        volumeSlider = GUI.HorizontalSlider(sliderVolume, volumeSlider, 0, 1);
        GUI.Label(textoSom, texto.som);
        som = GUI.Toggle(botaoSom, som, soundText);
        GUI.Label(textoQualidade, texto.qualidade);
        if (GUI.Button(botaoQualidadeBaixa, texto.qualidadeBaixa))
        {
            QualitySettings.SetQualityLevel(0);
        }
        if (GUI.Button(botaoQualidadeMedia, texto.qualidadeMedia))
        {
            QualitySettings.SetQualityLevel(2);
        }
        if (GUI.Button(botaoQualidadeAlta, texto.qualidadeAlta))
        {
            QualitySettings.SetQualityLevel(3);
        }
        if (GUI.Button(botaoQualidadeMuitoAlta, texto.qualidadeMuitoAlta))
        {
            QualitySettings.SetQualityLevel(5);
        }
        GUI.Label(textoLingua, texto.lingua);
        if (GUI.Button(botaoLinguaIngles, texto.linguaIngles))
        {
            ingles = true;
            portugues = false;
        }
        if (GUI.Button(botaoLinguaPortugues, texto.linguaPortugues))
        {
            portugues = true;
            ingles = false;
        }
        if (GUI.Button(botaoVoltar, texto.voltar))
        {
            optionWindow = false;
        }
    }

    void Loading(int id)
    {
        GUILayout.FlexibleSpace();
        GUILayout.BeginHorizontal();
        //GUILayout.Space(Screen.width / 32);
        GUILayout.FlexibleSpace();
        GUILayout.Label(loadImage);
        GUILayout.FlexibleSpace();
        //GUILayout.Space(Screen.width / 32);
        GUILayout.EndHorizontal();
        GUILayout.FlexibleSpace();
        GUILayout.BeginHorizontal();
        GUILayout.Space(Screen.width / 32);
        if (GUILayout.Button(texto.comecar))
        {
            if (PlayerPrefs.GetInt("NewGame") == 1)
                {
                    loading = true;
                    Application.LoadLevel(2);
                    loadWindow = false;
                }
        }
        GUILayout.Space(Screen.width / 32);
        if (GUILayout.Button(texto.voltar))
        {
            loadWindow = false;
        }
        GUILayout.Space(Screen.width / 32);
        GUILayout.EndHorizontal();
    }
}
