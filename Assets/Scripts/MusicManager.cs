using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

    public static MusicManager _instance;
    public AudioClip getMeat;
    public AudioClip getHero;
    public AudioSource audio;

    private void Start()
    {
        _instance = this;
    }

    public void PlayGetMeatAudio()
    {
        audio.PlayOneShot(getMeat);
    }

    public void PlayGetHeroAudio()
    {
        audio.PlayOneShot(getHero);
    }

}
