using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretColorChanger : MonoBehaviour {

	public Material mat1;
	public Material mat2;
	public bool selected = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ChangeShader(){
		if(!selected){
			GetComponent<Renderer> ().material = mat2;
		}
		else{
			GetComponent<Renderer> ().material = mat1;
		}
		selected = !selected;
	}
}
