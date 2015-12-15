using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameController : MonoBehaviour {
	public System.String gameState = "playing";

	[SerializeField] private AudioClip failAudio = new AudioClip();
	[SerializeField] private AudioClip killAudio = new AudioClip();
	private Camera camera;

	public void enterDecisionState() {
		gameState = "decision";
		GetComponent<AudioSource>().Play();

		return;
	}

	public System.String getGameState() {
		return gameState;
	}

	// Use this for initialization
	void Start () {
		camera = gameObject.GetComponent<Camera>();

		return;
	}
	
	// Update is called once per frame
	void Update () {
		switch(gameState) {
			case "gameover":
				if(Input.anyKeyDown)
				{
					SceneManager.LoadScene("adventureland");
				}
			break;

			case "decision":
				if((Input.GetAxis("Vertical") < 0) && (Input.GetButtonDown("Fire1")))
				{
					if(GameObject.Find("Hero").GetComponentInChildren<PlayerCharacter>().hasCookie)
					{
						//give cookie
						GetComponent<UnityStandardAssets._2D.Camera2DFollow>().target = GameObject.Find("Santa").transform;
						GameObject.Find("SantaCam").SetActive(false);
						
						DestroyObject(GameObject.Find("Hero"));
						transform.FindChild("Canvas").gameObject.SetActive(true);
						GetComponentInChildren<Text>().text = "You died from diabetes\n" + GetComponentInChildren<Text>().text;
						gameState = "gameover";
					}
					else {
						AudioSource.PlayClipAtPoint(failAudio, transform.position);
					}
				}
				else if(Input.GetButtonDown("Fire1")) {
					//shoot
					GetComponent<UnityStandardAssets._2D.Camera2DFollow>().target = GameObject.Find("Nick").transform;
					GetComponent<UnityStandardAssets._2D.Camera2DFollow>().enabled = false;
					camera.transform.position = GameObject.Find("SantaCam").transform.position;
					GameObject.Find("SantaCam").SetActive(false);
					AudioSource.PlayClipAtPoint(killAudio, transform.position);
					
					DestroyObject(GameObject.Find("Santa"));
					transform.FindChild("Canvas").gameObject.SetActive(true);
					GetComponentInChildren<Text>().text = "You killed Xmas\n" + GetComponentInChildren<Text>().text;
					gameState = "gameover";
				}
			break;

			default:
			break;
		}
	}
}
