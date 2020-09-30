using UnityEngine;
using System.Collections;

public class Texto : MonoBehaviour
{
    #region GameManager variables
    public GameManager manager;
    #endregion
    #region string variables
    public string choose;
    public string ready;
    public string start;
    public string novoJogo;
    public string carregarJogo;
    public string opcoes;
    public string sair;
    public string resolucao;
    public string telaCheia;
    public string volume;
    public string som;
    public string qualidade;
    public string qualidadeBaixa;
    public string qualidadeMedia;
    public string qualidadeAlta;
    public string qualidadeMuitoAlta;
    public string gamma;
    public string lingua;
    public string linguaPortugues;
    public string linguaIngles;
    public string voltar;
    public string ligado;
    public string desligado;
    public string salvarJogo;
    public string[] tutorial;
    public string gameOver;
    public string dificuldade;
    public string dificuldadeFacil;
    public string dificuldadeNormal;
    public string dificuldadeDificil;
    public string comecar;
    #endregion
    #region Texture variables
    public Texture options;
    public Texture optionsPort;
    public Texture optionsIng;
    #endregion

    // Use this for initialization
	void Start () {
        manager = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<GameManager>();
        choose = "Language/Idioma: ";
	
	}
	
	// Update is called once per frame
	void Update () {
        if (manager.ingles)
        {
            ready = "Ready";
            start = "Press any key to start!";
            novoJogo = "New Game";
            carregarJogo = "Load Game";
            opcoes = "Options";
            sair = "Exit";
            resolucao = "Resolution";
            telaCheia = "Fullscreen";
            volume = "Volume";
            som = "Sound";
            qualidade = "Quality";
            qualidadeBaixa = "Low";
            qualidadeMedia = "Medium";
            qualidadeAlta = "High";
            qualidadeMuitoAlta = "Very High";
            gamma = "Gamma";
            lingua = "Language";
            linguaIngles = "English";
            linguaPortugues = "Portuguese";
            voltar = "Back";
            ligado = " On";
            desligado = " Off";
            salvarJogo = "Save Game";
            tutorial[0] = "W, A, S, D to move";
            tutorial[1] = "Right Mouse Button to Attack";
            tutorial[2] = "Left Mouse Button to Shoot";
            tutorial[3] = "Hold the Mouse Button \n to charge the Shot or Sword";
            gameOver = "Game Over";
            dificuldade = "Difficulty";
            dificuldadeFacil = "Easy";
            dificuldadeNormal = "Normal";
            dificuldadeDificil = "Hard";
            comecar = "Start";
            options = optionsIng;
        }

        if (manager.portugues)
        {
            ready = "Pronto";
            start = "Pressione qualquer tecla para começar!";
            novoJogo = "Novo Jogo";
            carregarJogo = "Carregar Jogo";
            opcoes = "Opções";
            sair = "Sair";
            resolucao = "Resolução";
            telaCheia = "Tela Cheia";
            volume = "Volume";
            som = "Som";
            qualidade = "Qualidade";
            qualidadeBaixa = "Baixa";
            qualidadeMedia = "Mèdia";
            qualidadeAlta = "Alta";
            qualidadeMuitoAlta = "Muito Alta";
            gamma = "Gamma";
            lingua = "Idioma";
            linguaIngles = "Inglês";
            linguaPortugues = "Português";
            voltar = "Voltar";
            ligado = " Ligado";
            desligado = " Desligado";
            salvarJogo = "Salvar Jogo";
            tutorial[0] = "W, A, S, D para mover";
            tutorial[1] = "Botão Direito do Mouse para Atacar";
            tutorial[2] = "Botão Esquerdo do Mouse para Atirar";
            tutorial[3] = "Segure o Botão do Mouse \n para Carregar o Ataque ou Tiro";
            gameOver = "Fim de Jogo";
            dificuldade = "Dificuldade";
            dificuldadeFacil = "Fàcil";
            dificuldadeNormal = "Normal";
            dificuldadeDificil = "Difìcil";
            comecar = "Iniciar";
            options = optionsPort;
        }
	
	}
}
