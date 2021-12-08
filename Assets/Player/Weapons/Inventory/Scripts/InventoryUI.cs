using UnityEngine;

public class InventoryUI : MonoBehaviour
{
	public Transform itemsParent;   // The parent object of all the items
	public GameObject inventoryUI;  // The entire UI

	void Start()
	{

	}

	void Update()
	{
		// Check to see if we should open/close the inventory
		if (Input.GetKeyDown(KeyCode.Tab))
		{
			inventoryUI.SetActive(!inventoryUI.activeSelf);
		}
	}


}
