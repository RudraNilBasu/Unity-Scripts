#pragma strict

function Awake () 
{
	DontDestroyOnLoad(transform.gameObject);
	if( FindObjectsOfType(GetType()).Length > 1 )  // checking if the Same GameObject is already present in the current scene or not
	{
		Destroy(gameObject); // Destroy the GameObject if the same GameObject is already present in the Scene
	}
}
