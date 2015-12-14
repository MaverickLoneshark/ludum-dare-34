using UnityEngine;
using System.Collections;

public class Collectible : MonoBehaviour {
	public System.String type = "item";
	public AudioClip audioClip = new AudioClip();
	
	// Use this for initialization
	void Awake() {
		//
		return;
	}
	
	void Start () {
		//
		return;
	}

	public void playAudio() {
		AudioSource.PlayClipAtPoint(audioClip, Camera.main.transform.position);
		
		return;
	}

	// Update is called once per frame
	void Update () {
		//
		return;
	}
}
