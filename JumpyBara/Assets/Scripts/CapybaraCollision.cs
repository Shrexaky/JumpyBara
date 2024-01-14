using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CapybaraCollision : MonoBehaviour
{
    private AudioSource audioSource;
    public GameObject sound_object;
    public ProgressCalculator progressCalculator;
    public bool gameOver=false;
    public GameObject endCanva;
    public Slider slider;
    public float progress;
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        progressCalculator=gameObject.GetComponent<ProgressCalculator>();
    }

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            GetComponent<CapybaraMovement>().capybaraStop = true;
            sound_object.GetComponent<AudioSource>().Stop();
            audioSource.Play();
            endCanva.gameObject.SetActive(true);
            progressCalculator.CalculateAndPrintProgress(gameObject.transform);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Flag"))
        {
            GetComponent<CapybaraMovement>().capybaraStop = true;
            gameOver=true;
            endCanva.gameObject.SetActive(true);
            progressCalculator.CalculateAndPrintProgress(gameObject.transform);
        }
    }


}
