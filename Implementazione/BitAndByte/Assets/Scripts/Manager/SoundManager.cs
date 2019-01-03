using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    //public static SoundManager instance { get; private set; }
    private static SoundManager soundManager;
    public static SoundManager instance
    {
        get
        {
            if (soundManager == null)
            {
                soundManager = FindObjectOfType(typeof(SoundManager)) as SoundManager;

                if (!soundManager)
                {
                    Debug.LogError("There needs to be one active SoundManager script on a GameObject in your scene.");
                }
                else
                {
                    soundManager.Init();
                }
            }
            return soundManager;
        }
    }




    private AudioSource Background;
    private AudioSource Effect;


    private void Init()
    {
        Background = GetComponents<AudioSource>()[0];
        Effect = GetComponents<AudioSource>()[1];
        DontDestroyOnLoad(gameObject);
    }

    /*private void Awake()
	{
		if (instance == null)
		{
			instance = this;
            Background = GetComponents<AudioSource>()[0];
            Background = GetComponents<AudioSource>()[1];
            DontDestroyOnLoad(gameObject);
		}
		else
		{
			Destroy(gameObject);
		}
	}*/


    public void StartBackgroundMusic(AudioClip Audio)
    {
        Background.Stop();
        Background.clip = Audio;
        Background.loop = true;
        Background.Play();
    }

    public void StartEffectMusic(AudioClip Audio)
    {
        Effect.PlayOneShot(Audio);
    }

    public void StopBackgroundMusic()
    {
        Background.Stop();
    }



}
