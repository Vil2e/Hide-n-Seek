using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Investigate : MonoBehaviour
{
	public GameObject investigateObj;

	private void OnMouseDown()
	{
		if (investigateObj != null)
		{
			investigateObj.SetActive(true);
			gameObject.SetActive(false);
		}
	}
}
