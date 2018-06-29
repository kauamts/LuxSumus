using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public /*static*/ bool isPlayerActive;

    private bool upWeGo;
    private bool downWeGo;
    private bool slideRight;
    private bool slideLeft;
    private int keysPressed;

	void Start ()
    {
		
	}
	
	void FixedUpdate ()
    {
		if(isPlayerActive)
        {
            upWeGo = false;
            downWeGo = false;
            slideRight = false;
            slideLeft = false;
            keysPressed = 0;

            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                upWeGo = true;
                keysPressed++;
            }

            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                downWeGo = true;
                keysPressed++;
            }

            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                slideRight = true;
                keysPressed++;
            }

            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                slideLeft = true;
                keysPressed++;
            }

            switch (keysPressed)
            {
                case 1:
                    if (upWeGo)
                        this.upWeGo = false;
                    
                    break;

                case 2:

                    break;

                case 3:

                    break;

                case 4:

                    break;
            }
        }
	}
}
