using UnityEngine;
using System.Collections;

public class CameraTrigger : MonoBehaviour {
	public Camera target;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D()
	{
		target.enabled = true;
		target.ResetWorldToCameraMatrix();

		return;
	}
}
