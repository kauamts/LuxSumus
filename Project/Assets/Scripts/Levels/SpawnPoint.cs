using UnityEngine;
using System.Collections;

public class SpawnPoint : MonoBehaviour
{
    #region GameObject variables
    public GameObject playerCharacter;
    public GameObject playerDescent;
    #endregion
    #region bool variables
    public bool playerActive;
    #endregion
    #region float variables
    public float descentTime;
    #endregion
    // Use this for initialization
	void Start () {
        descentTime = 5.0f;
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.P))
        {
            //GameObject player = Instantiate(playerCharacter, transform.position, transform.rotation) as GameObject;
            //playerDescent = player;
            playerActive = true;
        }

        StartCoroutine("DescentAnimation");

        if (playerActive)
        {
            Destroy(this.gameObject.camera);
            playerDescent.transform.position = new Vector3(0, -1 * Time.deltaTime, 0);
        }
	
	}

    IEnumerator DescentAnimation()
    {
        yield return new WaitForSeconds(descentTime);
        Destroy(gameObject);
    }
}
