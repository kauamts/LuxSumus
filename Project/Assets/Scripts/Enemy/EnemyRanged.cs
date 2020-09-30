using UnityEngine;
using System.Collections;

public class EnemyRanged : Enemy
{
    #region GameObject variables
    public GameObject player;
    public GameObject enemyAmmo;
    #endregion
    // Use this for initialization
    public override void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        enemyMaxLife = 10;
        enemyLife = enemyMaxLife;
        enemySpeed = 10.0f;
        state = State.Patrol;
        gotHit = false;
        attack = false;
        gameManager = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<GameManager>();

    }

    // Update is called once per frame
    public override void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        base.Update();
        if (playerDetected)
        {
            Pursuit();
        }
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
            enemyMaxLife = 2;
            enemySpeed = 3.5f;
            agent.speed = enemySpeed;
            damage = 20.0f;
            attackSpeed = 1.3f;
        }
        else if (gameManager.dificuldade == 1)
        {
            enemyMaxLife = 3;
            enemySpeed = 4.0f;
            agent.speed = enemySpeed;
            damage = 50.0f;
            attackSpeed = 1.0f;
        }
        else if (gameManager.dificuldade == 2)
        {
            enemyMaxLife = 4;
            enemySpeed = 5.0f;
            agent.speed = enemySpeed;
            damage = 80.0f;
            attackSpeed = 0.8f;
        }
    }

    public override void EnterState(State stateEntered)
    {
        switch (stateEntered)
        {
            case State.Patrol:
                InvokeRepeating("Patrolling", 1f, 2f);
                break;

            case State.Alert:
                StartCoroutine("Alert");
                break;

            case State.Pursuit:

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

                break;

            case State.Dead:
                break;
        }
    }

    public override void Patrolling()
    {
        agent.destination = patrolPoints[a].position;

        if (a == patrolPoints.Length - 1 && patrolDirection == false)
        {
            patrolDirection = true;
        }
        else if (patrolDirection == false)
        {
            a++;
        }
        if (a == 0)
        {
            patrolDirection = false;
        }
        else if (patrolDirection == true)
        {
            a--;
        }


    }

    public override IEnumerator Alert()
    {
        agent.destination = GameObject.FindGameObjectWithTag("Player").transform.position;
        yield return new WaitForSeconds(1);
        gotHit = false;
        //state = State.Pursuit;
    }

    public override void Pursuit()
    {
        transform.LookAt(player.transform.position);
    }

    public void Shooting()
    {
        if (!attack && player.GetComponent<Player>().health > 0)
        {
            attack = true;
            Instantiate(enemyAmmo, transform.position, transform.rotation);
            StartCoroutine("Attack");
        }
    }

    public override IEnumerator Death()
    {
        //animação de morte
        yield return new WaitForSeconds(0.1f);
        //Destroy(gameObject);
        Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
        gameObject.SetActive(false);
        enemyLife = enemyMaxLife;
        attack = false;
        gameObject.transform.position = patrolPoints[0].transform.position;
        state = State.Patrol;
    }

    public override IEnumerator Attack()
    {
        yield return new WaitForSeconds(attackSpeed);
        attack = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerPosition = other.gameObject.transform;
            playerDetected = true;
            state = State.Pursuit;
        }

        if (other.gameObject.tag == "Ammo")
        {
            playerDetected = false;
            state = State.Alert;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            transform.LookAt(other.transform.position);
            Shooting();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerDetected = false;
            state = State.Alert;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ammo" || collision.gameObject.tag == "Espada")
        {
            audio.PlayOneShot(hit);
        }
    }
}
