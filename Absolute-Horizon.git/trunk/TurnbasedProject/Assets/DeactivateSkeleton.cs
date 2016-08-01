using UnityEngine;
using System.Collections;

public class DeactivateSkeleton : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine (Deactivate ());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator Deactivate(){
		bool active = gameObject.activeSelf;
		if (active) {
			yield return new WaitForSeconds (3f);
		}
	}
}
