using UnityEngine;
using System.Collections;

public class Gameplay : MonoBehaviour {
    public Player player;
    public GameObject[] checkpoints;

    void Awake()
    {
        //GameObject playerCharacter = Instantiate(player, Vector3.right, Quaternion.identity) as GameObject;
        
    }

	// Use this for initialization
	void Start () {
        if (PlayerPrefs.GetInt("NewGame") == 0)
        {
            //GameObject playerCharacter = 
                Instantiate(player, new Vector3(2, 1.5f, -1), Quaternion.identity);
            //as GameObject;
        }

        else if (PlayerPrefs.GetInt("NewGame") == 1)
        {
            //GameObject playerCharacter = 
                Instantiate(player, checkpoints[1].transform.position, Quaternion.identity);
            //as GameObject;
        }
        
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
