using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSky : MonoBehaviour
{
    // Start is called before the first frame update
    public Material day, night;
    public GameObject lightObject, lightDay, fadeScreen, fireflies;
    Light light;
    bool current = true, check = false;
    void Start()
    {
        RenderSettings.skybox = day;  
        light = lightObject.GetComponent<Light>();
        light.intensity = 2f;
        lightDay.SetActive(true);
        fireflies.SetActive(false);
    }

    // Update is called once per frame
    
    void Update()
    {
        if (Time.timeScale == 0f)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4)){
            changeSky();
        }
        if (check){
            if (current){
                RenderSettings.skybox = night;
                light.intensity = 1.0f;
                lightDay.SetActive(false);
                fireflies.SetActive(true);
                current  = false;
            } else {
                RenderSettings.skybox = day;
                light.intensity = 2f;
                lightDay.SetActive(true);
                fireflies.SetActive(false);
                current = true;
            }
            check = false;
        }
    }

    public void changeSky()
    {
        fadeScreen.SetActive(false);
        fadeScreen.SetActive(true);
        StartCoroutine(wait());
    }
    IEnumerator wait() {
        if (current)
            yield return new WaitForSeconds(0.7f);
        else 
            yield return new WaitForSeconds(1f);
        check = true;
    }
    
}
