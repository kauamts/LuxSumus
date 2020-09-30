using UnityEngine;
using System.Collections;

public class CheckpointAnim : MonoBehaviour
{
	public Animator crystal;
	public Renderer crystalColor;
	public Light luz;
	public Material corAtivado;
	public Material corDesativado;
	public bool turnedOn;
	private float tempo;

	void FixedUpdate ()
	{
		if(turnedOn)
		{
			tempo += Time.deltaTime;			
			luz.enabled = true;
			crystalColor.material = corAtivado;

			if(tempo > 1f)
			{
				crystal.SetBool("turnOn",true);
			}
		}
	}
	
	void OnTriggerStay (Collider hit)
	{
		if(hit.tag == "Player")
		{
			turnedOn = true;
		}
	}

}
