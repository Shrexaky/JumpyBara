using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Movement : MonoBehaviour
{
	public Transform cel;
	public float offsetPoziomy = 5f;
	public AudioClip backgroundMusic;
    private AudioSource audioSource;
	public GameObject capyabara;
	private bool gameOver;
	void Start()
	{
		PlayMusic();
		gameOver = capyabara.gameObject.GetComponent<CapybaraCollision>().gameOver;
	}

	void Update()
	{
		gameOver = capyabara.gameObject.GetComponent<CapybaraCollision>().gameOver;
		if (cel != null)
		{
			Podazaj();
			if(gameOver)
			{
				audioSource.Stop();
			}
			
		}
	}

	void PlayMusic()
	{
        if (backgroundMusic != null)
        {
            audioSource = gameObject.GetComponent<AudioSource>();
            if (audioSource == null)
            {
                audioSource = gameObject.AddComponent<AudioSource>();
            }

            audioSource.clip = backgroundMusic;

            audioSource.loop = true;
            audioSource.playOnAwake = false;
			
			audioSource.Play();
            
        }
	}

	void Podazaj()
	{
		Vector3 nowaPozycja = new Vector3(cel.position.x + offsetPoziomy, transform.position.y, transform.position.z);
		transform.position = Vector3.Lerp(transform.position, nowaPozycja, Time.deltaTime * 2);
	}
}
