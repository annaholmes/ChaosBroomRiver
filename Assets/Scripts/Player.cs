using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	public float easing = 1f;
	
	// Use this for initialization
	void Start () {
		
	}
		
	
	// Update is called once per frame
	void Update () {
		Vector3 mousePos2D = Input.mousePosition;
		mousePos2D.z = Camera.main.transform.position.z;
		Vector3 mousePos3D = Camera.main.ScreenToWorldPoint (mousePos2D);

		Vector3 pos = this.transform.position;
		pos.x = mousePos3D.x;
		pos.z = mousePos3D.z;
		this.transform.position = Vector3.Lerp(this.transform.position, pos, easing);
		
	}
}

