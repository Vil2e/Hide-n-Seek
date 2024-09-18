using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Pickup : MonoBehaviour
{
	public GameObject item;
	Inventory inventory;

	void Start()
	{
		inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
	}

	private void OnMouseDown()
	{
		for (int i = 0; i < inventory.slots.Length; i++)
		{
			if (inventory.isFull[i] == false)
			{
				GameObject inventoryItem = Instantiate(item, inventory.slots[i].transform, false);

				if (item.tag == "Doll3")
				{
					GameManager.instance.isDoll3Get = true;
					GameManager.instance.CheckDolls();
				}

				inventoryItem.GetComponent<InventoryItem>().itemIndex = i; //decide slot index for item

				inventory.isFull[i] = true;
				Destroy(gameObject);
				break;
			}
		}

	}


}
