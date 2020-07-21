using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSpeed : MonoBehaviour
{
    float x = 2f;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = x;
        Time.fixedDeltaTime *= Time.timeScale;
        // StartCoroutine(Delay());
    }

    
    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(3f);
        Time.fixedDeltaTime *= Time.timeScale;
    }
}
