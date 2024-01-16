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
	public GameObject capySpear;

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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Flag"))
        {
            GetComponent<CapybaraMovement>().capybaraStop = true;
            gameOver=true;
            progressCalculator.CalculateAndPrintProgress(gameObject.transform);
            StartCoroutine(EndCanvaActivation(3.0f));
        }
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

		if (other.gameObject.CompareTag("Flag"))
		{
			GetComponent<CapybaraMovement>().capybaraStop = true;
			gameOver = true;
			endCanva.SetActive(true);
			progressCalculator.CalculateAndPrintProgress(gameObject.transform);
		}
	}
}
