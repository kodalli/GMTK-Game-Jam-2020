using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform objectTransform;

    private float deltaX;

    void Start()
    {
        objectTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        deltaX = transform.position.x - objectTransform.position.x;
        transform.position = new Vector3(objectTransform.position.x + deltaX, transform.position.y, transform.position.z);
    }
}
