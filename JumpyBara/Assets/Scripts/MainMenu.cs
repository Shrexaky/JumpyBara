using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
	public Slider volumeSlider;
	public GameObject level2Blockade;
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
		PlayerPrefs.SetString("Level_2_Active","false");
		Application.Quit();
	}

    void Start()
    {
		if(PlayerPrefs.GetString("Level_2_Active")=="true")
		{
			level2Blockade.gameObject.SetActive(false);
		}
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
