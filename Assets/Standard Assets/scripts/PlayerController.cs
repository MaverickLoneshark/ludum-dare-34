using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerCharacter))]
public class PlayerController : MonoBehaviour {
	private PlayerCharacter playerCharacter;
	private Vector3 motion;
	private float jumpForce;

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
			jumpForce = 0;
			playerCharacter.setCrouching(Input.GetAxis("Vertical") < 0);
		}
		else
		{
			playerCharacter.fall();
		}
		
		if(Input.GetAxis("Vertical") > 0)
		{
			if(jumpForce < playerCharacter.maxJump)
			{
				jumpForce += playerCharacter.jumpGain;
				
				if(!playerCharacter.hasBoots)
				{
					jumpForce += ((int)playerCharacter.jumpGain >> 1);
				}
				
				playerCharacter.rigidbody2D.AddForce(new Vector2(0, playerCharacter.maxJump - jumpForce));
			}
		}
		else
		{
			jumpForce = playerCharacter.maxJump;
		}
		
		if(Input.GetButtonDown("Fire1"))
		{
			playerCharacter.attack();
		}
		
		motion.y = playerCharacter.getFallSpeed();
		motion.x = Input.GetAxis("Horizontal") * playerCharacter.speed;
		playerCharacter.setMotion(motion);
		
		return;
	}
}
