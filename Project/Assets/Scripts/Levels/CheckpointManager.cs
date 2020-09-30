using UnityEngine;
using System.Collections;

public class CheckpointManager : MonoBehaviour
{
    #region int variables
    public int pointNumber;
    #endregion
    #region GameObject variables
    public GameObject[] points;
    public GameObject markedPoint;
    #endregion
    #region enum variables
    public enum Checkpoints
    {
        Start,
        Point1,
        Point2,
        Point3,
        Point4,
        Point5,
        End
    }
    #endregion
    #region Checkpoints variables
    private Checkpoints _checkpoint;

    public Checkpoints checkpoint
    {
        get
        {
            return _checkpoint;
        }

        set
        {
            ExitCheckpoint(_checkpoint);
            _checkpoint = value;
            EnterCheckpoint(_checkpoint);
        }
    }
    #endregion
    
    // Use this for initialization
	void Start () {
        pointNumber = 0;
        
	
	}
	
	// Update is called once per frame
	void Update () {
        CheckpointNumber();
	
	}

    void EnterCheckpoint(Checkpoints checkpointEntered)
    {
        switch (checkpointEntered)
        {
            case Checkpoints.Start:
                markedPoint = points[0];
                PlayerPrefs.SetInt("NewGame", 0);
                break;

            case Checkpoints.Point1:
                markedPoint = points[1];
                PlayerPrefs.SetInt("NewGame", 1);
                break;

            case Checkpoints.Point2:
                markedPoint = points[2];
                PlayerPrefs.SetInt("NewGame", 2);
                break;

            case Checkpoints.Point3:
                markedPoint = points[3];
                PlayerPrefs.SetInt("NewGame", 3);
                break;

            case Checkpoints.Point4:
                markedPoint = points[4];
                PlayerPrefs.SetInt("NewGame", 4);
                break;

            case Checkpoints.Point5:
                markedPoint = points[5];
                PlayerPrefs.SetInt("NewGame", 5);
                break;

            case Checkpoints.End:
                markedPoint = points[6];
                PlayerPrefs.SetInt("NewGame", 6);
                break;
        }
    }

    void ExitCheckpoint(Checkpoints checkpointExited)
    {
        switch (checkpointExited)
        {
            case Checkpoints.Start:

                break;

            case Checkpoints.Point1:

                break;

            case Checkpoints.Point2:

                break;

            case Checkpoints.Point3:

                break;

            case Checkpoints.Point4:

                break;

            case Checkpoints.Point5:

                break;

            case Checkpoints.End:

                break;
        }
    }

    void CheckpointNumber()
    {
        if (pointNumber == 0)
        {
            checkpoint = Checkpoints.Start;
            points[0].GetComponent<Checkpoint>().activePoint = true;
            points[1].GetComponent<Checkpoint>().activePoint = false;
            points[2].GetComponent<Checkpoint>().activePoint = false;
            points[3].GetComponent<Checkpoint>().activePoint = false;
            points[4].GetComponent<Checkpoint>().activePoint = false;
            points[5].GetComponent<Checkpoint>().activePoint = false;
            points[6].GetComponent<Checkpoint>().activePoint = false;
        }
        else if (pointNumber == 1)
        {
            checkpoint = Checkpoints.Point1;
            points[0].GetComponent<Checkpoint>().activePoint = false;
            points[1].GetComponent<Checkpoint>().activePoint = true;
            points[2].GetComponent<Checkpoint>().activePoint = false;
            points[3].GetComponent<Checkpoint>().activePoint = false;
            points[4].GetComponent<Checkpoint>().activePoint = false;
            points[5].GetComponent<Checkpoint>().activePoint = false;
            points[6].GetComponent<Checkpoint>().activePoint = false;

        }
        else if (pointNumber == 2)
        {
            checkpoint = Checkpoints.Point2;
            points[0].GetComponent<Checkpoint>().activePoint = false;
            points[1].GetComponent<Checkpoint>().activePoint = false;
            points[2].GetComponent<Checkpoint>().activePoint = true;
            points[3].GetComponent<Checkpoint>().activePoint = false;
            points[4].GetComponent<Checkpoint>().activePoint = false;
            points[5].GetComponent<Checkpoint>().activePoint = false;
            points[6].GetComponent<Checkpoint>().activePoint = false;
        }
        else if (pointNumber == 3)
        {
            checkpoint = Checkpoints.Point3;
            points[0].GetComponent<Checkpoint>().activePoint = false;
            points[1].GetComponent<Checkpoint>().activePoint = false;
            points[2].GetComponent<Checkpoint>().activePoint = false;
            points[3].GetComponent<Checkpoint>().activePoint = true;
            points[4].GetComponent<Checkpoint>().activePoint = false;
            points[5].GetComponent<Checkpoint>().activePoint = false;
            points[6].GetComponent<Checkpoint>().activePoint = false;
        }
        else if (pointNumber == 4)
        {
            checkpoint = Checkpoints.Point4;
            points[0].GetComponent<Checkpoint>().activePoint = false;
            points[1].GetComponent<Checkpoint>().activePoint = false;
            points[2].GetComponent<Checkpoint>().activePoint = false;
            points[3].GetComponent<Checkpoint>().activePoint = false;
            points[4].GetComponent<Checkpoint>().activePoint = true;
            points[5].GetComponent<Checkpoint>().activePoint = false;
            points[6].GetComponent<Checkpoint>().activePoint = false;
        }
        else if (pointNumber == 5)
        {
            checkpoint = Checkpoints.Point5;
            points[0].GetComponent<Checkpoint>().activePoint = false;
            points[1].GetComponent<Checkpoint>().activePoint = false;
            points[2].GetComponent<Checkpoint>().activePoint = false;
            points[3].GetComponent<Checkpoint>().activePoint = false;
            points[4].GetComponent<Checkpoint>().activePoint = false;
            points[5].GetComponent<Checkpoint>().activePoint = true;
            points[6].GetComponent<Checkpoint>().activePoint = false;
        }
        else if (pointNumber == 6)
        {
            checkpoint = Checkpoints.End;
            points[0].GetComponent<Checkpoint>().activePoint = false;
            points[1].GetComponent<Checkpoint>().activePoint = false;
            points[2].GetComponent<Checkpoint>().activePoint = false;
            points[3].GetComponent<Checkpoint>().activePoint = false;
            points[4].GetComponent<Checkpoint>().activePoint = false;
            points[5].GetComponent<Checkpoint>().activePoint = false;
            points[6].GetComponent<Checkpoint>().activePoint = true;
        }
    }
}
