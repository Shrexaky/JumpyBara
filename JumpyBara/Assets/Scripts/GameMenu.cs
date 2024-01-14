using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.AssemblyQualifiedNameParser;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{
	public static bool GameIsPaused = false;
	public GameObject pauseMenuUI;
	public GameObject progressCalculator;
	private float progress;
	public Slider progressSlider;
	public GameObject progresslabel;
	public GameObject musicController;
	public GameObject attempsLabel;

	void Start()
	{
		PlayerPrefs.SetInt("Attemps", PlayerPrefs.GetInt("Attemps")+1);
        PlayerPrefs.Save();
	}
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (GameIsPaused)
			{
				Resume();
			}
			else
			{
				Pause();
			}
		}
		SetSliderValue();
	}

	void SetSliderValue()
	{
		progress = progressCalculator.GetComponent<ProgressCalculator>().progress;
		progressSlider.value = progress/100;
		progresslabel.GetComponent<TMP_Text>().text = Math.Round(progress,0).ToString()+" %";
		attempsLabel.GetComponent<TMP_Text>().text = PlayerPrefs.GetInt("Attemps").ToString();
	}
		

	public void Resume()
	{
		musicController.GetComponent<AudioSource>().volume = musicController.GetComponent<AudioSource>().volume * 3f;
		pauseMenuUI.SetActive(false);
		Time.timeScale = 1f;
		GameIsPaused = false;
	}

	public void GoToMainMenu()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
		Resume();
	}

	public void RestartGame()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		Resume();
	}

	//if(PauseMenu.GameIsPaused) => s.source.pitch *= .5f;

	void Pause()
	{
		musicController.GetComponent<AudioSource>().volume = musicController.GetComponent<AudioSource>().volume * 0.3f;
		pauseMenuUI.SetActive(true);
		Time.timeScale = 0f;
		GameIsPaused = true;
	}
}
