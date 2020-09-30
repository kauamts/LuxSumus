using UnityEngine;
using System.Collections;

public class HealthRegen : MonoBehaviour {
    #region Player variables
    public Player playerCharacter;
    #endregion
    #region bool variables
    public bool regen;
    #endregion
    #region float variables
    public float regenValue = 30.0f;
    #endregion

    // Use this for initialization
	void Start () {
        //playerCharacter = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<Player>().healed = true;
            other.GetComponent<Player>().health += regenValue;
            gameObject.SetActive(false);
        }
    }
}
