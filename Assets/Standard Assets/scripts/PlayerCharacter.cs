using UnityEngine;
using System.Collections;

public class PlayerCharacter : MonoBehaviour {
	public float speed = 10.0F;
	public float gravity = -10.0F;
	public float jumpGain = 100.0F;
	public float maxJump = 800.0F;
	public float pushPower = 2.0F;
	public new Rigidbody2D rigidbody2D;
	public AudioSource audioSource;

	[SerializeField] private LayerMask groundLayer; // A mask determining what is ground to the character
	[SerializeField] private float maxSpeed = 30.0F;

	[SerializeField] private bool hasSword = false;
	[SerializeField] private bool hasGun = false;
	public bool hasSack = false;
	public bool hasBoots = false;
	public bool hasCookie = false;

	private bool grounded;
	private bool crouching;
	private bool facingRight = true;  // For determining which way the player is currently facing.
	private float fallspeed;
	private Vector3 motion;
	private Transform groundCheck;  // A position marking where to check if the player is grounded.
	private Transform ceilingCheck; // A position marking where to check for ceilings.
	const float checkRadius = 0.5f; // Radius of the overlap circle to determine if grounded
	private Animator animator;
	private PlayerController playerController;
	
	public void attack() {
		if((!crouching) && hasSword) {
			animator.SetTrigger("triggerAttack");
			audioSource.Play();
		}
		
		return;
	}

	public void fall() {
		if(hasSack)
		{
			fallspeed = gravity;
		}
		else
		{
			fallspeed = gravity * 1.5F;
		}

		grounded = false;
		
		return;
	}

	public void stopFall() {
		fallspeed = 0.0F;
		
		return;
	}

	public float getFallSpeed() {
		return fallspeed;
	}

	public bool isGrounded() {
		return grounded;
	}

	public void setCrouching(bool input) {
		crouching = input;
		
		return;
	}

	public void setMotion(Vector3 input)
	{
		motion = input;
		
		return;
	}
	
	private void flipSprite()
	{
		// Switch the way the player is labelled as facing.
		facingRight = !facingRight;
		
		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
		
		return;
	}
	
	// Use this for initialization
	void Start () {
		playerController = GetComponent<PlayerController>();
		rigidbody2D = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
		audioSource = GetComponent<AudioSource>();
		motion = new Vector3();
		groundCheck = transform.Find("GroundCheck");
		ceilingCheck = transform.Find("CeilingCheck");

		return;
	}
	
	// Update is called once per frame
	void Update () {
		//
		return;
	}

	void FixedUpdate()
	{
		grounded = false;
		
		if(!crouching)
		{
			rigidbody2D.velocity = motion;
		}
		
		// If the input is moving the player right and the player is facing left...
		if((rigidbody2D.velocity.x > 0) && !facingRight)
		{
			flipSprite();
		}
		// Otherwise if the input is moving the player left and the player is facing right...
		else if((rigidbody2D.velocity.x < 0) && facingRight)
		{
			flipSprite();
		}
		
		// The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
		// This can be done using layers instead but Sample Assets will not overwrite your project settings.
		Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, checkRadius, groundLayer);
		for(int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject != gameObject)
			{
				grounded = true;
			}
		}

		if(grounded)
		{
			animator.SetBool("jumpState", false);
			animator.SetBool("parachuteState", false);
			animator.SetBool("walkState", (rigidbody2D.velocity.x != 0) && (!crouching));
			animator.SetBool("crouchState", crouching);
		}
		else if(!animator.GetBool("jumpState") && !animator.GetBool("parachuteState")) {
			animator.SetBool("crouchState", false);
			animator.SetBool("walkState", false);

			if(hasSack)
			{
				animator.SetBool("parachuteState", true);
			}
			else
			{
				animator.SetBool("jumpState", true);
			}
		}

		if(transform.position.y < -100) {
			Camera.main.transform.FindChild("Canvas").gameObject.SetActive(true);
			Camera.main.GetComponent<GameController>().gameState = "gameover";
		}
		
		return;
	}

	void OnCollisionEnter2D(Collision2D other) {
		GameObject otherGameObject = other.gameObject;
		EnemyController enemyController = otherGameObject.GetComponent<EnemyController>();
		
		if (LayerMask.LayerToName(otherGameObject.layer) == "Enemy")
		{
			while (!enemyController && otherGameObject.transform.parent)
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
					Camera.main.GetComponent<UnityStandardAssets._2D.Camera2DFollow>().target = otherGameObject.transform;
					DestroyObject(gameObject);
					Camera.main.transform.FindChild("Canvas").gameObject.SetActive(true);
					Camera.main.GetComponent<GameController>().gameState = "gameover";
				break;
				
				default:
					//
				break;
			}
		}
		
		return;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		GameObject otherGameObject = other.gameObject;
		Collectible collectible = otherGameObject.GetComponent<Collectible>();
		
		if (collectible)
		{
			switch (collectible.type)
			{
				case "sword":
					hasSword = true;
					break;

				case "cookie":
					hasCookie = true;
					break;

				case "sack":
					hasSack = true;
					break;

				case "boots":
					hasBoots = true;
					break;

				case "gun":
					hasGun = true;
					break;

				default:
					//
					break;
			}

			collectible.playAudio();
			Destroy(other.gameObject);
		}

		return;
	}
}
