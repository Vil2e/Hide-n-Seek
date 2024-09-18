using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Unlock : MonoBehaviour
{
	public string openedBy;
	Inventory inventory;
	public GameObject pickUp;



	void Start()
	{
		inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();

	}

	private void OnMouseDown()
	{
		//check the selected item
		for (int i = 0; i < inventory.isSelected.Length; i++)
		{
			// right item is selected
			if (inventory.isSelected[i] == true && inventory.slots[i].transform.GetChild(0).gameObject.tag == openedBy)
			{

				if (pickUp != null)
				{
					for (int j = 0; j < inventory.isFull.Length; j++)
					{
						if (inventory.isFull[j] == false)
						{
							Instantiate(pickUp, inventory.slots[j].transform, false);
							inventory.isFull[j] = true;

							if (pickUp.tag == "Doll2")
							{
								GameManager.instance.isDoll2Get = true;
								GameManager.instance.CheckDolls();
							}

							inventory.slots[j].transform.GetChild(0).GetComponent<InventoryItem>().itemIndex = j;
							break;
						}
					}
				}

				inventory.isFull[i] = false;
				Destroy(inventory.slots[i].transform.GetChild(0).gameObject);//destroy the right selected item (already got pick up)
				Destroy(this.gameObject);

			}
		}
		//reset selection (could cause bug if ignore)
		for (int j = 0; j < inventory.isSelected.Length; j++)
		{
			if (inventory.isFull[j] == true)
				inventory.slots[j].transform.GetChild(0).gameObject.GetComponent<Image>().color = Color.white;
			inventory.isSelected[j] = false;

		}

	}


}
