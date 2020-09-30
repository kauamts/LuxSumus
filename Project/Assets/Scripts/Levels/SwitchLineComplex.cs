using UnityEngine;
using System.Collections;

public class SwitchLineComplex : MonoBehaviour
{
	public bool hasJuice;
	public Renderer cube_01;
	public Renderer cube_02;
	public Material corAtivada;
	public Material corDesativada;

	void Start ()
	{
		
	}
	
	void Update ()
	{
		if(hasJuice)
		{
			cube_01.material = corAtivada;
			cube_02.material = corAtivada;
		}
		else
		{
			cube_01.material = corDesativada;
			cube_02.material = corDesativada;
		}
	}

}
