using UnityEngine;
using System.Collections;

public class EnemyMeleeAttack : MonoBehaviour {
    public float timer;

    public Transform player;

	// Use this for initialization
	void Start () {
        timer = 1.0f;
        StartCoroutine("DeleteObject");
	
	}

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        transform.LookAt(player);
    }
	
	// Update is called once per frame
	void Update () {
       transform.LookAt(player);
	
	}

    IEnumerator DeleteObject()
    {
        yield return new WaitForSeconds(timer);
        Destroy(gameObject);
    }
}
