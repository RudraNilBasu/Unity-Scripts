using UnityEngine;
using System.Collections;

public class Fading : MonoBehaviour {

	public Texture2D fadeOutTexture; // the image that will overlay the screen
	public float fadeSpeed = 0.8f; // the speed with which the texture will be rendered on the screen

	private int drawDepth = -1000; // drawing order. low value meaning that will be drawn last. So it will render on top
	private float alpha=1.0f;
	private int fadeDirection = -1; // -1 = fade in. 1 = fade out



	void OnGUI()
	{
		// fade in or out using fadeDirection
		alpha += fadeDirection * fadeSpeed * Time.deltaTime;
		// clamp the value between 0 and 1
		alpha = Mathf.Clamp01 (alpha);

		// set the color of the GUI
		GUI.color = new Color (GUI.color.r, GUI.color.g,GUI.color.b, alpha);
		GUI.depth = drawDepth;  // making sure black texture renders on top
		GUI.DrawTexture (new Rect(0,0,Screen.width, Screen.height), fadeOutTexture);
	}
	public float BeginFade(int direction)
	{
		return (fadeSpeed);
	}
	void OnLevelWasLoaded()
	{
		BeginFade (-1); // alpha = -1. We will fade in
	}
}
