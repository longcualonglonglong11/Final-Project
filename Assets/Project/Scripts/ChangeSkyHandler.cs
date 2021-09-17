using UnityEngine;

public class ChangeSkyHandler : MonoBehaviour
{
    public int threshHoldForChangeSky = 60;
    public Vector3[] itemsPos;
    private ChangeSky skyHandler;
    private long lastTime;

    void Start()
    {
        skyHandler = GameObject.FindGameObjectWithTag("Enviroment").GetComponent<ChangeSky>();
        lastTime = new System.DateTimeOffset(System.DateTime.Now).ToUnixTimeSeconds();
    }
    // Update is called once per frame
    void Update()
    {
        long currentTime = new System.DateTimeOffset(System.DateTime.Now).ToUnixTimeSeconds();
        if (currentTime - lastTime > threshHoldForChangeSky)
        {
            skyHandler.changeSky();
            lastTime = currentTime;
        }

    }
}