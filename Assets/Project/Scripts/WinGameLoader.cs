using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

public class WinGameLoader : MonoBehaviour
{
    public Animator transition;
    public float wait_time = 1f;

    IEnumerator LoadTransition(int ScreenIndex)
    {
        transition.SetTrigger("ChangeScreen");
        yield return new WaitForSeconds(wait_time);
        SceneManager.LoadScene(ScreenIndex);
    }

    IEnumerator Sleep(int sec)
    {
        yield return new WaitForSeconds(sec);
    }

    async void Start()
    {
        await Task.Delay(4000);
        StartCoroutine(LoadTransition(0));

    }

    private void Update()
    {
    }
    public void Quit()
    {
        Application.Quit();
    }
}