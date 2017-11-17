using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour {

	public float damage;
	public float fireCooldown;
	public float range;
	public int cost;

	private BoxCollider col;
	public Renderer rend;
	
	// Use this for initialization
	void Start () {
		col = GetComponent<BoxCollider> ();
        rend = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
		if (fireCooldown > 0){
			fireCooldown -= 1;
			//rend.material.color = Color.red;
		}
		else{
			rend.material.color = Color.green;
		}
	}

	void OnTriggerStay(Collider other){
		if(other.gameObject.tag == "Enemy" && fireCooldown <= 0){
			other.GetComponent<Enemy>().Die();
			fireCooldown = 100;
			rend.material.color = Color.blue;
		}
	}
	
}
