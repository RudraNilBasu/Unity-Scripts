using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class checkpointManager : MonoBehaviour {

	//int currentCheckpoint; // the current checkpoint we have crossed
	Vector3 playerPosition; // to store the player position
	GameObject thePlayer; // reference to the player

	[SerializeField]
	GameObject[] barriers; // all the solid barriers in the scene
	[SerializeField]
	GameObject[] piecesObjs; // all the broken pieces in the scene
	[SerializeField]
	Vector3[] piecesPos; // to store the position of the broken pieces on save


	[SerializeField]
	bool[] isB; // to store whether the solid barrier is visible or not
	[SerializeField]
	bool[] isP; // to store if the broken pieces is active in the hierarchy



	void Start () {
		//currentCheckpoint = 0;
		thePlayer = GameObject.Find ("Player");
		playerPosition = thePlayer.transform.position;


		int i;
		for (i = 0; i < barriers.Length; i++) {
			isB[i]=barriers[i].GetComponent<BoxCollider>().enabled; // checking whether ith barrier is visible or not
		}
		for (i = 0; i < piecesObjs.Length; i++) {
			isP [i] = piecesObjs [i].activeInHierarchy; // checking if ith broken piece is active in the scene or not
			piecesPos [i] = piecesObjs [i].transform.localPosition; // storing the position of the broken pieces
		}
	}




	public void save () {
		playerPosition = thePlayer.transform.position;

		int i;
		for (i = 0; i < barriers.Length; i++) {
			isB[i]=barriers[i].GetComponent<BoxCollider>().enabled; // checking whether ith barrier is visible or not
		}
		for (i = 0; i < piecesObjs.Length; i++) {
			isP [i] = piecesObjs [i].activeInHierarchy; // checking if ith broken piece is active in the scene or not
			piecesPos [i] = piecesObjs [i].transform.localPosition; // storing the position of the broken pieces
		}
	}

	public void loadLastCheckPoint()
	{
		
		thePlayer.transform.position = playerPosition; // restoring the player position to the position when player touched the checkpoint
		int i;
		for (i = 0; i < barriers.Length; i++) {
			// collider and mesh is enabled/disabled as per the values when it crossed the checkpoint
			barriers[i].GetComponent<BoxCollider>().enabled = isB[i];
			barriers[i].GetComponent<MeshRenderer> ().enabled = isB[i];

			if (isB [i]) {
				// if the ith barrier is visible, then deactivate it's broken pieces
				barriers [i].transform.GetChild (0).gameObject.SetActive (false);
			} else {
				barriers [i].transform.GetChild (0).gameObject.SetActive (true);
			}
		}
		for (i = 0; i < piecesObjs.Length; i++) {
			// set the position of the broken pieces to the position when the player crossed the checkpoint
			piecesObjs [i].transform.localPosition = piecesPos [i];
		}
	}
}
