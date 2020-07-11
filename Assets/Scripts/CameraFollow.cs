using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform objectTransform;

    private float deltaX = 0.0f;

    void Start()
    {
        deltaX = transform.position.x - objectTransform.position.x;
    }

    void Update()
    {
        transform.position = new Vector3(objectTransform.position.x + deltaX, transform.position.y, transform.position.z);
    }
}
