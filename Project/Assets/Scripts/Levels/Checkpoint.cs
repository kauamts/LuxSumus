using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour
{
    #region CheckpointManager variables
    public CheckpointManager checkpointManager;
    #endregion
    #region int variables
    public int check;
    #endregion
    #region bool variables
    public bool activePoint;
    public bool checkpointNotification;
    #endregion
    #region Player variables
    public Player playerCharacter;
    #endregion
    #region Rect variables
    public Rect notification;
    #endregion
    #region GUISkin variables
    public GUISkin guiSkin;
    #endregion

    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        playerCharacter = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        ActivePoint();
        RectPosition();
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!activePoint)
            {
                playerCharacter.health = 100;
                checkpointNotification = true;
            }
            checkpointManager.pointNumber = check;
        }
    }

    void ActivePoint()
    {
        if (activePoint)
        {
            //animação de ativação
        }
        if (!activePoint)
        {
            //animação desativado
        }
    }

    public void RectPosition()
    {
        notification = new Rect(Screen.width / 2 - Screen.width/8, Screen.height / 2, Screen.width / 4, Screen.height / 8);
    }

    public IEnumerator Notification()
    {
        yield return new WaitForSeconds(2.0f);
        checkpointNotification = false;
    }

    void OnGUI()
    {
        GUI.skin = guiSkin;
        if (activePoint && checkpointNotification)
        {
            //GUI.Box(notification, "Checkpoint!");
            //StartCoroutine("Notification");
        }
    }
}
