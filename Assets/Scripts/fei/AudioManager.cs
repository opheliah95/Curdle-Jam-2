using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AudioManager
{
    static AudioClip sfx;
    //AudioClip music;

    public static AudioSource audiosource;


    public static void playSound(string sfxName, float vol = 1)
    {
        sfx = Resources.Load("Audio/" + sfxName) as AudioClip;
        if (audiosource == null)
        {
            audiosource = new GameObject().AddComponent<AudioSource>();
            audiosource.name = "soundplayer";
        }
        audiosource.transform.position = Camera.main.transform.position;
        audiosource.volume = vol;
        audiosource.PlayOneShot(sfx);

    }
}
