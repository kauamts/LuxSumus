using UnityEngine;
using System.Collections;

public class Espada : MonoBehaviour
{
    #region GameObject variables
    public GameObject player;
    #endregion
    #region float variables
    public float rotation = -60.0f;
    public float timer;
    #endregion
    #region int variables
    public int damage;
    #endregion
    // Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        //Physics.IgnoreCollision(gameObject.collider, player.collider);
        Physics.IgnoreLayerCollision(8, 13, true);
        Physics.IgnoreLayerCollision(9, 13, true);
        Physics.IgnoreLayerCollision(12, 13, true);
        Physics.IgnoreLayerCollision(14, 13, true);
        if (damage == 1)
        {
            timer = 0.25f;
        }
        else if (damage == 2)
        {
            timer = 0.50f;
        }
        else if (damage == 3)
        {
            timer = 0.75f;
        }
        StartCoroutine("DestroySword");
	
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.Rotate(Vector3.up, 540.0f * Time.deltaTime);
	
	}

    IEnumerator DestroySword()
    {
        yield return new WaitForSeconds(timer);
        Destroy(gameObject);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyMelee>().enemyLife -= damage;
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Enemy Ranged")
        {
            collision.gameObject.GetComponent<EnemyRanged>().enemyLife -= damage;
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Switch")
        {
            collision.gameObject.GetComponent<Switch>().ativada = true;
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Sentry")
        {
            collision.gameObject.GetComponent<Sentry>().enemyLife -= damage;
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Sentry Dodger")
        {
            collision.gameObject.GetComponent<SentryDodger>().enemyLife -= damage;
            Destroy(gameObject);
        }
    }
}
