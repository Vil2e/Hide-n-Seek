using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
	public int itemIndex;
	public string combinesWith;
	public GameObject combinedObj;
	Inventory inventory;

	[SerializeField] bool doll1;
	[SerializeField] bool doll2;
	[SerializeField] bool doll3;

	void Start()
	{
		inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();

	}

	public void SelectItem() //for item onclick use
	{
		gameObject.GetComponent<Image>().color = Color.grey;

		int tempCount = 0;// if 0, means this one is the first selected item
		int countIndex = 0;//record the last item selected

		for (int i = 0; i < inventory.isSelected.Length; i++)
		{
			if (inventory.isSelected[i] == true)
			{
				tempCount++;
				countIndex = i;//get the last item index
			}
		}

		if (tempCount == 0)
		{
			inventory.isSelected[itemIndex] = true;//this one is the first chosen item
		}
		else // already got a selected item (tempCount != 0)
		{
			if (combinedObj != null && inventory.slots[countIndex].transform.GetChild(0).gameObject.tag == combinesWith)
			{
				GameObject previousItem = inventory.slots[countIndex].transform.GetChild(0).gameObject;
				Transform thisParent = inventory.slots[itemIndex].transform;

				Destroy(previousItem);//destroy item1

				inventory.isFull[itemIndex] = false;
				Instantiate(combinedObj, thisParent, false);

				if (combinedObj.tag == "Doll1")
				{
					GameManager.instance.isDoll1Get = true;
					GameManager.instance.CheckDolls();
				}

				thisParent.GetChild(1).gameObject.GetComponent<InventoryItem>().itemIndex = itemIndex;// assign child0 value to child1

				inventory.isFull[itemIndex] = true;
				inventory.isFull[countIndex] = false;

				// cancel selections
				inventory.isSelected[itemIndex] = false;
				inventory.isSelected[countIndex] = false;

				Destroy(this.gameObject);
			}
			else
			{
				// cancel selections
				inventory.isSelected[itemIndex] = false;
				inventory.isSelected[countIndex] = false;

				inventory.slots[itemIndex].transform.GetChild(0).gameObject.GetComponent<Image>().color = Color.white;
				inventory.slots[countIndex].transform.GetChild(0).gameObject.GetComponent<Image>().color = Color.white;
			}

		}




	}
}
