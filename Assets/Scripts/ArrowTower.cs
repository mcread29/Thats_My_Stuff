using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTower : MonoBehaviour {

	Transform turretTransform;

	public float range = 10f;
	public GameObject arrowPrefab;

	public int cost = 5;

	float fireCooldown = 0;
	float fireCooldownLeft = 0;

	public float damage = 1;
	public float radius = 5;

	private bool selected = false;
	private bool placed = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(selected){
			if(Input.GetKeyDown("right")){
				transform.rotation = transform.rotation * Quaternion.Euler(0, 90, 0);
			}
			else if(Input.GetKeyDown("left")){
				transform.rotation = transform.rotation * Quaternion.Euler(0, -90, 0);;
			}
		}
	}

	void OnMouseDown(){
		foreach (Transform child in transform)
		{
			child.gameObject.GetComponent<TurretColorChanger> ().ChangeShader ();
		}
		selected = !selected;
	}
	
	void OnTriggerStay(Collider other){
		if(other.gameObject.tag == "Enemy" && fireCooldown <= 0){
			Shoot ();
			fireCooldown = 50;
		}
		else{
			fireCooldown--;
		}
	}

	void Shoot() {
		Vector3 pos = new Vector3 (transform.position.x, transform.position.y + 1, transform.position.z);
		// TODO: Fire out the tip!
		GameObject arrowGO = (GameObject)Instantiate(arrowPrefab, pos, this.transform.rotation);

	}
}
