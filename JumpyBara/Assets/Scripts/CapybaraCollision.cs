using UnityEngine;
using UnityEngine.SceneManagement;

public class CapybaraCollision : MonoBehaviour
{
    private AudioSource audioSource;
    public GameObject sound_object;
    public ProgressCalculator progressCalculator;
    public bool gameOver=false;
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        progressCalculator=gameObject.GetComponent<ProgressCalculator>();
    }

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            
            Invoke("RestartGame", 3f);
            GetComponent<CapybaraMovement>().capybaraStop = true;
            sound_object.GetComponent<AudioSource>().Stop();
            audioSource.Play();
            progressCalculator.CalculateAndPrintProgress(gameObject.transform);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Flag"))
        {
            GetComponent<CapybaraMovement>().capybaraStop = true;
            gameOver=true;
        }
    }

    private void RestartGame()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}
