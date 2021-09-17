using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemHandle itemHandle;
    // Start is called before the first frame update
    void Start()
    {
        itemHandle = GameObject.Find("Character").GetComponent<ItemHandle>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        int curIndex = System.Int32.Parse(gameObject.name.Replace("(Clone)", ""));
        itemHandle.gameObjects[curIndex] = null;
        itemHandle.items++;
        Destroy(gameObject);
    }
}
