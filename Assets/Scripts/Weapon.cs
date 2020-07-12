using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // public Transform firepoint;
    [SerializeField] GameObject [] bulletPrefab;
    float timer;

    // Update is called once per frame
    void Start()
    {
        timer = Random.Range(1f, 5f);
    }
    void FixedUpdate()
    {
        if(timer < 0) {
            timer = Random.Range(1f, 5f);
            Instantiate(bulletPrefab[(int)(Random.Range(0, bulletPrefab.Length))], transform.position, transform.rotation);
        }
        timer -= Time.deltaTime;
    }
}
