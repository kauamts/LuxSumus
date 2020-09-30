using UnityEngine;
using System.Collections;

public class FlashingLantern : MonoBehaviour
{
	public Animator lantern;

	void OnTriggerStay (Collider hit)
	{
		if(hit.tag == "Player")
		{
			lantern.SetBool("turnOn",true);
		}
	}

	void OnTriggerExit (Collider hit)
	{
		if(hit.tag == "Player")
		{
			lantern.SetBool("turnOn",false);
		}
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            audio.Play();
        }
    }
}
