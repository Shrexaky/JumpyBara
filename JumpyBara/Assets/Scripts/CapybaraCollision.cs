using UnityEngine;
using UnityEngine.SceneManagement;

public class CapybaraCollision : MonoBehaviour
{

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Invoke("RestartGame", 3f);
            GetComponent<CapybaraMovement>().capybaraStop = true;
        }
    }

    private void RestartGame()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}
