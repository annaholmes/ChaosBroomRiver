using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DockRock : MonoBehaviour {
	public GameObject dock;
	public List<GameObject> enemies;
	public int numEnemies = 5;
	public GameObject seaLionPrefab;
	public GameObject playerPrefab;


	// Use this for initialization
	void Start () {
		GameObject p = Instantiate (playerPrefab) as GameObject;
		Vector3 player_pos = Vector3.zero;
		player_pos.y = 1;
		p.transform.position = player_pos;
			
		Collider dock_collider = dock.GetComponent<Collider> ();
		Vector3 bounds = dock_collider.bounds.size;
		enemies = new List<GameObject> ();
		// create player
		// create list of enemies (randomly on dock)
		for (int i = 0; i < numEnemies; i++) {
			GameObject s = Instantiate (seaLionPrefab) as GameObject;
			Vector3 pos = Vector3.zero;
			pos.x = Random.Range (bounds.x / 2, -bounds.x / 2);
			pos.y = 1;
			if (Random.Range(0, 2) == 1) {
				pos.z = bounds.z/2 - 0.5f;
			} else {
				pos.z = -bounds.z/2 + 0.5f;
			}
			s.transform.position = pos;
		}
		// Start screen w/instructions
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
