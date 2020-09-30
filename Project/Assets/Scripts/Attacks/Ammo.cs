using UnityEngine;
using System.Collections;

public class Ammo : MonoBehaviour
{
    #region float variables
    public float speed;
    public float timer;
    #endregion
    #region GameObject variables
    public GameObject luz;
    public GameObject player;
    #endregion
    #region Player variables
    public Player playerScript;
    #endregion
    #region int variables
    public int damage;
    #endregion
    
    // Use this for initialization
	void Start () {
        speed = 20.0f;
        timer = 0.8f;
        player = GameObject.FindGameObjectWithTag("Player");
        //Physics.IgnoreCollision(gameObject.collider, player.collider);
        Physics.IgnoreLayerCollision(8, 9, true);
        Physics.IgnoreLayerCollision(9, 13, true);
        Physics.IgnoreLayerCollision(9, 14, true);
        playerScript = player.GetComponent<Player>();
        StartCoroutine("ExpireTimer");
        luz.light.color = this.gameObject.renderer.material.color;
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(0, 0, 1 * speed * Time.deltaTime);	
	}

    void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(collision.gameObject.name);
        if (collision.gameObject.tag == "Cenário")
        {
            if (damage == 3)
            {
                Instantiate(luz, transform.position, transform.rotation);
            }
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Enemy")
        {
            if (damage == 3)
            {
                Instantiate(luz, transform.position, transform.rotation);
            }
            collision.gameObject.GetComponent<EnemyMelee>().enemyLife -= damage;
            collision.gameObject.GetComponent<EnemyMelee>().gotHit = true;
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Enemy Ranged")
        {
            if (damage == 3)
            {
                Instantiate(luz, transform.position, transform.rotation);
            }
            collision.gameObject.GetComponent<EnemyRanged>().enemyLife -= damage;
            collision.gameObject.GetComponent<EnemyRanged>().gotHit = true;
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Switch")
        {
            if (damage == 3)
            {
                Instantiate(luz, transform.position, transform.rotation);
            }
            collision.gameObject.GetComponent<Switch>().ativada = true;
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Sentry")
        {
            if (damage == 3)
            {
                Instantiate(luz, transform.position, transform.rotation);
            }
            collision.gameObject.GetComponent<Sentry>().enemyLife -= damage;
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Sentry Dodger")
        {
            if (damage == 3)
            {
                Instantiate(luz, transform.position, transform.rotation);
            }
            collision.gameObject.GetComponent<SentryDodger>().enemyLife -= damage;
            Destroy(gameObject);
        }
    }

    IEnumerator ExpireTimer()
    {
        yield return new WaitForSeconds(timer);
        Destroy(gameObject);
    }
}
