using UnityEngine;
using System.Collections;

public class touchControls : MonoBehaviour {

	public Vector2 startPos; // the starting position of the touch.
	public Vector2 endPos;

	public Vector2 direction; // Vector 2 storing the direction of the motion of the touch
	public bool directionChosen; // boolean to store whether a complete touch is complete

	private float damping=100.0f; // the value of the damping to the force applied
	public GameObject thePlayer; // the gameObject on which the movement is to be done

	void Update () 
	{
		// Track a single touch in a direction
		if (Input.touchCount > 0) 
		{
			// Input.touchCount - Number of touches. Guaranteed not to change throughout the frame.
			Touch touch = Input.GetTouch(0); //GetTouch - Returns object representing status of a specific touch
			// Handle finger movements based on touch phase.
			switch(touch.phase)
			{
				// Record initial touch position.
				case TouchPhase.Began: 
				startPos = touch.position;
				directionChosen = false;
				break;
				// Determine direction by comparing the current touch position with the initial one.
				case TouchPhase.Moved:
				direction = touch.position - startPos;
				break;
				// Report that a direction has been chosen when the finger is lifted.
				case TouchPhase.Ended:
				directionChosen = true;
				break;
			}
		}
		if (directionChosen) 
		{
			gameObject.GetComponent<Rigidbody2D>().velocity=new Vector2(0,0); // to stop the motion of the object due to the previous force whenever a new force is to be added
			gameObject.GetComponent<Rigidbody2D>().AddForce(direction*damping*Time.deltaTime);
		}
	}
}
