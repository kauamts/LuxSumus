using UnityEngine;
using System.Collections;

public class LightExplosion : MonoBehaviour
{
    #region float variables
    public float duration;
    public float range;
    public float intensity;
    #endregion
    // Use this for initialization
	void Start () {
        duration = 5.0f;
        range = 50.0f;
        intensity = 3.0f;
        this.gameObject.light.range = range;
        this.gameObject.light.intensity = intensity;
        StartCoroutine("Duration");
	
	}
	
	// Update is called once per frame
	void Update () {
        this.gameObject.light.range -= 10.0f * Time.deltaTime;
        this.gameObject.light.intensity -= 0.6f * Time.deltaTime;
	
	}

    IEnumerator Duration(){
        yield return new WaitForSeconds(duration);
        Destroy(gameObject);
    }
}
