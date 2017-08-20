using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
	public GameObject[] hazards;
	public Vector3 spawnvalues;
	public int hazardcount;
	public float spawnWait;
	public float startWait;
	public float WaveWait;
	public GUIText scoretext;
	public GUIText restarttext;
	public GUIText gameovertext;
	private bool gameover;
	private bool restart;
	private int score;

	void Start(){
		
		gameover = false;
		restart = false;
		restarttext.text = "";
		gameovertext.text = "";
		hazards [0].GetComponent<Mover> ().speed = -4;
		hazards [1].GetComponent<Mover> ().speed = -3;
		hazards [2].GetComponent<Mover> ().speed = -5;
		hazards [3].GetComponent<Mover> ().speed = -4;
		hazards [3].GetComponent<WeaponControl> ().firerate = 4;
		hazards [3].GetComponent<Evade> ().dodge = 5;
		hazards [3].GetComponent<Evade> ().startWait.x = 1.00f;
		hazards [3].GetComponent<Evade> ().startWait.y = 1.25f;
		StartCoroutine( Spawnwaves ());
	}
	IEnumerator Spawnwaves()
	{ 
		while(true)
		{
			
			for (int i=0;i<hazardcount;i++) {
				GameObject hazard = hazards [Random.Range (0, hazards.Length)];
				yield return new WaitForSeconds (startWait);
				Vector3 spawnposition = new Vector3 (Random.Range (-spawnvalues.x, spawnvalues.x), 0.0f, spawnvalues.z);
				Quaternion spawnrotation = Quaternion.identity;
				Instantiate (hazard, spawnposition, spawnrotation);
				yield return new WaitForSeconds (spawnWait);

				if (gameover) {
					restarttext.text = "Press 'R' To Restart Game";
					restart = true;
					break;
				}
				if (hazard.GetComponent<Mover> ().speed < 15) {
					hazard.GetComponent<Mover> ().speed -= 0.25f;
				} else {
					mn:hazard.GetComponent<Mover> ().speed = 10;
				}
			}
			if (hazards [3].GetComponent<WeaponControl> ().firerate > 0) {

				hazards [3].GetComponent<WeaponControl> ().firerate -= 0.5f;
			} else {
				mn:hazards [3].GetComponent<WeaponControl> ().firerate = 0.5f;
			}
			hazardcount += 3;
			spawnWait /= 10;
			hazards [3].GetComponent<Evade> ().dodge += 3;
			hazards [3].GetComponent<Evade> ().startWait.x -= 0.25f;
			hazards [3].GetComponent<Evade> ().startWait.y -= 0.25f;
			yield return new WaitForSeconds (WaveWait);
		
		}
	}

	public void GameOver()
	{
		gameovertext.text = "Game Over ";

		gameover = true;

	}
	public void AddScore(int newscorevalue){

		score += newscorevalue;
		UpdateScore ();

	}
	void UpdateScore(){

		scoretext.text = "Score : " + score;

	}
	void Update(){
		if (restart) {
			if (Input.GetKeyDown (KeyCode.R)) {
				Application.LoadLevel (Application.loadedLevel);	
			}
		}
	}

}
