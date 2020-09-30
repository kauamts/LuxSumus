using UnityEngine;
using System.Collections;

[System.Serializable]
public class Player : MonoBehaviour
{
    #region GameObject variables
    public GameObject body;
    public GameObject ammo;
    public GameObject rotationAnchor;
    //public GameObject crystals;
    public GameObject mira;
    public GameObject espada;
    public GameObject espadaCharging;
    public GameObject espadaCharged;
    public GameObject chargedAmmo;
    public GameObject chargingAmmo;
    public GameObject chargingAnimation;
    //public GameObject chargedAnimation;
    public GameObject markedCheckpoint;
    #endregion
    #region ParticleEmitter variables
    public ParticleEmitter[] particles;
    #endregion
    #region PlayerMovement variables
    public PlayerMovement playerMovement;
    #endregion
    #region ParticleSystem variables
    public ParticleSystem spawnParticles;
    public ParticleSystem deathParticles;
    #endregion
    #region CheckpointManager variables
    public CheckpointManager checkpointManager;
    #endregion
    #region Color variables
    public Color[] particleColors;
    #endregion
    #region ParticleAnimator variables
    public ParticleAnimator[] particleAnimator;
    #endregion
    #region PowerCrystal variables
    public PowerCrystal[] powers = new PowerCrystal[3];
    #endregion
    #region PauseMenu variables
    public PauseMenu pauseMenu;
    #endregion
    #region Light variables
    public Light luz;
    #endregion
    #region float variables
    public float health;
    public float energy;
    public float chargeCounter;
    public float swordChargeCounter;
    #endregion
    #region int variables
    public int usablePowers;
    public int powerNumber;
    #endregion
    #region Vector3 variables
    public Vector3 healthControl;
    public Vector3 playerPosition;
    #endregion
    #region bool variables
    public bool teleported;
    public bool charge;
    public bool swordCharge;
    public bool shooting;
    public bool melee;
    public bool charging;
    public bool swordCharging;
    public bool charged;
    public bool swordCharged;
    public bool playerEnabled;
    #endregion
    #region enum variables
    public enum PlayerState
    {
        Normal,
        Charging,
        SwordCharging,
        Charged,
        SwordCharged,
        Dead
    }
    #endregion
    #region PlayerState variables
    private PlayerState _state;
    public PlayerState state
    {
        get
        {
            return _state;
        }
        set
        {
            ExitState(_state);
            _state = value;
            EnterState(_state);
        }
    }
    #endregion
    #region AudioClip variables
    public AudioClip normalShotSound;
    public AudioClip chargingShotSound;
    public AudioClip chargedShotSound;
    public AudioClip chargingSound;
    public AudioClip chargedSound;
    public AudioClip deathSound;
    #endregion
    #region SpawnController variables
    public SpawnController spawnController;
    #endregion

    public GameObject chargingSoundObject;
    public GameObject chargedSoundObject;
    public GameObject deathSoundObject;
    public GameObject spawnSoundObject;
    public GameObject healthRegen;

    public bool healed;

    public Player()
    {
        //health = 100.0f;
        //chargeCounter = 0.0f;
        //swordChargeCounter = 0.0f;
        //playerPosition = markedCheckpoint.transform.position;
    }
    void Awake()
    {
        checkpointManager = GameObject.FindGameObjectWithTag("Checkpoint Manager").GetComponent<CheckpointManager>();
        particles = chargingAnimation.GetComponentsInChildren<ParticleEmitter>();
        particles[0].emit = false;
        particles[1].emit = false;
        playerMovement.enabled = false;
        mira.renderer.enabled = false;
        StartCoroutine("PlayerSpawn");
    }

	// Use this for initialization
	void Start () {
        pauseMenu = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<PauseMenu>();
        particleAnimator = chargingAnimation.GetComponentsInChildren<ParticleAnimator>();
        spawnController = GameObject.FindGameObjectWithTag("Spawn Controller").GetComponent<SpawnController>();
        usablePowers = 0;
        powerNumber = 0;
        health = 1.0f;
        energy = 100.0f;
        chargeCounter = 0.0f;
        teleported = false;
        shooting = false;
        playerEnabled = false;
        charge = true;
        markedCheckpoint = checkpointManager.markedPoint;
        state = PlayerState.Normal;
	
	}
	
