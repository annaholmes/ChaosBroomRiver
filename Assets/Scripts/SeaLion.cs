using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaLion : MonoBehaviour {
	public float easing = 0.5f;
	public GameObject poi;
	public GameObject player;
	public GameObject[] otherLions;
	public Collider dock_collider;
	public Vector3 bounds;
	public GameObject dock;
	public float forceConstant = 1.0f;
	// Use this for initialization
	void Start () {
		dock = GameObject.FindGameObjectWithTag ("Dock");
		dock_collider = dock.GetComponent<Collider> ();
		bounds = dock_collider.bounds.size;
		player = GameObject.FindGameObjectWithTag("Player");
		poi = player;
		otherLions = GameObject.FindGameObjectsWithTag ("SeaLion");
		int randPick = Random.Range (0, otherLions.Length);
		if (Random.Range(0, 2) == 0) {
			poi = otherLions [randPick];
		}
	}
	

	void FixedUpdate () {
		
		if (gameObject.transform.position.z > bounds.z / 2 || gameObject.transform.position.z < -bounds.z / 2 
			|| gameObject.transform.position.x > bounds.x / 2 || gameObject.transform.position.x < -bounds.x / 2) {
			Destroy (this.gameObject);
			return;
		}
		while (poi == null || poi == this.gameObject) {
			poi = player;

			if (Random.Range (0, 2) == 0) {
				int randPick = Random.Range (0, otherLions.Length);
				poi = otherLions [randPick];
			}
		}

		Vector3 fv = poi.transform.position - this.transform.position;
		Rigidbody rb = gameObject.GetComponent<Rigidbody> ();
		rb.AddForce (fv * forceConstant);
	}
}
