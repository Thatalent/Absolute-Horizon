using UnityEngine;
using System.Collections;

public class AttackAnime : MonoBehaviour {

	protected Animator anime;
	// Use this for initialization
	void Start () {
		anime = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	 if (Input.GetButton ("Z")) {
			anime.SetBool ("attack", true);
		}
		else {
			anime.SetBool ("attack", false);
		}

	}
}
