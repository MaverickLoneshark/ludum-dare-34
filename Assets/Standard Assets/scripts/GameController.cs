using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameController : MonoBehaviour {
	public System.String gameState = "playing";
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(gameState == "gameover") {
			if(Input.anyKeyDown) {
				SceneManager.LoadScene("adventureland");
			}
		}
	}
}
