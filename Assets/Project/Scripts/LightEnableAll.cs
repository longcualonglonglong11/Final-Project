using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightEnableAll : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var lights = FindObjectsOfType<Light>();
        Debug.Log(lights.Length);
        for(int i = 0; i < lights.Length; ++i)
            lights[i].enabled = true;
    }
}
