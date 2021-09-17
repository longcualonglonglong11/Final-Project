using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject rabbit, lightDay;
    GameObject player, r, child1, child2;
    float respawnTime = 1f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(spawnRabbit());
    }

    // Update is called once per frame
    void spawn(){
        r = Instantiate(rabbit) as GameObject;
        child1 = r.transform.GetChild(1).gameObject;
        child2 = r.transform.GetChild(1).gameObject;
        child1.SetActive(false);
        child2.SetActive(false);
        //r.transform.localScale = new Vector3(0,0,0);
        //r.transform.position = player.transform.position + new Vector3(Random.Range(3,10),0,Random.Range(3,10));
        float rand1 = Random.Range(7,14);
        float rand2;
        if(Random.value<0.5f)
            rand2 = 1;
        else
            rand2 = -1;
        float randx = rand1 * rand2;
        if(Random.value<0.5f)
            rand2 = 1;
        else
            rand2 = -1;
        float randz = rand1 * rand2;
        r.transform.position = player.transform.position + new Vector3(randx,0.2f,randz);
        r.transform.Rotate(0, Random.Range(0,360),0);     
    }

    IEnumerator spawnRabbit(){
        while(true){
            int rnumber = GameObject.FindGameObjectsWithTag("Rabbit").Length;
            if (rnumber < 5 && lightDay.activeSelf) spawn();
            //r.SetActive(true);
            yield return new WaitForSeconds(respawnTime);
            if(r??false){
                child1.SetActive(true);
                child2.SetActive(true);
            }
        }
    }

}
