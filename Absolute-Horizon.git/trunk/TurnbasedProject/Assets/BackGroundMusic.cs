using UnityEngine;
using System.Collections;

public class BackGroundMusic : MonoBehaviour {

    AudioSource bgSound;
    public AudioClip backGMusic;
	// Use this for initialization
	void Start () {
        bgSound = GetComponent<AudioSource>();
        bgSound.Play();

    }
	
	// Update is called once per frame
	void Update () {

      
	}
}
