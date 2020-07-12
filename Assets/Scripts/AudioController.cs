using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioSource audioData;
    
    void Start()
    {
        audioData.GetComponent<AudioSource>();
        audioData.Play(0);
    }

}
