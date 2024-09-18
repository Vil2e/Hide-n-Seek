using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchRooms : MonoBehaviour
{
	public GameObject[] rooms;
	int cameraIndex = 0;

	public void ClickLeft()
	{
		rooms[cameraIndex].SetActive(false);
		cameraIndex--;
		if (cameraIndex < 0)
		{
			cameraIndex = 2;
		}

		rooms[cameraIndex].SetActive(true);
	}

	public void ClickRight()
	{
		rooms[cameraIndex].SetActive(false);
		cameraIndex++;
		if (cameraIndex > 2)
		{
			cameraIndex = 0;
		}

		rooms[cameraIndex].SetActive(true);
	}
}
