using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager audioManager;
    // Start is called before the first frame update
    [SerializeField] private AudioSource source;


    private void Awake()
    {
        if(audioManager == null)
        {
            audioManager = this;
            source = GetComponent<AudioSource>();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        source.volume = PlayerPrefs.GetFloat("MVolume");
    }

    public void PlaySound(AudioClip sound, Vector3 position)
    {
        AudioSource.PlayClipAtPoint(sound, position, source.volume);
    }
}
