using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField] private AudioClip[] clips;
    private AudioSource _audioSource;
    private int _currentClipId;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        _audioSource.clip = clips[0];
        _audioSource.Play();
        _currentClipId++;
        Invoke(nameof(PlayClip),_audioSource.clip.length+10);
    }

    private void PlayClip()
    {
        if (_currentClipId > clips.Length) _currentClipId = 0;
        _audioSource.clip = clips[_currentClipId];
        _audioSource.Play();
        _currentClipId++;
    }
}