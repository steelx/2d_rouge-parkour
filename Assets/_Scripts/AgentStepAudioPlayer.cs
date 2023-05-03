using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AgentStepAudioPlayer : MonoBehaviour
{
    AudioSource audioSource;

    [SerializeField] AudioClip stepClip;
    [SerializeField] protected float pitchRandomness = 0.05f;
    protected float basePitch = 1f;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        basePitch = audioSource.pitch;
    }

    protected void PlayClip(AudioClip clip)
    {
        audioSource.Stop();
        audioSource.clip = clip;
        audioSource.Play();
    }

    protected void PlayClipWithVariablePitch(AudioClip clip)
    {
        audioSource.pitch = basePitch + Random.Range(-pitchRandomness, pitchRandomness);
        PlayClip(clip);
    }

    public void PlayStepAudio()
    {
        PlayClipWithVariablePitch(this.stepClip);
    }
}
