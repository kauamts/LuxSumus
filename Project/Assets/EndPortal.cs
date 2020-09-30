using UnityEngine;
using System.Collections;

public class EndPortal : MonoBehaviour {
    public AnimationClip portalAnimation;

	// Use this for initialization
	void Start () {
        //StartCoroutine("EndGame");
        
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(portalAnimation.length);
        Application.LoadLevel(4);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Debug.Log("hit");
            //animation.Play();
            gameObject.GetComponentInChildren<Animator>().Play("portal_animation");
            StartCoroutine("EndGame");
            other.gameObject.SetActive(false);
            gameObject.GetComponentInChildren<AudioListener>().enabled = true;
            gameObject.GetComponentInChildren<AudioListener>().audio.Play();
        }
    }
}
