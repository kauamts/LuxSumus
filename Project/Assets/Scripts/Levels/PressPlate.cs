using UnityEngine;
using System.Collections;

public class PressPlate : MonoBehaviour
{
    #region GameObject variables
    public GameObject botao;
    #endregion
    #region bool variables
    public bool ativada;
    #endregion
    #region Material variables
    public Material corAtivada;
    public Material corDesativada;
    #endregion
    // Use this for initialization
	void Start () {
        ativada = false;
	
	}
	
	// Update is called once per frame
	void Update () {
        Estado();
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            ativada = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            ativada = false;
        }
    }

    void Estado()
    {
        if (ativada)
        {
            botao.gameObject.renderer.material = corAtivada;
        }

        else
        {
            botao.gameObject.renderer.material = corDesativada;
        }
    }
}
