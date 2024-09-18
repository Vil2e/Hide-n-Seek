using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalLetter : MonoBehaviour
{

	public GameObject letter;


	private void OnMouseDown()
	{
		if (letter != null)
		{
			letter.SetActive(true);
		}
	}
}
