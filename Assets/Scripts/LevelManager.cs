using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
	[SerializeField] int delaySecs = 2;
	[SerializeField] GameObject creditMenu;
	[SerializeField] GameObject buttonsPanel;

	public void QuitGame()
	{
		Debug.Log("See you next time!");
		Application.Quit();
	}

	public void Play()
	{
		StartCoroutine(StartGame());
	}

	public void OpenCreditMenu()
	{
		creditMenu.SetActive(true);
		buttonsPanel.SetActive(false);
	}

	public void BackToMainPanel()
	{
		creditMenu.SetActive(false);
		buttonsPanel.SetActive(true);
	}

	IEnumerator StartGame()
	{
		yield return new WaitForSeconds(delaySecs);
		SceneManager.LoadScene(1);
	}

}
