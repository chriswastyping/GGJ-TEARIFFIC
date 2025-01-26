using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class MusicManager : MonoBehaviour
{
    private AudioSource newAudio;
    public AudioClip[] songs;
    public float volume;

    private void Start()
    {
        newAudio = GetComponent<AudioSource>();
        if (!newAudio.isPlaying)
        {
            ChangeMusic(Random.Range(0, songs.Length));
        }
    }

    private void Update()
    {
        newAudio.volume = volume;

        if (!newAudio.isPlaying)
        {
            ChangeMusic(Random.Range(0, songs.Length));
        }
    }

    public void ChangeMusic(int songPicked)
    {
        newAudio.clip = songs[songPicked];
        newAudio.Play();
    }
    
}
