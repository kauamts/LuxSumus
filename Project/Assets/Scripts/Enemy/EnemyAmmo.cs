using UnityEngine;
using System.Collections;

public class EnemyAmmo : MonoBehaviour
{
    #region float variables
    public float speed;
    public float timer;
    #endregion
    #region GameObject variables
    public GameObject enemyRanged;
    #endregion
    // Use this for initialization
	void Start () {
        speed = 20.0f;
        timer = 0.8f;
        enemyRanged = GameObject.FindGameObjectWithTag("Enemy Ranged");
        //Physics.IgnoreCollision(gameObject.collider, enemyRanged.collider);
        Physics.IgnoreLayerCollision(10, 11, true);
        Physics.IgnoreLayerCollision(10, 14, true);
        StartCoroutine("ExpireTimer");
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(0, 0, 1 * speed * Time.deltaTime);
	
	}

    void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(collision.gameObject.name);
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().health -= 10.0f;
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Cenário")
        {
            //collision.gameObject.GetComponent<Player>().health -= 10.0f;
            Destroy(gameObject);
        }
    }

    IEnumerator ExpireTimer()
    {
        yield return new WaitForSeconds(timer);
        Destroy(gameObject);
    }
}
