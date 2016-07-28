using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class dimensionSelect : MonoBehaviour {
	

	void Awake()
	{
		DontDestroyOnLoad (gameObject);

		if (FindObjectsOfType (GetType ()).Length > 1) {
			Destroy (gameObject);
		}
	}


	
}
