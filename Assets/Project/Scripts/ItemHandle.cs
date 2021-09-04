using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemHandle : MonoBehaviour
{
    // Start is called before the first frame update
    public Text itemText;
    public int items = 0;
    public Transform[] checkpoint;
    void Start()
    {
        itemText.text = "Items: " + items;
    }

    // Update is called once per frame
    void Update()
    {
        itemText.text = "Items: " + items;
    }
}
