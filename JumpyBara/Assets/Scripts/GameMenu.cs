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
	public GameObject Star1;
	public GameObject Star2;
	public GameObject Star3;
	public Sprite goldStar;
	public static bool GameIsPaused = false;
	public GameObject pauseMenuUI;
	public GameObject progressCalculator;
	private float progress;
	public Slider progressSlider;
	public GameObject progresslabel;
	public GameObject musicController;
	public GameObject attempsLabel;
	public GameObject attempsLabelMainUi;
	public GameObject orangeContent;
	public GameObject orangeCounterMainUi;
	private int collectedOranges;

	void Start()
	{
		PlayerPrefs.SetInt("Attempts", PlayerPrefs.GetInt("Attempts")+1);
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
		collectedOranges = progressCalculator.GetComponent<CapybaraMovement>().collectedOranges;
		if(collectedOranges>0) Star1.GetComponent<Image>().sprite= goldStar;
		if(collectedOranges>10) Star2.GetComponent<Image>().sprite= goldStar;
		if(collectedOranges>20) Star3.GetComponent<Image>().sprite= goldStar;
	}

	void SetSliderValue()
	{
		progress = progressCalculator.GetComponent<ProgressCalculator>().progress;
		progressSlider.value = progress/100;
		progresslabel.GetComponent<TMP_Text>().text = Math.Round(progress,0).ToString()+" %";
		attempsLabel.GetComponent<TMP_Text>().text = PlayerPrefs.GetInt("Attempts").ToString();
		attempsLabelMainUi.GetComponent<TMP_Text>().text = PlayerPrefs.GetInt("Attempts").ToString();
		orangeCounterMainUi.GetComponent<TMP_Text>().text = collectedOranges.ToString();
		orangeContent.GetComponent<TMP_Text>().text = collectedOranges.ToString();

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
