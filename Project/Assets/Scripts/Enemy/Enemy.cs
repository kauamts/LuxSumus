using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    #region int variables
    public int enemyMaxLife;
    public int enemyLife;
	public int a;
    #endregion
    #region float variables
    public float enemySpeed;
    public float damage;
    public float attackSpeed;
    #endregion
    #region bool variables
    public bool playerDetected;
	public bool patrolDirection;
    public bool gotHit;
    public bool attack;
    #endregion
    #region Vector3 variables
    public Vector3 enemyPosition;
	public Vector3 enemyDirection;
    #endregion
    #region Transform variables
    public Transform[] patrolPoints;
	public Transform playerPosition;
    #endregion
    #region NavMeshAngent variables
    public NavMeshAgent agent;
    #endregion
    #region enum variables
    public enum State{
		Patrol,
        Alert,
		Pursuit,
		Dead
	}
    #endregion
    #region State variables
    private State _state;

	public State state{
		get{
			return _state;
		}
		set{
			ExitState(_state);
			_state = value;
			EnterState(_state);
		}
	}
    #endregion
    #region GameManager variables
    public GameManager gameManager;
    #endregion
    #region GameObject variables
    public GameObject explosion;
    #endregion

    public AudioClip hit;
    // Use this for initialization
	public virtual void Start () {
		agent = GetComponent<NavMeshAgent> ();
		enemyMaxLife = 10;
		enemySpeed = 10.0f;
		state = State.Patrol;
        gotHit = false;
        attack = false;


	}
	
	// Update is called once per frame
	public virtual void Update () {
        LifeControl();
        DifficultyControl();
        if (gotHit && state != State.Pursuit)
        {
            state = State.Alert;
        }
	}

    public virtual void LifeControl()
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

    public virtual void DifficultyControl()
    {
        if (gameManager.dificuldade == 0)
        {
            enemyMaxLife = 3;
            enemySpeed = 10.0f;
            damage = 10.0f;
            attackSpeed = 1.0f;
        }
        else if (gameManager.dificuldade == 1)
        {

        }
        else if (gameManager.dificuldade == 2)
        {

        }
    }

	public virtual void EnterState(State stateEntered){
		switch (stateEntered) {
		case State.Patrol:
			InvokeRepeating ("Patrolling", 1f, 2f);
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

	public virtual void ExitState(State stateExited){
		switch (stateExited) {

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

    public virtual void Patrolling()
    {
		agent.destination = patrolPoints [a].position;

		if (a == patrolPoints.Length - 1 && patrolDirection == false) {
						patrolDirection = true;
		} 
		else if(patrolDirection == false) {
			a++;
		}
		if(a == 0){
			patrolDirection = false;
		}
		else if(patrolDirection == true){
			a--;
		}
	

	}

    public virtual IEnumerator Alert()
    {
        agent.destination = GameObject.FindGameObjectWithTag("Player").transform.position;
        yield return new WaitForSeconds(1);
        gotHit = false;
        state = State.Patrol;
    }

    public virtual void Pursuit()
    {
		agent.destination = playerPosition.position;
	}

    public virtual IEnumerator Death()
    {
        //animação de morte
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }

    public virtual IEnumerator Attack()
    {
        yield return new WaitForSeconds(0.5f);
        attack = false;
    }
}