	// Update is called once per frame
	void Update () {
        if (!pauseMenu.isPaused)
        {
            SizeControl();
            LightControl();
            RangedAttack();
            MeleeAttack();
            HealthControl();
            Charge();
            //PowerSelection();
            //PowerColors();
            Charging();
            Charged();
            MarkedCheckpoint();
            //if (Input.GetKeyDown(KeyCode.L))
            //{
                //usablePowers++;
            //}

            if (health <= 0)
            {
                state = PlayerState.Dead;
            }
        }
	
	}
    void EnterState(PlayerState stateEntered)
    {
        switch (stateEntered)
        {
            case PlayerState.Normal:
                
                break;

            case PlayerState.Charging:
                charging = true;
                particles[0].emit = true;
                particles[1].emit = true;
                break;

            case PlayerState.SwordCharging:
                swordCharging = true;
                particles[0].emit = true;
                particles[1].emit = true;
                break;

            case PlayerState.Charged:
                charged = true;
                particles[0].emit = true;
                particles[1].emit = true;
                break;

            case PlayerState.SwordCharged:
                swordCharged = true;
                particles[0].emit = true;
                particles[1].emit = true;
                break;

            case PlayerState.Dead:
                spawnController.respawn = true;
                StartCoroutine("Death");
                break;
        }
    }

    void ExitState(PlayerState stateExited)
    {
        switch (stateExited)
        {

            case PlayerState.Normal:
                
                break;

            case PlayerState.Charging:
                charging = false;
                particles[0].emit = false;
                particles[1].emit = false;
                break;

            case PlayerState.SwordCharging:
                swordCharging = false;
                particles[0].emit = false;
                particles[1].emit = false;
                break;

            case PlayerState.Charged:
                charged = false;
                particles[0].emit = false;
                particles[1].emit = false;
                break;

            case PlayerState.SwordCharged:
                swordCharged = false;
                particles[0].emit = false;
                particles[1].emit = false;
                break;

            case PlayerState.Dead:

                break;
        }
    }

    IEnumerator Death()
    {
        playerMovement.enabled = false;
        deathSoundObject.SetActive(true);
        deathParticles.Play();
        yield return new WaitForSeconds(1.0f);
        deathParticles.Stop();
        yield return new WaitForSeconds(0.2f);
        deathSoundObject.SetActive(false);
        gameObject.transform.position = markedCheckpoint.transform.position;
        spawnSoundObject.SetActive(true);
        spawnParticles.Play();
        playerEnabled = false;
        yield return new WaitForSeconds(1.0f);
        spawnParticles.Stop();
        spawnSoundObject.SetActive(false);
        playerEnabled = true;
        health = 100.0f;
        playerMovement.enabled = true;
        state = PlayerState.Normal;
    }

    void Charge()
    {
        if (charge)
        {
            if (Input.GetMouseButton(0) && !Input.GetMouseButton(1))
            {
                chargeCounter = chargeCounter + 1 * Time.deltaTime;

                if (chargeCounter >= 2 && chargeCounter < 5)
                {
                    state = PlayerState.Charging;
                }

                else if (chargeCounter >= 5)
                {
                    state = PlayerState.Charged;
                }
            }

            else if (Input.GetMouseButton(1) && !Input.GetMouseButton(0))
            {
                swordChargeCounter = swordChargeCounter + 1 * Time.deltaTime;
                if (swordChargeCounter >= 2 && swordChargeCounter < 5)
                {
                    state = PlayerState.SwordCharging;
                }

                else if (swordChargeCounter >= 5)
                {
                    state = PlayerState.SwordCharged;
                }
            }

            else if (Input.GetMouseButtonUp(0) || Input.GetMouseButton(1))
            {
                chargeCounter = 0.0f;
                state = PlayerState.Normal;
            }

            else if (Input.GetMouseButtonUp(1) || Input.GetMouseButton(0))
            {
                swordChargeCounter = 0.0f;
                state = PlayerState.Normal;
            }
        }
        
    }

    void Charging()
    {
        
        if (charging)
        {
            chargingSoundObject.SetActive(true);
            particleColors = particleAnimator[0].colorAnimation;
            particleColors[0] = Color.white;
            particleColors[1] = Color.white;
            particleColors[2] = Color.white;
            particleColors[3] = Color.white;
            particleColors[4] = Color.white;
            particleAnimator[0].colorAnimation = particleColors;
            particleColors[0] = Color.white;
            particleColors[1] = Color.white;
            particleColors[2] = Color.white;
            particleColors[3] = Color.white;
            particleColors[4] = Color.white;
            particleAnimator[1].colorAnimation = particleColors;
        }
        
        if (swordCharging)
        {
            chargingSoundObject.SetActive(true);
            particleColors = particleAnimator[0].colorAnimation;
            particleColors[0] = Color.blue;
            particleColors[1] = Color.blue;
            particleColors[2] = Color.blue;
            particleColors[3] = Color.blue;
            particleColors[4] = Color.blue;
            particleAnimator[0].colorAnimation = particleColors;
            particleColors[0] = Color.blue;
            particleColors[1] = Color.blue;
            particleColors[2] = Color.blue;
            particleColors[3] = Color.blue;
            particleColors[4] = Color.blue;
            particleAnimator[1].colorAnimation = particleColors;
        }

        else if (!charging && !swordCharging)
        {
            chargingSoundObject.SetActive(false);
        }
    }

