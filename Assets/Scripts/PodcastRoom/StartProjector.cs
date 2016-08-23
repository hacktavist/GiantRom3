using UnityEngine;
using System;

public class StartProjector : MonoBehaviour {
    
    public float bufferTime = 3F;

    public MovieTexture movie;

    private GameObject screen;
    private AudioSource audioSource;
    private CheckVideo cv;
    private bool movieStarted = false;
    private float movieDuration;
    private float currentTime = 0;

	// Use this for initialization
	void Start () {
        screen = GameObject.FindGameObjectWithTag("Screen");
        if (screen == null)
        {
            throw new SystemException("Screen not found");
        }

        screen.GetComponent<Renderer>().material.mainTexture = movie;
        audioSource = screen.GetComponent<AudioSource>();
        audioSource.clip = movie.audioClip;
        cv = GetComponent<CheckVideo>();

        movieDuration = movie.duration;
    }

    void Update()
    {
        if (movieStarted)
        {
            currentTime += Time.deltaTime;
            if (currentTime > movieDuration)
            {
                cv.InitiateCrossFade();
                if (currentTime > movieDuration + bufferTime)
                {
                    cv.ChangeScenes();
                }
            }
        }
    }

    void OnTriggerStay(Collider c)
    {
        if (c.tag == "Player" && Input.GetKeyDown(KeyCode.E) && !movie.isPlaying)
        {
            audioSource.Play();
            movie.Play();
            movieStarted = true;
        }
    }
}
