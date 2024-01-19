using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CapybaraCollision : MonoBehaviour
{
	private AudioSource audioSource;
	public GameObject sound_object;
	public ProgressCalculator progressCalculator;
	public bool gameOver = false;
	public GameObject endCanva;
	public Slider slider;
	public float progress;
	public GameObject spearIcon;
	public GameObject lightsaberIcon;
	public GameObject capySpear;
	public GameObject capyLightsaber;

	void Start()
	{
		audioSource = gameObject.GetComponent<AudioSource>();
		progressCalculator = gameObject.GetComponent<ProgressCalculator>();
	}

    IEnumerator EndCanvaActivation(float delay)
    {
        yield return new WaitForSeconds(delay);
        endCanva.gameObject.SetActive(true);
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Enemy"))
		{
			if (spearIcon.activeSelf)
			{
				collision.gameObject.SetActive(false);
				capySpear.GetComponent<SpriteRenderer>().enabled = false;
				spearIcon.SetActive(false);
				return;
			}

			if (lightsaberIcon.activeSelf)
			{
				collision.gameObject.SetActive(false);
				capyLightsaber.GetComponent<SpriteRenderer>().enabled = false;
				lightsaberIcon.SetActive(false);
				return;
			}

			GetComponent<CapybaraMovement>().capybaraStop = true;
			sound_object.GetComponent<AudioSource>().Stop();
			audioSource.Play();
			endCanva.SetActive(true);
			progressCalculator.CalculateAndPrintProgress(gameObject.transform);
		}
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Spear"))
		{
			if (!spearIcon.activeSelf)
			{
				GetComponent<CapybaraMovement>().CollectObject(other.gameObject);
				capySpear.GetComponent<SpriteRenderer>().enabled = true;
				spearIcon.SetActive(true);
				other.gameObject.SetActive(false);
			}
		}

		if (other.gameObject.CompareTag("Lightsaber"))
		{
			if (!lightsaberIcon.activeSelf)
			{
				GetComponent<CapybaraMovement>().CollectObject(other.gameObject);
				capyLightsaber.GetComponent<SpriteRenderer>().enabled = true;
				lightsaberIcon.SetActive(true);
				other.gameObject.SetActive(false);
			}
		}

		if (other.gameObject.CompareTag("Flag"))
		{
			GetComponent<CapybaraMovement>().capybaraStop = true;
			gameOver = true;
			progressCalculator.CalculateAndPrintProgress(gameObject.transform);
			StartCoroutine(EndCanvaActivation(3.0f));
		}
	}
}
