using UnityEngine;
using System.Collections;

public class IntroManager : MonoBehaviour
{	
	private bool fInUp;
	private bool fOutUp;
	private bool fInUnity;
	private bool fOutUnity;	
	private bool fInYgg;
	private bool fOutYgg;	
	private bool fInLux;
	private bool fOutLux;

	public Animator animUp;
	public Animator animUnity;
	public Animator animYgg;
	public Animator animLux;

	public float viewingTime = 5;
	public float blackTime = 3;
	public float startTime = 2;
	public float endTime = 2;

	private float timer;

	void Start ()
	{
		timer = 0;

		animUp = GameObject.FindGameObjectWithTag("Animator").GetComponent<Animator>();
		animUnity = GameObject.FindGameObjectWithTag("Animator").GetComponent<Animator>();
		animYgg = GameObject.FindGameObjectWithTag("Animator").GetComponent<Animator>();
		animLux = GameObject.FindGameObjectWithTag("Animator").GetComponent<Animator>();
	}
	
	void FixedUpdate ()
	{
		timer += Time.deltaTime;print (timer);

		//BUTTON LOAD MENU
		if(timer > startTime && Input.anyKeyDown)
		{
			Application.LoadLevel(1);
		}

		//UP
		if(timer > startTime && !fInUp)
		{
			animUp.SetBool("fadeIn", true);
			fInUp = true;
		}
		if(timer > (startTime + viewingTime) && !fOutUp)
		{
			animUp.SetBool("fadeIn", false);
			fOutUp = true;
		}

		//Unity
		if(timer > (startTime + viewingTime + blackTime) && !fInUnity)
		{
			animUnity.SetBool("fadeIn", true);
			fInUnity = true;
		}
		if(timer > ((startTime + viewingTime + blackTime) + viewingTime) && !fOutUnity)
		{
			animUnity.SetBool("fadeIn", false);
			fOutUnity = true;
		}
		
		//Yggdrasil
		if(timer > (((startTime + viewingTime + blackTime) + viewingTime) + blackTime) && !fInYgg)
		{
			animYgg.SetBool("fadeIn", true);
			fInYgg = true;
		}
		if(timer > ((((startTime + viewingTime + blackTime) + viewingTime) + blackTime) + viewingTime) && !fOutYgg)
		{
			animYgg.SetBool("fadeIn", false);
			fOutYgg = true;
		}
		
		//Lux Sumus
		if(timer > (((((startTime + viewingTime + blackTime) + viewingTime) + blackTime) + viewingTime) + blackTime) && !fInLux)
		{
			animLux.SetBool("fadeIn", true);
			fInLux = true;
		}
		if(timer > ((((((startTime + viewingTime + blackTime) + viewingTime) + blackTime) + viewingTime) + blackTime) + viewingTime) && !fOutLux)
		{
			animLux.SetBool("fadeIn", false);
			fOutLux = true;
		}

		//END LOAD MENU
		if(timer > (((((((startTime + viewingTime + blackTime) + viewingTime) + blackTime) + viewingTime) + blackTime) + viewingTime) + endTime))
		{
			Application.LoadLevel(1);
		}

	}

}
