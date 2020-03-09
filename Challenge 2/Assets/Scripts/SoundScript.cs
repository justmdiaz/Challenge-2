using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript : MonoBehaviour
{
    public AudioClip musicClipOne;

    public AudioClip musicClipTwo;

    public AudioSource musicSource;

    public AudioClip background;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
       

        if (Input.GetKeyDown(KeyCode.W))
        {
            musicSource.clip = musicClipOne;
            musicSource.Play();
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            
            musicSource.clip = background;
            musicSource.Play();

        }

        if (Input.GetKeyDown(KeyCode.R))
        {

           
        }

        if (Input.GetKeyUp(KeyCode.R))
        {
            musicSource.Stop();
            musicSource.clip = background;
            musicSource.Play();

        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            musicSource.loop = true;
        }

        if (Input.GetKeyUp(KeyCode.L))
        {
            musicSource.loop = false;
        }
    }
}
