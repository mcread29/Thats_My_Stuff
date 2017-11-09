using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BuildingManager : MonoBehaviour {

	public GameObject selectedTower;
	
	public Text nameText;
	public Text damageText;
	public Text rangeText;
	public Text costText;
	
	public CanvasGroup infoTab;

	// Use this for initialization
	void Start () {
		infoTab = FindObjectOfType<CanvasGroup>();
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void SelectTowerType(GameObject prefab) {
		selectedTower = prefab;
		
		infoTab.alpha = 1f;
		
		nameText.text 	= 			   selectedTower.name;
		
		if(prefab.gameObject.tag == "Tower"){
			damageText.text = "Damage: " + selectedTower.GetComponent<Tower>().damage.ToString();
			rangeText.text 	= "Range: "  + selectedTower.GetComponent<Tower>().range.ToString();
			costText.text 	= "Cost: " 	 + selectedTower.GetComponent<Tower>().cost.ToString();
		}
		else if(prefab.gameObject.tag == "Floor"){
			damageText.text = "Damage: " + selectedTower.GetComponent<Floor>().damage.ToString();
			rangeText.text 	= "Range: "  + selectedTower.GetComponent<Floor>().range.ToString();
			costText.text 	= "Cost: " 	 + selectedTower.GetComponent<Floor>().cost.ToString();
		}
		
		
		
	}
}