    void Charged()
    {
        if (charged)
        {
            chargedSoundObject.SetActive(true);
            //particles[0].emit = charged;
            particleColors = particleAnimator[0].colorAnimation;
            particleColors[0] = Color.cyan;
            particleColors[1] = Color.white;
            particleColors[2] = Color.cyan;
            particleColors[3] = Color.white;
            particleColors[4] = Color.cyan;
            particleAnimator[0].colorAnimation = particleColors;
            //particles[1].emit = charged;
            particleColors[0] = Color.cyan;
            particleColors[1] = Color.white;
            particleColors[2] = Color.cyan;
            particleColors[3] = Color.white;
            particleColors[4] = Color.cyan;
            particleAnimator[1].colorAnimation = particleColors;
        }

        if (swordCharged)
        {
            chargedSoundObject.SetActive(true);
            //particles[0].emit = swordCharged;
            particleColors = particleAnimator[0].colorAnimation;
            particleColors[0] = Color.blue;
            particleColors[1] = Color.white;
            particleColors[2] = Color.blue;
            particleColors[3] = Color.white;
            particleColors[4] = Color.blue;
            particleAnimator[0].colorAnimation = particleColors;
            //particles[1].emit = swordCharged;
            particleColors[0] = Color.blue;
            particleColors[1] = Color.white;
            particleColors[2] = Color.blue;
            particleColors[3] = Color.white;
            particleColors[4] = Color.blue;
            particleAnimator[1].colorAnimation = particleColors;
        }

        else if (!charged && !swordCharged)
        {
            chargedSoundObject.SetActive(false);
        }
    }

    void SizeControl()
    {
        healthControl = new Vector3(health / 100, health / 100, health / 100);
        body.transform.localScale = healthControl;
    }

    void LightControl()
    {
        luz.light.range = health / 20;
    }

    void RangedAttack()
    {
        if (Input.GetMouseButtonUp(0) && !Input.GetMouseButton(1))
        {
            if (!shooting)
            {
                shooting = true;
                if (state == PlayerState.Normal)
                {
                    //audio.clip = normalShotSound;
                    //audio.Play();
                    GameObject ammoTemp =  Instantiate(ammo, body.transform.position, body.transform.rotation) as GameObject;
                    ammoTemp.GetComponent<Ammo>().damage = 1;
                }

                else if (state == PlayerState.Charging)
                {
                    //audio.clip = chargingShotSound;
                    //audio.Play();
                    GameObject chargingAmmoTemp = Instantiate(chargingAmmo, body.transform.position, body.transform.rotation) as GameObject;
                    chargingAmmoTemp.GetComponent<Ammo>().damage = 2;
                }

                else if (state == PlayerState.Charged)
                {
                    //audio.clip = chargedShotSound;
                    //audio.Play();
                    GameObject chargedAmmoTemp =  Instantiate(chargedAmmo, body.transform.position, body.transform.rotation) as GameObject;
                    chargedAmmoTemp.GetComponent<Ammo>().damage = 3;
                }
                StartCoroutine("Shooting");
            }
            
        }
    }

    void MeleeAttack()
    {
        if (Input.GetMouseButtonUp(1) && !Input.GetMouseButton(0))
        {
            if (!melee)
            {
                melee = true;
                if (state == PlayerState.Normal)
                {
                    GameObject espadaTemp = Instantiate(espada, body.transform.position, body.transform.rotation) as GameObject;
                    espadaTemp.transform.Rotate(0, -60.0f, 0);
                    espadaTemp.transform.parent = gameObject.transform;
                    espadaTemp.GetComponent<Espada>().damage = 1;
                }

                else if (state == PlayerState.SwordCharging)
                {
                    GameObject espadaChargingTemp = Instantiate(espadaCharging, body.transform.position, body.transform.rotation) as GameObject;
                    espadaChargingTemp.transform.Rotate(0, -60.0f, 0);
                    espadaChargingTemp.transform.parent = gameObject.transform;
                    espadaChargingTemp.GetComponent<Espada>().damage = 2;
                }

                else if (state == PlayerState.SwordCharged)
                {
                    GameObject espadaChargedTemp = Instantiate(espadaCharged, body.transform.position, body.transform.rotation) as GameObject;
                    espadaChargedTemp.transform.Rotate(0, -60.0f, 0);
                    espadaChargedTemp.transform.parent = gameObject.transform;
                    espadaChargedTemp.GetComponent<Espada>().damage = 3;
                }
                StartCoroutine("Melee");
            }
        }
    }

