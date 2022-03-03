using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempoChanger : MonoBehaviour
{
    public AudioSource audioSource;

    [Range(0.5f, 2)]
    public float audioSpeed;

    private void Start()
    {
        audioSource.pitch = audioSpeed;
        audioSource.outputAudioMixerGroup.audioMixer.SetFloat("Pitch", 1f / audioSpeed);
    }
    void Update()
    {
        audioSource.pitch = audioSpeed;
        audioSource.outputAudioMixerGroup.audioMixer.SetFloat("Pitch", 1f / audioSpeed);
    }
}
