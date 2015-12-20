using UnityEngine;
using System.Collections;

public class mouseDrag : MonoBehaviour {

	private float distance1=2;
	private float distance; // minimum distance in which the player should be at to enable dragging

	[HideInInspector]
	public GameObject thePlayer;
	
	[HideInInspector]
	public Rigidbody rb;

	private bool isDragged;
	private bool isMouse; // to check if the mouse cursor is over the gameobject or not to check when to show the hand

	void Awake()
	{
		thePlayer = GameObject.Find ("Player");
		if (thePlayer == null)
			Debug.Log ("Player Not Found");
		rb = gameObject.GetComponent<Rigidbody> ();
	}

	void OnMouseDrag()
	{
		if (distance < 5) {
			isDragged = true;
			thePlayer.GetComponent<Rigidbody> ().freezeRotation = true;

			Vector3 mousePosition = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, distance1);
			Vector3 objPosition = Camera.main.ScreenToWorldPoint (mousePosition);

			transform.position = objPosition; // storing the position on the game Object's new position

		}
	}

	void OnMouseUp()
	{
		isDragged = false;  // When the mouse is released
	}

	void OnMouseEnter()
	{
		isMouse = true;
	}
	void OnMouseExit()
	{
		isMouse = false;
	}
	void Update()
	{
		// Calculating the player position at every frame
		float playerX = thePlayer.transform.position.x;
		float playerY = thePlayer.transform.position.y;
		float playerZ = thePlayer.transform.position.z;
		// Calculating the gameObject's position at every frame
		float objX = transform.position.x;
		float objY = transform.position.y;
		float objZ = transform.position.z;
		// Calculating the distance
		distance = Mathf.Sqrt (Mathf.Pow((playerX-objX),2)+Mathf.Pow((playerY-objY),2)+Mathf.Pow((playerZ-objZ),2));

		rb.freezeRotation = isDragged;
		/*
		// Fixing the jumping of the player when the box moves under the player
		if (isDragged) {
			gameObject.GetComponent<BoxCollider> ().enabled = false;
		} else if (!isDragged) {
			gameObject.GetComponent<BoxCollider>().enabled=true;
		}
		*/
		// The Show of Hand will be done on the player script by raycasting
	}
}
