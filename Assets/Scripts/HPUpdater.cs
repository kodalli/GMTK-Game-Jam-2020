using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HPUpdater : MonoBehaviour
{
    TextMeshPro healthPoints;
    void Start()
    {
        healthPoints = GetComponent<TextMeshPro>();
    }
    void Update()
    {
        UpdateHealth();
    }
    private void UpdateHealth()
    {
        healthPoints.text = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().health.ToString();
    }
}
