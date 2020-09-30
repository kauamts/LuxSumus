using UnityEngine;
using System.Collections;

public class PowerCrystal : MonoBehaviour
{
    #region float variables
    public float energy;
    public float maxEnergy;
    #endregion
    #region bool variables
    public bool main;
    #endregion
    #region Vector3 variables
    public Vector3 activeAttack = new Vector3(0.05f, 0.05f, 0.05f);
    public Vector3 inactiveAttack = new Vector3(0.025f, 0.025f, 0.025f);
    #endregion
    // Use this for initialization
	void Start () {
        energy = 100.0f;
        maxEnergy = 100.0f;
	
	}
	
	// Update is called once per frame
	void Update () {
        MainAttack();
        EnergyControl();
	
	}

    void MainAttack()
    {
        if (main)
        {
            gameObject.transform.localScale = activeAttack ;
        }
        else
        {
            gameObject.transform.localScale = inactiveAttack;
        }
    }

    void EnergyControl()
    {
        if (energy < 0)
        {
            energy = 0;
        }
        if (energy > maxEnergy)
        {
            energy = maxEnergy;
        }
    }
}
