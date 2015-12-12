using UnityEngine;
using System.Collections;

public class PlayerCharacter : MonoBehaviour {
	public float speed = 10.0F;
	public float gravity = -10.0F;
	public float pushPower = 2.0F;

	[SerializeField] private float maxSpeed = 30.0F;
	private float fallspeed;
	private Vector3 motion;

	Rigidbody2D rigidbody2D;

	public void fall() {
		fallspeed = gravity;
		
		return;
	}

	public void stopFall() {
		fallspeed = 0.0F;
		
		return;
	}

	public bool isGrounded() {
		/*
		if() {
			return false;
		}
		*/
		
		return true;
	}

	public void setMotion(Vector3 input)
	{
		motion = input;
		
		return;
	}

	// Use this for initialization
	void Start () {
		rigidbody2D = GetComponent<Rigidbody2D>();
		motion = new Vector3();
		
		return;
	}
	
	// Update is called once per frame
	void Update () {
		//
		return;
	}

	void FixedUpdate()
	{
		rigidbody2D.velocity = motion;
		
		return;
	}

	void OnControllerColliderHit(ControllerColliderHit hit)
	{
		Debug.Log(hit);
		Rigidbody body = hit.collider.attachedRigidbody;
		if (body == null || body.isKinematic)
			return;

		if (hit.moveDirection.y < -0.3F)
			return;

		Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
		body.velocity = pushDir * pushPower;

		return;
	}
}
