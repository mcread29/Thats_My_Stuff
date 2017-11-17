using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {

	public float speed = 1f;
	public float damage = 1f;
	public float radius = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float distThisFrame = speed * Time.deltaTime;
		transform.Translate( transform.forward * distThisFrame, Space.World );
		//Quaternion targetRotation = Quaternion.LookRotation( dir );
		//this.transform.rotation = Quaternion.Lerp(this.transform.rotation, targetRotation, Time.deltaTime*5);
	}

	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "Enemy"){
			//other.
		}
	}
}
