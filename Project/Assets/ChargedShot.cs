using UnityEngine;
using System.Collections;

public class ChargedShot : MonoBehaviour {
    public GameObject centralShot;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.RotateAround(centralShot.transform.position, Vector3.forward, 720.0f*Time.deltaTime);
	
	}
}
