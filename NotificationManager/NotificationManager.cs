using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;
using UnityEngine.UI;

public class NotificationManager : MonoBehaviour {

	[SerializeField]
	GameObject button1,button2, button3, notif; // button1,2,3 are required only if the buttons need to be disabled
	[SerializeField]
	Text header, instruction; // header - The Title of the Notification, instruction - the content of the notification

	PlayerController controller; // reference to the player controller
	GameObject cam; // Reference to the camera of the game (Only if the camera's blur needs to be turned on/off)
	// Use this for initialization
	void Start () {
		controller = GameObject.Find ("Player").GetComponent<PlayerController> ();
		cam = GameObject.Find ("Camera");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Notify(string _header, string _content)
	{
		// disabling the player control buttons
		/*
		button1.SetActive (false);
		button2.SetActive (false);
		button3.SetActive (false);
		*/
		controller.StartMoving (0); // disables player movement
		// Enabling Blur
		//cam.GetComponent<Blur>().enabled = true;
		// setting the header and instruction texts
		header.text = _header;  // setting the header
		instruction.text = _content; // setting the content 
		notif.GetComponent<notificationControls>().notiON(); // notifON plays the animation which drops the notification
	}
}
