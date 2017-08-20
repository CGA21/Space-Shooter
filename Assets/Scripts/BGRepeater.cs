using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGRepeater : MonoBehaviour {
	public float scrollSpeed;
	public float tilesize;

	private Vector3 startpos;

	void Start(){
		startpos = transform.position;
	}
	void Update(){
		float newpos = Mathf.Repeat(Time.time * scrollSpeed,tilesize);
		transform.position = startpos + Vector3.forward * newpos;
	}
}
