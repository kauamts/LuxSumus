using UnityEngine;
using System.Collections;

public class SentryDodger : Sentry
{
    #region Transform variables
    public Transform[] dodgeSpots;
    #endregion
    #region int variables
    public int spotNumber;
    #endregion
    #region bool variables
    public bool dodged;
    #endregion
    // Use this for initialization
    public override void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemyMaxLife = 10;
        enemyLife = enemyMaxLife;
        enemySpeed = 10.0f;
        state = State.Patrol;
        gotHit = false;
        shooting = false;
        dodged = false;
        gameManager = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<GameManager>();

    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        //SpotManager();
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
        gameObject.transform.Rotate(Vector3.up, 30.0f * enemySpeed * Time.deltaTime);
    }

    public override IEnumerator Alert()
    {
        //agent.destination = GameObject.FindGameObjectWithTag("Player").transform.position;
        yield return new WaitForSeconds(1);
        //gotHit = false;
        //state = State.Patrol;
    }

    public override void Pursuit()
    {
        base.Pursuit();
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

    public override IEnumerator Attack()
    {
        yield return new WaitForSeconds(1.0f);
        shooting = false;
    }

    public override void Shooting()
    {
        if (!shooting && player.GetComponent<Player>().health > 0)
        {
            shooting = true;
            Instantiate(enemyAmmo, transform.position, transform.rotation);
            StartCoroutine("Attack");
        }
    }

    IEnumerator Dodge()
    {
        this.gameObject.transform.position = dodgeSpots[spotNumber].position;
        transform.LookAt(player.transform.position);
        Shooting();
        yield return new WaitForSeconds(0.1f);
        dodged = false;
        
    }

    void SpotManager()
    {
        if (!dodged)
        {
            //spotNumber = 0;
            //this.gameObject.transform.position = dodgeSpots[spotNumber].position;
        }
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
            if (spotNumber == 0 && !dodged)
            {
                spotNumber = Random.Range(1, 2);
                dodged = true;
            }
            else if (spotNumber == 1 && !dodged)
            {
                spotNumber = Random.Range(0, 2);
                if (spotNumber == 1)
                {
                    spotNumber = 2;
                }
                dodged = true;
            }
            else if (spotNumber == 2 && !dodged)
            {
                spotNumber = Random.Range(0, 1);
                dodged = true;
            }
            StartCoroutine("Dodge");
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

    void OnCollisionStay(Collision collision)
    {
        
    }
}
