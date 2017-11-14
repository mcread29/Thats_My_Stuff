using UnityEngine;
using System.Collections;

public class FloorSpot : MonoBehaviour {

	public CanvasGroup infoTab;
	
	void Start(){
		infoTab = FindObjectOfType<CanvasGroup>();
	}
	
	void OnMouseUp() {
		Debug.Log("FloorSpot clicked.");

		BuildingManager bm = GameObject.FindObjectOfType<BuildingManager>();
		if(bm.selectedTower != null) {
			ScoreManager sm = GameObject.FindObjectOfType<ScoreManager>();
			if(sm.money < bm.selectedTower.GetComponent<Floor>().cost) {
				Debug.Log("Not enough money!");
				return;
			}

			sm.money -= bm.selectedTower.GetComponent<Floor>().cost;

			// FIXME: Right now we assume that we're an object nested in a parent.
			Instantiate(bm.selectedTower, transform.parent.position, transform.parent.rotation);
			Destroy(transform.parent.gameObject);
			
			infoTab.alpha = 0f;
			bm.selectedTower = null;
		}
	}

}