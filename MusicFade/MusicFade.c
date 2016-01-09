using UnityEngine;
using System.Collections;

public class MusicFade : MonoBehaviour {

	private float fadingTime=10.0f; // time after which the audio will stop

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		FadeOut ();
	}

	void FadeOut()
	{
		if (gameObject.GetComponent<AudioSource> ().volume > 0) 
		{
			gameObject.GetComponent<AudioSource> ().volume -= Time.deltaTime/fadingTime;
		} 
		else 
		{
			gameObject.GetComponent<AudioSource> ().volume=0;
			gameObject.GetComponent<AudioSource>().Stop();
		}
	}
}
