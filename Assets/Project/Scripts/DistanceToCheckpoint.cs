using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;     

public class DistanceToCheckpoint : MonoBehaviour {

    // Reference to checkpoint position
    [SerializeField]
    private int currentitemId;
    // Reference to UI text that shows the distance value
    [SerializeField]
    private Text distanceText;

    // Calculated distance value
    private float distance;
    public ItemHandle itemHandle;
    private int lastCurItemId;
    private int marginItem = 2;
    private bool firstTime = true;
    public void Start()
    {
        itemHandle = GameObject.Find("Character").GetComponent<ItemHandle>();
        currentitemId = 0;
        lastCurItemId = 0;
    }
    // Update is called once per frame
    private void Update()
    {
        if (itemHandle.items == itemHandle.total)
        {
            return;
        }

        if (lastCurItemId != itemHandle.items || firstTime)
        {
            float min = 9999999f;

            for(int j = 0; j < itemHandle.itemsPos.Length; j++)
            {
                if (itemHandle.gameObjects[j] == null) continue;

                float curMag = (itemHandle.itemsPos[j] - transform.position).magnitude;
                if (min > curMag)
                {
                    currentitemId = j;
                    min = curMag;
                }
            }
            lastCurItemId = itemHandle.items;
            firstTime = false;
        }

        
        // Calculate distance value between character and checkpoint
        distance = (itemHandle.itemsPos[currentitemId] - transform.position).magnitude - marginItem;

        // Display distance value via UI text
        // distance.ToString("F1") shows value with 1 digit after period
        // so 12.234 will be shown as 12.2 for example
        // distance.ToString("F2") will show 12.23 in this case
        distanceText.text = "Distance: " + distance.ToString("F1") + " m";
    }

}
