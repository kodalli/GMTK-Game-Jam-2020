using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(prefab, transform.position, transform.rotation);
    }
}
