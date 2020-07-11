using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine.Tilemaps;
using UnityEngine;


public class tilemapLoop : MonoBehaviour
{
    public GameObject[] levels1;
    private Camera mainCamera;
    private Vector2 screenBounds;
    public float choke1;
    public float scrollSpeed1;

    void Start()
    {
        mainCamera = gameObject.GetComponent<Camera>();
        screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
        foreach (GameObject obj in levels1)
        {
            loadChildObjects(obj);
        }
    }
    void loadChildObjects(GameObject obj)
    {
        float objectWidth = obj.GetComponent<TilemapRenderer>().bounds.size.x - choke1;
        int childsNeeded = (int)Mathf.Ceil(screenBounds.x * 2 / objectWidth)+1;
        GameObject clone = Instantiate(obj) as GameObject;
        for (int i = 0; i <= childsNeeded; i++)
        {
            GameObject c = Instantiate(clone) as GameObject;
            c.transform.SetParent(obj.transform);
            c.transform.position = new Vector3(objectWidth * i, obj.transform.position.y, obj.transform.position.z);
            c.name = obj.name + i;
        }
        Destroy(clone);
        Destroy(obj.GetComponent<TilemapRenderer>());
    }
    void repositionChildObjects(GameObject obj)
    {
        Transform[] children = obj.GetComponentsInChildren<Transform>();
        if (children.Length > 1)
        {
            GameObject firstChild = children[1].gameObject;
            GameObject lastChild = children[children.Length - 1].gameObject;
            float halfObjectWidth = lastChild.GetComponent<TilemapRenderer>().bounds.extents.x - choke1;
            if (transform.position.x + screenBounds.x > lastChild.transform.position.x)
            {
                firstChild.transform.SetAsLastSibling();
                firstChild.transform.position = new Vector3((lastChild.transform.position.x + halfObjectWidth * 2)-3, lastChild.transform.position.y, lastChild.transform.position.z);
            }
            else if (transform.position.x - screenBounds.x < firstChild.transform.position.x - halfObjectWidth)
            {
                lastChild.transform.SetAsFirstSibling();
                lastChild.transform.position = new Vector3(firstChild.transform.position.x - halfObjectWidth * 2, firstChild.transform.position.y, firstChild.transform.position.z);
            }
        }
    }
    void Update()
    {

        Vector3 velocity = Vector3.zero;
        Vector3 desiredPosition = transform.position + new Vector3(scrollSpeed1, 0, 0);
        Vector3 smoothPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, 0.3f);
        transform.position = smoothPosition;

    }
    void LateUpdate()
    {
        foreach (GameObject obj in levels1)
        {
            repositionChildObjects(obj);
        }
    }
}