    void PowerSelection()
    {
        if (usablePowers == 0)
        {
            powers[1].gameObject.SetActive(false);
            powers[2].gameObject.SetActive(false);
            if (powerNumber > 0)
            {
                powerNumber = 0;
            }
            if (powerNumber < 0)
            {
                powerNumber = 0;
            }
            if (powerNumber == 0)
            {
                powers[0].main = true;
                powers[1].main = false;
                powers[2].main = false;

            }
        }
        if (usablePowers == 1)
        {
            powers[1].gameObject.SetActive(true);
            powers[2].gameObject.SetActive(false);
            if (powerNumber > 1)
            {
                powerNumber = 0;
            }
            if (powerNumber < 0)
            {
                powerNumber = 1;
            }
            if (powerNumber == 0)
            {
                powers[0].main = true;
                powers[1].main = false;
                powers[2].main = false;

            }
            if (powerNumber == 1)
            {
                powers[0].main = false;
                powers[1].main = true;
                powers[2].main = false;
            }
        }
        if (usablePowers == 2)
        {
            powers[1].gameObject.SetActive(true);
            powers[2].gameObject.SetActive(true);
            if (powerNumber > 2)
            {
                powerNumber = 0;
            }
            if (powerNumber < 0)
            {
                powerNumber = 2;
            }
            if (powerNumber == 0)
            {
                powers[0].main = true;
                powers[1].main = false;
                powers[2].main = false;

            }
            if (powerNumber == 1)
            {
                powers[0].main = false;
                powers[1].main = true;
                powers[2].main = false;
            }
            if (powerNumber == 2)
            {
                powers[0].main = false;
                powers[1].main = false;
                powers[2].main = true;
            }
        }
        
        if (Input.GetAxisRaw("Mouse ScrollWheel") > 0)
        {
            powerNumber++;
        }
        if (Input.GetAxisRaw("Mouse ScrollWheel") < 0)
        {
            powerNumber--;
        }
    }
    IEnumerator Melee()
    {
        yield return new WaitForSeconds(0.3f);
        melee = false;
    }

    IEnumerator Shooting()
    {
        yield return new WaitForSeconds(0.3f);
        shooting = false;
    }

    void PowerColors()
    {
        if (powers[0].main)
        {
            mira.renderer.material.color = powers[0].gameObject.renderer.material.color;
            body.renderer.material.color = powers[0].gameObject.renderer.material.color;
            ammo.renderer.material.color = powers[0].gameObject.renderer.material.color;
            luz.color = powers[0].gameObject.renderer.material.color;
        }
        if (powers[1].main)
        {
            mira.renderer.material.color = powers[1].gameObject.renderer.material.color;
            body.renderer.material.color = powers[1].gameObject.renderer.material.color;
            ammo.renderer.material.color = powers[1].gameObject.renderer.material.color;
            luz.color = powers[1].gameObject.renderer.material.color;
        }
        if (powers[2].main)
        {
            mira.renderer.material.color = powers[2].gameObject.renderer.material.color;
            body.renderer.material.color = powers[2].gameObject.renderer.material.color;
            ammo.renderer.material.color = powers[2].gameObject.renderer.material.color;
            luz.color = powers[2].gameObject.renderer.material.color;
        }
    }

    void MarkedCheckpoint()
    {
        markedCheckpoint = checkpointManager.markedPoint;
    }

    IEnumerator PlayerSpawn()
    {
        if (!playerEnabled)
        {
            spawnSoundObject.SetActive(true);
            spawnParticles.Play();
            yield return new WaitForSeconds(1.0f);
            spawnParticles.Stop();
            spawnSoundObject.SetActive(false);
            health = 100.0f;
            playerEnabled = true;
            mira.renderer.enabled = true;
            playerMovement.enabled = true;
        }
    }

    void HealthControl()
    {
        if (health > 100.0f)
        {
            health = 100.0f;
        }

        if (health < 0.0f)
        {
            health = 0.0f;
        }

        if (!playerEnabled)
        {
            health += 2.0f;
        }

        if (healed)
        {
            healthRegen.SetActive(true);
            StartCoroutine("Regen");
        }
    }

    IEnumerator Regen()
    {
        yield return new WaitForSeconds(0.5f);
        healed = false;
        healthRegen.SetActive(false);
    }
}
