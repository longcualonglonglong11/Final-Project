using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class ItemHandle : MonoBehaviour
{
    // Start is called before the first frame update
    public Text itemText;
    public Text chestText;
    public int items = 0;
    public int chests = 0;
    public Transform[] checkpoint;
    public GameObject[] itemObjects;
    public GameObject itemCanvas, distCanvas, chestCanvas;
    public float wait_time = 1f;
    public AudioSource[] soundEffects;
    AudioSource collectSound;
    public List<GameObject> gameObjects;
    public int total;
    public Vector3[] itemsPos;
    private ChangeSky skyHandler;
    public int threshHoldForChangeSky = 60;
    private long lastTime;
    public Vector3 originPo;
    public AudioSource openChestSound;
    public AudioSource jumpSound;
    void Start()
    {
        skyHandler = GameObject.FindGameObjectWithTag("Enviroment").GetComponent<ChangeSky>();
        itemText.text = "Items: " + items;
        chestText.text = "Chests: " + chests;
        soundEffects = GetComponents<AudioSource>();
        collectSound = soundEffects[1];
        openChestSound = soundEffects[3];
        jumpSound = soundEffects[0];
        originPo = GameObject.FindGameObjectWithTag("Player").transform.position;
        itemsPos = new Vector3[]
        {
            new Vector3(46, 40, 168),
/*            new Vector3(232, 46, 168),
            new Vector3(97, 44, 171),
            new Vector3(70, 42, 170),
            new Vector3(92, 43, 170),
            new Vector3(95, 47, 204),
            new Vector3(93, 58, 56),
            new Vector3(90 , 60, 91),
            new Vector3(175, 36, 291),
            new Vector3(285, 35, 276),
            new Vector3(282, 40, 196),
            new Vector3(270, 38, 165),
            new Vector3(286, 40, 43),
            new Vector3(196, 40, 34),
            new Vector3(257, 45, 33),
            new Vector3(248, 59, 117),
            new Vector3(47, 50, 117),
            new Vector3(202, 33, 295),
            new Vector3(96, 33, 295),
            new Vector3(250, 47, 278)
*/        };
        total = itemsPos.Length;
        gameObjects = new List<GameObject>();
        for (int i = 0; i < itemsPos.Length; i++)
        {
            Vector3 item = itemsPos[i];
            float rand = Random.Range(0, itemObjects.Length - 1);
            GameObject randItem = itemObjects[(int)rand];
            randItem.name = i.ToString();
            gameObjects.Add(randItem);
            GameObject itemObject = Instantiate(randItem) as GameObject;
            float rand1 = Random.Range(0, 3);
            float rand2 = Random.Range(0, 1);
            float rand3 = Random.Range(0, 3);
            itemObject.transform.position = new Vector3(item.x + rand1, item.y + rand2, item.z + rand3);
        }
        lastTime = new System.DateTimeOffset(System.DateTime.Now).ToUnixTimeSeconds();
    }
    // Update is called once per frame
    void Update()
    {
        if (items == total)
        {
            StartCoroutine(LoadTransition(SceneManager.GetActiveScene().buildIndex + 1));
        }
        itemText.text = "Items: " + items;
        chestText.text = "Chest: " + chests;
        long currentTime = new System.DateTimeOffset(System.DateTime.Now).ToUnixTimeSeconds();

        if (currentTime - lastTime > threshHoldForChangeSky)
        {
            skyHandler.changeSky();
            lastTime = currentTime;
        }
        if (Input.GetKey(KeyCode.Tab))
        {
            itemCanvas.SetActive(true);
            distCanvas.SetActive(true);
            chestCanvas.SetActive(true);

        }
        else
        {
            itemCanvas.SetActive(false);
            distCanvas.SetActive(false);
            chestCanvas.SetActive(false);
        }
    }

    IEnumerator LoadTransition(int ScreenIndex)
    {
        yield return new WaitForSeconds(wait_time);
        SceneManager.LoadScene(ScreenIndex);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("item"))
        {
            collectSound.Play();
        }
    }

}