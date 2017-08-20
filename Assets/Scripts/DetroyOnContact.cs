using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetroyOnContact : MonoBehaviour {

	public GameObject explosion;
	public GameObject playerexplosion;
	private GameController gamecontroller;
	public int scorevalue;
	void Start(){

		GameObject gamecontrollerObject = GameObject.FindWithTag ("GameController");
		if (gamecontrollerObject != null) {
			gamecontroller = gamecontrollerObject.GetComponent<GameController> ();
		}
	
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Boundary"||other.tag == "Enemy"||other.tag=="bolt enemy") {
			return;
		}

		if (explosion != null) {
			Instantiate (explosion, transform.position, transform.rotation);
		}
		gamecontroller.AddScore(scorevalue);
		if (other.tag == "Player") {
			Instantiate (playerexplosion, other.transform.position, other.transform.rotation);
			gamecontroller.GameOver ();
			Destroy (other.gameObject);
			Destroy (gameObject);
		}
			
		Destroy (other.gameObject);
		Destroy (gameObject);
	}
}
