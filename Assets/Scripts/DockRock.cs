using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* still need:
 * layers
 * triggers
 * effects
 * vection
 * linerenderers
 * buttons
 * camera movement
 * audiosource
 * physic material 
 */

public class DockRock : MonoBehaviour {
	public GameObject dock;
	public List<GameObject> enemies;
	public int numEnemies = 5;
	public GameObject seaLionPrefab;
	public GameObject playerPrefab;
	public Collider dock_collider;
	public Vector3 bounds;
	public GameObject p;
	public float secBetweenWaves = 3f;


	// Use this for initialization
	void Start () {
		InvokeRepeating ("Wave", 0f, secBetweenWaves); 
		p = Instantiate (playerPrefab) as GameObject;
		Vector3 player_pos = Vector3.zero;
		player_pos.y = 1;
		p.transform.position = player_pos;
			
		dock_collider = dock.GetComponent<Collider> ();
		bounds = dock_collider.bounds.size;
		enemies = new List<GameObject> ();
		// create player
		// create list of enemies (randomly on dock)

		// Start screen w/instructions
	}

	void Wave() {
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

	}
	
	// Update is called once per frame
	void Update () {
		// TODO makes unity crash 
		if (p == null) {
			Time.timeScale = 0;
		}
	}
}
