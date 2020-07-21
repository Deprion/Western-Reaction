﻿using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioClip[] music;
    public AudioSource audioSource;
    private AudioClip lastClip;
    private void Start()
    {
        lastClip = music[Random.Range(0, music.Length - 1)];
        audioSource.PlayOneShot(lastClip);
    }
    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("music");
        if (objs.Length > 1)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    private void Update()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(RandomAudio());
        }
    }
    private AudioClip RandomAudio()
    {
        int attempts = 3;
        AudioClip newClip = music[Random.Range(0, music.Length - 1)];
        while (newClip == lastClip && attempts > 0)
        {
            newClip = music[Random.Range(0, music.Length - 1)];
            attempts--;
        }
        lastClip = newClip;
        return newClip;
    }
}
