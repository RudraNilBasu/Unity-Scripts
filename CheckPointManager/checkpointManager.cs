using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class checkpointManager : MonoBehaviour {

	int currentCheckpoint; // the current checkpoint we have crossed
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
		currentCheckpoint = 0;
		thePlayer = GameObject.Find ("Player");
		playerPosition = thePlayer.transform.position;
	}




	// Update is called once per frame
	public void save (int _checkPointIndex) {
		currentCheckpoint = _checkPointIndex;
		playerPosition = thePlayer.transform.position;
		/*
		isB1 = breaker1.activeInHierarchy;
		isP1 = pieces.activeInHierarchy;
		*/
		int i;
		//Debug.Log (barriers.Length);
		for (i = 0; i < barriers.Length; i++) {
			//isB [i] = barriers [i].activeInHierarchy;
			//Debug.Log("i="+i);
			//Debug.Log(barriers[i].GetComponent<BoxCollider>().enabled);
			isB[i]=barriers[i].GetComponent<BoxCollider>().enabled;
		}
		//Debug.Log ("HURRRAAAYY"+isP[0]);
		//Debug.Log (piecesObjs.Length+","+isP.Length+","+piecesPos.Length);
		for (i = 0; i < piecesObjs.Length; i++) {
			//Debug.Log("i="+i+"()"+piecesObjs [i].activeInHierarchy);
			isP [i] = piecesObjs [i].activeInHierarchy;
			piecesPos [i] = piecesObjs [i].transform.localPosition;
		}
	}

	public void loadLastCheckPoint()
	{
		if (currentCheckpoint == 0) {
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		} else {
			thePlayer.transform.position = playerPosition;
			/*
			breaker1.GetComponent<BoxCollider> ().enabled = isB1;
			breaker1.GetComponent<MeshRenderer> ().enabled = isB1;
			//breaker1.SetActive (isB1);
			pieces.SetActive (isP1);
			*/
			int i;
			for (i = 0; i < barriers.Length; i++) {
				//isB [i] = barriers [i].activeInHierarchy;
				barriers[i].GetComponent<BoxCollider>().enabled = isB[i];
				barriers[i].GetComponent<MeshRenderer> ().enabled = isB[i];

				if (isB [i]) {
					//Debug.Log (barriers [i].transform.GetChild (0).gameObject.name);
					barriers [i].transform.GetChild (0).gameObject.SetActive (false);
				} else {
					barriers [i].transform.GetChild (0).gameObject.SetActive (true);
				}
			}
			for (i = 0; i < piecesObjs.Length; i++) {
				//piecesObjs [i].SetActive(isP[i]);
				piecesObjs [i].transform.localPosition = piecesPos [i];
			}
		}
	}
}
