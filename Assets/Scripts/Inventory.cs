using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
	public GameObject[] slots;
	public bool[] isSelected;
	public bool[] isFull;


	void Start()
	{
		for (int i = 0; i < isSelected.Length; i++)
		{
			isSelected[i] = false;
			isFull[i] = false;
		}
	}

}
