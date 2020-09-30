using UnityEngine;
using System.Collections;

public class Tutorial : MonoBehaviour
{
    #region int variables
    public int number;
    #endregion
    #region texto variables
    public Texto texto;
    #endregion
    #region bool variables
    public bool ativa;
    #endregion
    #region Rect variables
    public Rect windowsPosition;
    #endregion
    #region string variables
    public string tutorial;
    #endregion
    #region GUISkin variables
    public GUISkin guiSkin;
    #endregion

    // Use this for initialization
	void Start () {
        ativa = false;
        texto = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<Texto>();
	
	}
	
	// Update is called once per frame
	void Update () {
        RectPosition();
        tutorial = texto.tutorial[number];
	
	}

    void RectPosition()
    {
        windowsPosition = new Rect((Screen.width / 2 - Screen.width / 4),(Screen.height / 2 + Screen.height/4), Screen.width / 2, Screen.height / 4);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            ativa = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            ativa = false;
        }
    }

    void OnGUI()
    {
        GUI.skin = guiSkin;
        if (ativa)
        {
            GUI.Box(windowsPosition, tutorial);
        }
    }
}
