using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ItemHandle : MonoBehaviour
{
    // Start is called before the first frame update
    public Text itemText;
    public int items = 0;
    public int threshHold = 3;

    public Transform[] checkpoint;
    public float wait_time = 1f;
    public AudioSource[] soundEffects;
    AudioSource collectSound;
    void Start()
    {
        itemText.text = "Items: " + items;
        soundEffects = GetComponents<AudioSource>();
        collectSound = soundEffects[1];
    }

    // Update is called once per frame
    void Update()
    {
        if (items == threshHold)
        {
            StartCoroutine(LoadTransition(SceneManager.GetActiveScene().buildIndex + 1));
        }
        itemText.text = "Items: " + items;
    }

    IEnumerator LoadTransition(int ScreenIndex)
    {
        yield return new WaitForSeconds(wait_time);
        SceneManager.LoadScene(ScreenIndex);
    }

    private void OnTriggerEnter(Collider other)
    {
      if(other.gameObject.CompareTag("item"))
           collectSound.Play();
    }

}

