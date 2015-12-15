using UnityEngine;
using System.Collections;

public class Collectible : MonoBehaviour {
	public System.String type = "item";
	public AudioClip audioClip = new AudioClip();
	
	public void playAudio()
	{
		AudioSource.PlayClipAtPoint(audioClip, Camera.main.transform.position);

		return;
	}
	
	// Use this for initialization
	void Awake() {
		//
		return;
	}
	
	void Start () {
		//
		return;
	}
	
	// Update is called once per frame
	void Update () {
		//
		return;
	}
}
