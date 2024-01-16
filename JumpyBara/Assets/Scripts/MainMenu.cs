using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
	public Slider volumeSlider;
	public void PlayGame()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		PlayerPrefs.SetInt("Attempts", 0);
		PlayerPrefs.Save();
	}

	public void QuitGame()
	{
		Application.Quit();
	}

    void Start()
    {
        AudioListener.volume = PlayerPrefs.GetFloat("Volume");
		volumeSlider.value = PlayerPrefs.GetFloat("Volume");
    }

    public void OnVolumeChanged()
    {
        UpdateVolume();
    }

    void UpdateVolume()
    {
        float volume = volumeSlider.value;
        AudioListener.volume = volume;
		PlayerPrefs.SetFloat("Volume",volumeSlider.value);
    }
}
