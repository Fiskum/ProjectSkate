using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TempoChanger : MonoBehaviour
{
    public AudioSource audioSource;

    [Range(0.6f, 1.4f)]
    public float audioSpeed;
    public Slider pitch;

    private void Start()
    {
        
        audioSpeed = 1;
        audioSource.pitch = audioSpeed;
        audioSource.outputAudioMixerGroup.audioMixer.SetFloat("Pitch", 1f / audioSpeed);
    }
    void Update()
    {
        audioSource.pitch = audioSpeed;
        audioSpeed = Mathf.Log10(pitch.value) * 0.8f;
        audioSource.outputAudioMixerGroup.audioMixer.SetFloat("Pitch", 1f / audioSpeed);
    }
}
