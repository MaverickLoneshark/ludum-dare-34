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
	
	void OnTriggerEnter2D(Collider2D other)
	{
		GameObject otherGameObject = other.gameObject;
		EnemyController enemyController = otherGameObject.GetComponent<EnemyController>();
		
		if (LayerMask.LayerToName(otherGameObject.layer) == "Enemy")
		{
			while(!enemyController && otherGameObject.transform.parent)
			{
				otherGameObject = otherGameObject.transform.parent.gameObject;
				enemyController = otherGameObject.GetComponent<EnemyController>();
			}
		}
		
		if(enemyController)
		{
			switch(enemyController.type)
			{
				case "rawrbert":
					enemyController.playAudio();
					DestroyObject(otherGameObject);
				break;

				default:
					//
				break;
			}
		}

		return;
	}
}
