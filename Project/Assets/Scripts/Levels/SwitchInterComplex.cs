using UnityEngine;
using System.Collections;

public class SwitchInterComplex : MonoBehaviour
{
	public SwitchLineComplex in_01;
	public SwitchLineComplex in_02;
	public SwitchLineComplex out_01;
	public Material corAtivada;
	public Material corDesativada;

	void Start ()
	{
		
	}
	
	void Update ()
	{
		if(in_01.hasJuice && in_02.hasJuice)
		{
			this.renderer.material = corAtivada;
			out_01.hasJuice = true;
		}
		else
		{
			this.renderer.material = corDesativada;
			out_01.hasJuice = false;
		}
	}

}
