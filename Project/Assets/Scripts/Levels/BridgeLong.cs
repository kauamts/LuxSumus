using UnityEngine;
using System.Collections;

public class BridgeLong : MonoBehaviour
{
	private bool disabled;
	public Switch trigger_01;
//	public Switch trigger_02;
	public GameObject wall;
	public Animator plataform_01;
	public Animator plataform_02;
	public Animator plataform_03;
	public Animator plataform_04;
	public Animator plataform_05;
	public Animator plataform_06;
	public Animator plataform_07;
	private bool startDelay;
	private float tempo;
	public float delayTime = 2f;

	void Start ()
	{
		
	}
	
	void FixedUpdate ()
	{
		if(!disabled)
		{
			if(trigger_01.ativada /*&& trigger_02.ativada*/)
			{ 
				plataform_01.SetBool("goUp",true);
				plataform_02.SetBool("goUp",true);
				plataform_03.SetBool("goUp",true);
				plataform_04.SetBool("goUp",true);
				plataform_05.SetBool("goUp",true);
				plataform_06.SetBool("goUp",true);
				plataform_07.SetBool("goUp",true);
				startDelay = true;
				disabled = true;
			}
		}

		if(startDelay)
		{
			tempo += 1*Time.deltaTime;

			if(tempo > delayTime)
			{
				wall.collider.enabled = false;
				startDelay = false;
			}
		}
	}

}
