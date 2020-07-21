using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class CarSpawner : MonoBehaviour
{
    [SerializeField] private GameObject [] prefab;
    public float Timer = 6f;
    bool hasSpawned = false;
    [SerializeField] private AudioSource audioData;
    // Start is called before the first frame update
    //void Start()
    //{
    //    StartCoroutine(SpawnDelay(prefab[(int)Random.Range(0,prefab.Length)]));
    //}
    private void FixedUpdate()
    {
        if (!hasSpawned)
        {
            int index = (int)Random.Range(0, prefab.Length);
            // int index = 2;
            if(index == 0)
            {
                //audioData.GetComponent<AudioSource>();
                //audioData.Play(0);
                StartCoroutine(PlayCarSound());
            }
            StartCoroutine(SpawnDelay(index));
            hasSpawned = true;
        }
    }

    private IEnumerator SpawnDelay(int index)
    {
        GameObject obj = prefab[index];
        yield return new WaitForSeconds(Timer);
        if(index == 4 || index == 3)
        {
            //Spinny blade
            Vector2 spawn = new Vector2(transform.position.x, 3f);
            Instantiate(obj, spawn, transform.rotation);
        }
        else
            Instantiate(obj, transform.position, transform.rotation);
        hasSpawned = false;
    }

    private IEnumerator PlayCarSound()
    {
        //Debug.Log("b4");
        yield return new WaitForSeconds(1f);
        audioData.GetComponent<AudioSource>();
        audioData.Play(0);
        //Debug.Log("after");
    }
}
