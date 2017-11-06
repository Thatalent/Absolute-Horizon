using UnityEngine;
using System.Collections;

public class PlayMovement : MonoBehaviour {
 
	Animator amin;

	void Start () {
		amin = GetComponent<Animator>();
	}

	void FixedUpdate () {
		float input_x = Input.GetAxisRaw ("Horizontal");
		float input_y = Input.GetAxisRaw ("Vertical");

		bool isWalking = (Mathf.Abs (input_x) + Mathf.Abs (input_y)) > 0;
		bool isAttacking = Input.GetButton("Fire1");

		if (isWalking) {
			//amin.SetFloat ("x", input_x);
			//amin.SetFloat ("y", input_y);

			transform.position+= new Vector3 (input_x, input_y, 0).normalized*0.1f;
		}
		if (isAttacking) {
			amin.SetBool ("Attack", true);
		} 
		else {
			amin.SetBool("Attack",false);
		}
	}
}
