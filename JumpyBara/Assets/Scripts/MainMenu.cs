using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
	public Slider volumeSlider;
	public void PlayLevel1()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		PlayerPrefs.SetInt("Attempts", 0);
		PlayerPrefs.Save();
	}

	public void PlayLevel2()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
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
