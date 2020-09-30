using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    #region GameObject variables
    public GameObject rotationAnchor;
    #endregion
    #region float variables
    public float rotationSpeed;
    public float movementSpeed;
    #endregion
    // Use this for initialization
	void Start () {
        rotationSpeed = 10.0f;
        movementSpeed = 8.0f;
	
	}
	
	// Update is called once per frame
	void Update () {
        Rotation();
        Movement();
	
	}

    void Rotation()
    {
        Plane playerPlane = new Plane(Vector3.up, rotationAnchor.transform.position);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float hitdist = 0.0f;
        if (playerPlane.Raycast(ray, out hitdist))
        {
            Vector3 targetPoint = ray.GetPoint(hitdist);
            Quaternion targetRotation = Quaternion.LookRotation(targetPoint - rotationAnchor.transform.position);
            rotationAnchor.transform.rotation = Quaternion.Slerp(rotationAnchor.transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }

    void Movement()
    {
        Vector3 newMovement = new Vector3(0, 0, 0);

        if (Input.GetKey(KeyCode.W))
        {
            newMovement.z++;
        }

        if (Input.GetKey(KeyCode.S))
        {
            newMovement.z--;
        }

        if (Input.GetKey(KeyCode.A))
        {
            newMovement.x--;
        }

        if (Input.GetKey(KeyCode.D))
        {
            newMovement.x++;
        }

        transform.Translate(newMovement.normalized * movementSpeed * Time.deltaTime);
    }
}
