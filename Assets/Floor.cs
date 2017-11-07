using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour {

	public float damage;
	public float fireCooldown;
	public float range;

	private BoxCollider col;
	
	// Use this for initialization
	void Start () {
		col = GetComponent<BoxCollider> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (fireCooldown > 0){
			fireCooldown -= 1;
		}
	}

	void OnTriggerStay(Collider other){
		if (fireCooldown <= 0) {
			Destroy (other.gameObject);
			fireCooldown = 100;
		} 
	}
	
}
