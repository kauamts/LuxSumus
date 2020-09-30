using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour
{
    #region Rect variables
    public Rect gameOver;
    #endregion
    #region Texto variables
    public Texto texto;
    #endregion
    #region bool variables
    public bool restart;
    public bool restartable;
    #endregion
    #region Texture variables
    public Texture textura;
    #endregion
    #region GameObject variables
    public GameObject toBeContinued;
    public GameObject continua;
    #endregion
    #region GameManager variables
    public GameManager manager;
    #endregion
    // Use this for initialization
	void Start () {
        manager = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<GameManager>();
        texto = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<Texto>();
        restart = false;
        StartCoroutine("EndGame");
        //StartCoroutine("MinimumTime");
	
	}
	
	// Update is called once per frame
	void Update () {
        RectPosition();
        Restart();
        if (manager.ingles)
        {
            toBeContinued.SetActive(true);
        }

        else if (manager.portugues)
        {
            continua.SetActive(true);
        }
	
	}

    void RectPosition()
    {
        //gameOver = new Rect(Screen.width / 2 - Screen.width / 4, Screen.height / 2 - Screen.height / 4, Screen.width / 2, Screen.height / 2);
    }

    void OnGUI()
    {
        //GUI.Label(gameOver, textura);
    }

    IEnumerator MinimumTime()
    {
        yield return new WaitForSeconds(2.0f);
        if (Input.anyKey)
        {
            restart = true;
        }

    }

    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(2.0f);
        restartable = true;
        yield return new WaitForSeconds(28.0f);
        restart = true;
    }

    void Restart()
    {
        if (restartable)
        {
            if (Input.anyKey)
            {
                restart = true;
            }
        }
        if (restart)
        {
            Application.LoadLevel(1);
        }
    }
}
