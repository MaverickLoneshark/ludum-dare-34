using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {
	public System.String type = "weapon";
	public AudioClip audioClip = new AudioClip();
	
	public void playAudio()
	{
		AudioSource.PlayClipAtPoint(audioClip, Camera.main.transform.position);
		
		return;
	}
	
	// Use this for initialization
	void Start () {
		//
	}
	
	// Update is called once per frame
	void Update () {
		//
	}
}
