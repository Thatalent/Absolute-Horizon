using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour {

	public float horizontalScrollSpeed = 0.0F;
	public float verticalScrollSpeed = 0.0F;
	float horizontalOffset;
	float verticalOffset;
	Renderer rend;

	void Start() 
	{
		rend = GetComponent<Renderer>();
	}

	void FixedUpdate() 
	{
		horizontalOffset = Time.time * horizontalScrollSpeed;
		verticalOffset = Time.time * verticalScrollSpeed;
		rend.material.SetTextureOffset("_MainTex", new Vector2(horizontalOffset, verticalOffset));
	}
}
