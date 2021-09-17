using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestControl : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject player, dayLight;
    Animator anim;
    ItemHandle itemHandle;
    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        gameObject.transform.GetChild(6).gameObject.SetActive(false);
        dayLight = GameObject.FindGameObjectWithTag("DayLight").transform.GetChild(0).gameObject;
        gameObject.transform.GetChild(5).gameObject.transform.rotation = Quaternion.Euler(-90f,0f,0f);
        gameObject.transform.GetChild(6).gameObject.transform.rotation = Quaternion.Euler(-90f,0f,0f);
        itemHandle = GameObject.Find("Character").GetComponent<ItemHandle>();
        if (GameObject.Find("Character") != null)
            itemHandle = GameObject.Find("Character").GetComponent<ItemHandle>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject??false){
            float distance = Vector3.Distance(player.transform.position, transform.position);
            if (distance > 25f)
                Destroy(gameObject);
            else{
                if (dayLight.activeSelf)
                    gameObject.transform.GetChild(5).gameObject.SetActive(false);
                else
                    gameObject.transform.GetChild(5).gameObject.SetActive(true);
                    
                
                if (distance < 3f && Input.GetKeyDown(KeyCode.F)){
                    itemHandle.openChestSound.Play();
                    anim.Play("Open");
                    itemHandle.chests++;
                    gameObject.transform.GetChild(6).gameObject.SetActive(true);
                    Destroy(gameObject, 3.5f);
                }
            }
        }
    }

    void OnCollisionEnter(Collision collision){
        if (collision.gameObject.tag == "Pond"){
            Destroy(gameObject);
        }
    }
}
