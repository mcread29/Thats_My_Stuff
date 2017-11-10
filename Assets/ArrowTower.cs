using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTower : MonoBehaviour {

	Transform turretTransform;

	public float range = 10f;
	public GameObject bulletPrefab;

	public int cost = 5;

	float fireCooldown = 0.5f;
	float fireCooldownLeft = 0;

	public float damage = 1;
	public float radius = 5;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerStay(Collider other){
		if(other.gameObject.tag == "Enemy"){
			
		}
	}
}
