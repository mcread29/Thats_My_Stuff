using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BuildingManager : MonoBehaviour
{

	public GameObject selectedTower;
	public GameObject holoTower;
	
	public Text nameText;
	public Text damageText;
	public Text rangeText;
	public Text costText;
	
	public CanvasGroup infoTab;

	private Tower tower;
	private Floor floor;
	private ArrowTower aTower;

	// Use this for initialization
	void Start ()
	{
		infoTab = FindObjectOfType<CanvasGroup> ();
		selectedTower = null;
	}
	
	// Update is called once per frame
	void Update ()
	{
		//TODO: Make arrow tower rotate
		//		Make holoTower transparent
		//		Make new prefabs with no scripts
		Vector3 mousepos = Input.mousePosition;
		mousepos.z = 15;
		Vector3 worldpos = Camera.main.ScreenToWorldPoint (mousepos);
		Vector3 camerapos = Camera.main.transform.position;
		if (selectedTower != null) {
			if (holoTower == null) {
				holoTower = Instantiate (selectedTower, worldpos, selectedTower.transform.rotation);
				if(holoTower.gameObject.tag == "Tower"){
					tower = holoTower.GetComponent<Tower>();
					Destroy (tower);
				}
				else if(holoTower.gameObject.tag == "Arrow Tower"){
					aTower = holoTower.GetComponent<ArrowTower>();
					Destroy (aTower);
				}
				else if(holoTower.gameObject.tag == "Floor"){
					floor = holoTower.GetComponent<Floor>();
					Destroy (floor);
				}
			} else {
				holoTower.transform.position = Vector3.Lerp (holoTower.transform.position, worldpos, 1);
			}
		}
		if (Input.GetButtonDown ("Fire1")) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit[] hits;
			Vector3 dir = new Vector3 (worldpos.x-camerapos.x, worldpos.y-camerapos.y, worldpos.z-camerapos.z);
			hits = Physics.RaycastAll (worldpos, dir);
			foreach (RaycastHit hit in hits) {
				if(holoTower != null){
					if(holoTower.gameObject.tag == "Arrow Tower" || holoTower.gameObject.tag == "Tower"){
						if(hit.transform.gameObject.tag == "TowerSpot"){
							hit.transform.gameObject.GetComponent<TowerSpot> ().ClickedTowerSpot ();
							Destroy (holoTower);
						}
					}
					else if(holoTower.gameObject.tag == "Floor"){
						if (hit.transform.gameObject.tag == "FloorSpot") {
							hit.transform.gameObject.GetComponent<FloorSpot> ().ClickedFloorSpot ();
							Destroy (holoTower);
						}
					}
				}
			}
		}
	}

	public void SelectTowerType (GameObject prefab)
	{
		selectedTower = prefab;
		//Destroy(holoTower.gameObject);
		holoTower = null;
		
		infoTab.alpha = 1f;
		
		nameText.text = selectedTower.name;
		
		if (prefab.gameObject.tag == "Tower") {
			damageText.text = "Damage: " + selectedTower.GetComponent<Tower> ().damage.ToString ();
			rangeText.text = "Range: " + selectedTower.GetComponent<Tower> ().range.ToString ();
			costText.text = "Cost: " + selectedTower.GetComponent<Tower> ().cost.ToString ();
		} else if (prefab.gameObject.tag == "Floor") {
			damageText.text = "Damage: " + selectedTower.GetComponent<Floor> ().damage.ToString ();
			rangeText.text = "Range: " + selectedTower.GetComponent<Floor> ().range.ToString ();
			costText.text = "Cost: " + selectedTower.GetComponent<Floor> ().cost.ToString ();
		} else if (prefab.gameObject.tag == "Arrow Tower") {
			damageText.text = "Damage: " + selectedTower.GetComponent<ArrowTower> ().damage.ToString ();
			rangeText.text = "Range: " + selectedTower.GetComponent<ArrowTower> ().range.ToString ();
			costText.text = "Cost: " + selectedTower.GetComponent<ArrowTower> ().cost.ToString ();
		}
	}
}

