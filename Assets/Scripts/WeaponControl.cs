using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponControl : MonoBehaviour {
	public GameObject shot;
	public Transform shotspawn;
	private AudioSource audio;
	public float firerate;
	public float delay;
	void Start () {
		audio = GetComponent<AudioSource> ();
		InvokeRepeating ("Fire", delay, firerate);
		
	}
	void Fire(){
		
		Instantiate (shot,shotspawn.position,shotspawn.rotation);
		audio.Play ();

	
	}


	}
		
	

