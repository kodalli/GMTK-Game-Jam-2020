using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarenAudio : MonoBehaviour
{
    [SerializeField] private AudioSource audioData1;
    [SerializeField] private AudioSource audioData2;
    [SerializeField] private AudioSource audioData3;
    [SerializeField] private AudioSource audioData4;
    public AudioSource [] sound;
    bool isPlaying = false;
    private void Start()
    {
        sound = GetComponents<AudioSource>();
    }

    private void FixedUpdate()
    {
        if (!isPlaying)
        {
            StartCoroutine(PlaySound());
            isPlaying = true;
        }
    }

    private IEnumerator PlaySound()
    {
        sound[(int)(Random.Range(0,sound.Length))].Play(0);
        yield return new WaitForSeconds(30f);
        isPlaying = false;
    }
}
