using UnityEngine;
using System.Collections;

public class SpawnController : MonoBehaviour
{
    #region GameObject variables
    public GameObject[] spawnables;
    #endregion
    #region bool variables
    public bool respawn;
    public bool finish;
    #endregion
    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Respawn();
        EndGame();
	
	}

    void Respawn()
    {
        if (respawn)
        {
            foreach (GameObject spawn in spawnables)
            {
                spawn.SetActive(true);
            }
            respawn = false;
        }
    }

    void EndGame()
    {
        //if (!spawnables[0].activeInHierarchy && !spawnables[1].activeInHierarchy && !spawnables[2].activeInHierarchy && !spawnables[3].activeInHierarchy && !spawnables[4].activeInHierarchy && !spawnables[5].activeInHierarchy && !spawnables[6].activeInHierarchy && !spawnables[7].activeInHierarchy)
        //{
            //finish = true;
        //}

        //if (finish)
        //{
            //StartCoroutine("Delay");
        //}
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(2.0f);
        Application.LoadLevel(2);
    }
}
