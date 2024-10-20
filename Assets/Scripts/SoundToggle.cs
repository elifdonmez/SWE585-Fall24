using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundToggle : MonoBehaviour
{
   private AudioSource audioSource;
    private bool isPlaying = true;

    void Start()
    {
        // Get the AudioSource component
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();  // Start playing the audio
    }

    void Update()
    {
        // Check for 'm' key press
        if (Input.GetKeyDown(KeyCode.M))
        {
            // Toggle sound on and off
            if (isPlaying)
            {
                audioSource.Pause();
            }
            else
            {
                audioSource.UnPause();
            }

            // Toggle isPlaying state
            isPlaying = !isPlaying;
        }
    }
}
