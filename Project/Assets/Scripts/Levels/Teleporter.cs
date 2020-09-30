using UnityEngine;
using System.Collections;

public class Teleporter : MonoBehaviour
{
    #region GameObject variables
    public GameObject exit;
    #endregion
    #region Player variables
    public Player player;
    #endregion

    // Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !player.teleported)
        {
            player.teleported = true;
            player.transform.position = exit.transform.position;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            player.teleported = false;
        }
    }
}
