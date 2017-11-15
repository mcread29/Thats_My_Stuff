using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BuildingManager : MonoBehaviour {

	public GameObject selectedTower;
	public GameObject holoTower;
	
	public Text nameText;
	public Text damageText;
	public Text rangeText;
	public Text costText;
	
	public CanvasGroup infoTab;

	// Use this for initialization
	void Start () {
		infoTab = FindObjectOfType<CanvasGroup>();
		selectedTower = null;
	}
	
	// Update is called once per frame
	void Update () {
		//TODO: Make arrow tower rotate
		//		Make holoTower transparent
		//		Make new prefabs with no scripts
		// Vector3 mousepos = Input.mousePosition;
		// mousepos.z = 17;
		// if(selectedTower != null){
		// 	if(holoTower == null){
		// 		holoTower = Instantiate(selectedTower, Camera.main.ScreenToWorldPoint(mousepos), selectedTower.transform.rotation);
		// 	}
		// 	else{
		// 		holoTower.transform.position = Vector3.Lerp(holoTower.transform.position, Camera.main.ScreenToWorldPoint(mousepos), 1);
		// 	}
		// }
		// if(Input.GetButtonDown("Fire1")){
		// 	Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		// 	RaycastHit[] hits;
		// 	hits = Physics.RaycastAll(Camera.main.ScreenToWorldPoint(mousepos), Vector3.down);
		// 	foreach(RaycastHit hit in hits){
		// 		Debug.Log(hit.transform.gameObject.tag);
		// 	}
		// 	// for(int i = 0; i < hits.length; i++){
		// 	// 	Debug.Log(hits[i].transform.gameObject.tag);
		// 	// }
		// }
	}

	public void SelectTowerType(GameObject prefab) {
		selectedTower = prefab;
		//Destroy(holoTower.gameObject);
		holoTower = null;
		
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
		else if(prefab.gameObject.tag == "Arrow Tower"){
			damageText.text = "Damage: " + selectedTower.GetComponent<ArrowTower>().damage.ToString();
			rangeText.text 	= "Range: "  + selectedTower.GetComponent<ArrowTower>().range.ToString();
			costText.text 	= "Cost: " 	 + selectedTower.GetComponent<ArrowTower>().cost.ToString();
		}
	}
}

