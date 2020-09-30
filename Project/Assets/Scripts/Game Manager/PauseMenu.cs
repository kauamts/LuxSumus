using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour
{
    #region GameManager variables
    public GameManager manager;
    #endregion
    #region GameObject variables
    public GameObject player;
    #endregion
    #region Texto variables
    public Texto texto;
    #endregion
    #region bool variables
    public bool menuAvaiable;
    public bool isPaused;
    #endregion
    #region Rect variables
    public Rect box;
    public Rect voltar;
    public Rect salvar;
    public Rect carregar;
    public Rect opcoes;
    public Rect sair;
    #endregion
    #region GuiSkin variables
    public GUISkin optionSkin;
    #endregion

    // Use this for initialization
	void Start () {
        manager = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<GameManager>();
        texto = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<Texto>();
        player = GameObject.FindGameObjectWithTag("Player");
        menuAvaiable = false;
        isPaused = false;
	
	}
	
	// Update is called once per frame
	void Update () {
        SceneCheck();
        RectPosition();
        PauseTime();
        if (!manager.optionWindow)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                isPaused = !isPaused;
            }
        }

        if (manager.optionWindow)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                manager.optionWindow = false;
            }
        }
	
	}

    void SceneCheck()
    {
        if (Application.loadedLevelName != "Main Menu" && Application.loadedLevelName != "Game Over" && Application.loadedLevelName != "Loading" && Application.loadedLevelName != "Intro")
        {
            menuAvaiable = true;
        }
        else
        {
            menuAvaiable = false;
            isPaused = false;
        }
    }
    void RectPosition()
    {
        box = new Rect(0, 0, Screen.width, Screen.height);
        //voltar = new Rect((Screen.width / 2 - Screen.width/8), (Screen.height / 4), Screen.width / 4, Screen.height / 16);
        voltar = new Rect((Screen.width / 2 - Screen.width / 8), (Screen.height / 4 + Screen.height / 12), Screen.width / 4, Screen.height / 16);
        carregar = new Rect((Screen.width / 2 - Screen.width / 8), (Screen.height / 4 + Screen.height / 6), Screen.width / 4, Screen.height / 16);
        opcoes = new Rect((Screen.width / 2 - Screen.width / 8), (Screen.height / 4 + Screen.height / 4), Screen.width / 4, Screen.height / 16);
        sair = new Rect((Screen.width / 2 - Screen.width / 8), (Screen.height / 4 + Screen.height / 3), Screen.width / 4, Screen.height / 16);
    }

    void PauseTime()
    {
        if (isPaused)
        {
            Time.timeScale = 0.0f;
        }
        else
        {
            Time.timeScale = 1.0f;
        }
    }

    void OnGUI()
    {
        GUI.skin = optionSkin;
        if (isPaused && !manager.optionWindow && !manager.loadWindow)
        {
            GUI.Box(box, "");
            if (GUI.Button(voltar, texto.voltar))
            {
                isPaused = false;
            }
            if (GUI.Button(salvar, texto.salvarJogo))
            {
                //SaveLoad.Save();
                PlayerPrefs.Save();
            }
            GUI.enabled = manager.hasSavedGame;
            if (GUI.Button(carregar, texto.carregarJogo))
            {
                //SaveLoad.Load();
                //Application.LoadLevel(1);
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
                manager.loading = false;
                isPaused = false;
                Application.LoadLevel(2);
            }
        }
    }
}
