using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour
{
    #region float variables
    public float timer;
    #endregion

    // Use this for initialization
	void Start () {
        timer = 1.0f;
        StartCoroutine("DeleteExplosion");
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator DeleteExplosion()
    {
        yield return new WaitForSeconds(timer);
        Destroy(gameObject);
    }
}
