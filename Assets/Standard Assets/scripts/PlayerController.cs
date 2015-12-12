using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerCharacter))]
public class PlayerController : MonoBehaviour {
	private PlayerCharacter playerCharacter;
	private Vector3 motion;

	// Use these for initialization
	void Awake()
	{
		//
		return;
	}

	void Start () {
		playerCharacter = GetComponent<PlayerCharacter>();
		motion = new Vector3();
		
		return;
	}
	
	// Update is called once per frame
	void Update () {
		if(playerCharacter.isGrounded())
		{
			playerCharacter.stopFall();
		}
		else
		{
			playerCharacter.fall();
		}
		
		motion.y = playerCharacter.gravity + Input.GetAxis("Vertical") * playerCharacter.speed;
		motion.x = Input.GetAxis("Horizontal") * playerCharacter.speed;
		playerCharacter.setMotion(motion);
		
		return;
	}
}
