using UnityEngine;
using System.Collections;

public class Loading : MonoBehaviour
{
    #region GameManager variables
    public GameManager manager;
    #endregion
    #region GameObject variables
    public GameObject loading;
    public GameObject carregando;
    #endregion

    // Use this for initialization
	void Start () {
        manager = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<GameManager>();
	
	}
	
	// Update is called once per frame
	void Update () {
        Load();
        if (manager.ingles)
        {
            loading.SetActive(true);
        }

        else if (manager.portugues)
        {
            carregando.SetActive(true);
        }
	
	}

    void Load()
    {
        StartCoroutine("Timer");
        if (manager.currentScene == 1)
        {
            Application.LoadLevel(3);
        }
        else if (manager.currentScene == 3)
        {
            if (manager.loading)
            {
                Application.LoadLevel(3);
                manager.loading = false;
            }
            else if (!manager.loading)
            {
                Application.LoadLevel(1);
            }
        }
        else if (manager.currentScene == 4)
        {
            Application.LoadLevel(1);
        }
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(2.0f);
    }
}
