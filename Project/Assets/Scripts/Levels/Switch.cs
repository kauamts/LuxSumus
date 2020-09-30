using UnityEngine;
using System.Collections;

public class Switch : MonoBehaviour
{
    #region bool variables
    public bool ativada;
    #endregion
    #region Animator variables
	public Animator switchCube;
    #endregion
    // Use this for initialization
	void Start () {
        ativada = false;
		this.renderer.enabled = false;
	
	}
	
	// Update is called once per frame
	void Update () {
        Estado();
	
	}

    void Estado()
    {
        if (ativada)
        {
			switchCube.SetBool("hit",true);
        }

        else
        {
			switchCube.SetBool("hit",false);
        }
    }
}
