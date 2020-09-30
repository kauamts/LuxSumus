using UnityEngine;
using System.Collections;

public class HideOnPlay : MonoBehaviour
{
	void Awake()
	{
		this.renderer.enabled = false;
	}
}
