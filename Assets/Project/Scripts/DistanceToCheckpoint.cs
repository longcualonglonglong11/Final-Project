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
    private int lastCount;
    public void Start()
    {
        itemHandle = GameObject.Find("Character").GetComponent<ItemHandle>();
        currentitemId = 0;
        lastCount = 0;
    }
    // Update is called once per frame
    private void Update()
    {
        if (itemHandle.items == itemHandle.checkpoint.Length)
        {
            return;
        }

        if (lastCount < itemHandle.items)
        {
            int i = 0;
            while(true)
            {
                if (itemHandle.checkpoint[i] != null)
                {
                    currentitemId = i;
                    Debug.Log(currentitemId);
                    break;
                }
                i++;
                if (i == itemHandle.checkpoint.Length)
                {
                    i = 0;
                }
            }

        }
        // Calculate distance value between character and checkpoint
        distance = (itemHandle.checkpoint[currentitemId].transform.position - transform.position).magnitude;

        // Display distance value via UI text
        // distance.ToString("F1") shows value with 1 digit after period
        // so 12.234 will be shown as 12.2 for example
        // distance.ToString("F2") will show 12.23 in this case
        distanceText.text = "Distance: " + distance.ToString("F1") + " m";
    }

}
