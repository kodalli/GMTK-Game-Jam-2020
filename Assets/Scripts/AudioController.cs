using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioSource audioData;
    [SerializeField] private AudioSource audioData2;
    void Start()
    {
        audioData.GetComponents<AudioSource>();
        audioData2.GetComponents<AudioSource>();
        audioData.Play(0);
        audioData2.Play(0);
    }

}
