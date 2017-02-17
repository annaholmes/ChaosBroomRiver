using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaLion : MonoBehaviour {
	public float easing = 0.5f;
	// Use this for initialization
	void Start () {
		
	}
	

	void FixedUpdate () {
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		Vector3 poi = player.transform.position;
		print (poi);

		this.transform.position = Vector3.Lerp(this.transform.position, poi, easing);
	}
}
