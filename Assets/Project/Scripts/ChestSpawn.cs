using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject chest;
    GameObject player;
    float respawnTime = 1f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(spawnChest());
    }

    // Update is called once per frame
    void spawnc(){
        GameObject c = Instantiate(chest) as GameObject;
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
        c.transform.position = player.transform.position + new Vector3(randx,0.2f,randz);
        c.transform.Rotate(0, Random.Range(0,360),0);
    }

    IEnumerator spawnChest(){
        while(true){
            int cnumber = GameObject.FindGameObjectsWithTag("Chest").Length;
            if (cnumber < 4) spawnc();
            yield return new WaitForSeconds(respawnTime);
        }
    }
}
