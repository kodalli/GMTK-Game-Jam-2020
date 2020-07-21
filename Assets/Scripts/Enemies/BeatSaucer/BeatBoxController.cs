using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatBoxController : MonoBehaviour
{
    private Vector3 startPos;
    private float camerax;
    [SerializeField] private float xoffset = 0f;

    void Start()
    {
        startPos = transform.position;
    }

    void FixedUpdate()
    {
        camerax = GameObject.FindGameObjectWithTag("Player").transform.position.x;
        transform.position = startPos + new Vector3(camerax+xoffset, Mathf.Sin(Time.time), 0.0f);
    }
}
