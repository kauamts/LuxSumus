using UnityEngine;
using System.Collections;

public class Sentry : Enemy
{
    #region GameObject variables
    public GameObject enemyAmmo;
    public GameObject player;
    #endregion
    #region float variables
    public float error;
    #endregion
    #region bool variables
    public bool rotationChange;
    public bool shooting;
    #endregion
    #region Quaternion variables
    public Quaternion rotation = new Quaternion(0, 60, 0, 0);
    #endregion
    
    // Use this for initialization
	public override void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        enemyMaxLife = 10;
        enemyLife = enemyMaxLife;
        enemySpeed = 1.0f;
        state = State.Patrol;
        gotHit = false;
        shooting = false;
        rotationChange = false;
        gameManager = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<GameManager>();
	
	}
	
	// Update is called once per frame
    public override void Update()
    {
        //RotationChange();
        DifficultyControl();
        LifeControl();
	
	}

    public override void LifeControl()
    {
        if (enemyLife <= 0)
        {
            state = State.Dead;
        }
        if (enemyLife > enemyMaxLife)
        {
            enemyLife = enemyMaxLife;
        }

        //if (state == State.Patrol)
        //{
            //enemyLife = enemyMaxLife;
        //}
    }

    public override void DifficultyControl()
    {
        if (gameManager.dificuldade == 0)
        {

        }
        else if (gameManager.dificuldade == 1)
        {

        }
        else if (gameManager.dificuldade == 2)
        {

        }
    }

    public override void EnterState(State stateEntered)
    {
        switch (stateEntered)
        {
            case State.Patrol:
                InvokeRepeating("Patrolling", 0, 0.1f);
                break;

            case State.Alert:
                
                break;

            case State.Pursuit:
                InvokeRepeating("Pursuit", 0, 0.1f);
                break;

            case State.Dead:
                StartCoroutine("Death");
                break;
        }
    }

    public override void ExitState(State stateExited)
    {
        switch (stateExited)
        {

            case State.Patrol:
                CancelInvoke("Patrolling");
                break;

            case State.Alert:

                break;

            case State.Pursuit:
                CancelInvoke("Pursuit");
                break;

            case State.Dead:
                break;
        }
    }

    public override void Patrolling()
    {
        gameObject.transform.Rotate(Vector3.up, 60.0f * enemySpeed * Time.deltaTime);
    }

    public override IEnumerator Attack()
    {
        yield return new WaitForSeconds(1.0f);
        shooting = false;
    }

    public virtual void Shooting()
    {
        if (!shooting && player.GetComponent<Player>().health > 0)
        {
            shooting = true;
            Instantiate(enemyAmmo, transform.position, transform.rotation);
            StartCoroutine("Attack");
        }
    }

    void RotationChange()
    {
        //if (gameObject.transform.rotation.eulerAngles.y <= 300 && gameObject.transform.rotation.eulerAngles.y >= 60)
        //{
            //rotationChange = !rotationChange;
        //} 
    }

    public override IEnumerator Alert()
    {
        transform.LookAt(player.transform.position);
        Shooting();
        yield return new WaitForSeconds(1.0f);
    }

    public override void Pursuit()
    {
        transform.LookAt(player.transform.position);
    }

    public override IEnumerator Death()
    {
        //animação de morte
        yield return new WaitForSeconds(0.1f);
        //Destroy(gameObject);
        gameObject.SetActive(false);
        enemyLife = enemyMaxLife;
        shooting = false;
        state = State.Patrol;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerPosition = other.gameObject.transform;
            playerDetected = true;
            state = State.Pursuit;
        }
        else if (other.gameObject.tag == "Ammo")
        {
            StartCoroutine("Alert");
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            transform.LookAt(player.transform.position);
            Shooting();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerDetected = false;
            state = State.Patrol;
        }
    }
}
