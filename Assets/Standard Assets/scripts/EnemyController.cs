using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {
	public System.String type = "enemy";
	public AudioClip audioClip = new AudioClip();

	public void playAudio()
	{
		AudioSource.PlayClipAtPoint(audioClip, Camera.main.transform.position);

		return;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		Weapon weapon = other.GetComponent<Weapon>();

		switch(weapon.type)
		{
			case "sword":
				playAudio();
				DestroyObject(gameObject);
			break;
			
			default:
				//
			break;
		}
		
		return;
	}
}
