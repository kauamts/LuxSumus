using UnityEngine;
using System.Collections;

public class CubeSpin_RedMarker : MonoBehaviour
{
	public bool visible;

	void Awake ()
	{
		if(!visible)
			this.renderer.enabled = false;
	}
}
