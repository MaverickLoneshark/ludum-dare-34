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

	//these are essentially useless for all but active frame
	/*
	void OnTriggerEnter2D(Collider2D other)
	{
Debug.Log(gameObject + " trigger");
		return;
	}
	
	void OnCollisionEnter2D(Collision2D other)
	{
Debug.Log(gameObject + " collision");
		GameObject otherGameObject = other.gameObject;
		Weapon weapon = otherGameObject.GetComponent<Weapon>();

		if(LayerMask.LayerToName(otherGameObject.layer) == "Player")
		{
			while(!weapon && otherGameObject.transform.parent)
			{
				otherGameObject = otherGameObject.transform.parent.gameObject;
				weapon = otherGameObject.GetComponent<Weapon>();
			}
		}

		if(weapon)
		{
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
		}

		return;
	}
	*/
	}
