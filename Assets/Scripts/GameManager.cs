using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager instance;

	public bool isDoll1Get = false;
	public bool isDoll2Get = false;
	public bool isDoll3Get = false;

	[SerializeField] GameObject finalLetter;


	void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			Destroy(gameObject);
		}
	}

	// get 3 dolls then reveal the final letter
	public void CheckDolls()
	{
		if (isDoll1Get && isDoll2Get && isDoll3Get && finalLetter != null)
		{
			finalLetter.SetActive(true);
		}
	}

	public void QuitGame()
	{
		Debug.Log("See ypu next time!");
		Application.Quit();
	}

}
