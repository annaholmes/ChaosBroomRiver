using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	public float easing = 1f;
	public Vector3 bounds;
	public Collider dock_collider;
	public GameObject dock;
	public float forceConstant = 1.0f;
	// Use this for initialization
	void Start () {
		dock = GameObject.FindGameObjectWithTag ("Dock");
		dock_collider = dock.GetComponent<Collider> ();
		bounds = dock_collider.bounds.size;	
	}
	
	// Update is called once per frame
	void Update () {
		if (this.gameObject.transform.position.z > bounds.z / 2 || gameObject.transform.position.z < -bounds.z / 2 
			|| this.gameObject.transform.position.x > bounds.x / 2 || gameObject.transform.position.x < -bounds.x / 2) {
			Destroy (this.gameObject);
			return;
		}

		Vector3 mousePos2D = Input.mousePosition;
		mousePos2D.z = Camera.main.transform.position.z;
		Vector3 mousePos3D = Camera.main.ScreenToWorldPoint (mousePos2D);

		Vector3 pos = this.transform.position;
		pos.x = mousePos3D.x;
		pos.z = mousePos3D.z;
		this.transform.position = Vector3.Lerp(this.transform.position, pos, easing);
		if (Input.GetMouseButtonDown (0)) {
			Vector3 fv = pos - this.transform.position;
			Rigidbody rb = gameObject.GetComponent<Rigidbody> ();
			rb.AddForce (fv * forceConstant);
		}
	}
}

