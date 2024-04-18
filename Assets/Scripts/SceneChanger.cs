using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChanger : MonoBehaviour
{
    public enum Scene
    {
        MainMenu,
        OpenWorld,
        Hub,
        GameOver
    }

    public GameObject LoadingScreenObject;
    public LoadingBar loadingBar;
    public Scene CurrentScene;



    public void ChangeScene(Scene scene)
    {
        CurrentScene = scene;
        switch (scene)
        {
            case Scene.OpenWorld:
                LoadScene("OpenWorld");
                break;
            case Scene.Hub:
                LoadScene("Hub");
                break;
            case Scene.MainMenu:
                LoadScene("BountyHunter");
                break;
            default:
                LoadScene("OpenWorld");
                break;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (CurrentScene == Scene.MainMenu)
        {
            LoadingScreenObject.SetActive(true);
            ChangeScene(Scene.OpenWorld);
        }
        else
        {
            //change the display of the loading screen
            LoadingScreenObject.SetActive(false);
        }
    }

    private void LoadScene(string sceneName)
    {
        StartCoroutine(LoadSceneAsync(sceneName));
    }

    private IEnumerator LoadSceneAsync(string sceneName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        LoadingScreenObject.SetActive(true);

        while (!operation.isDone)
        {
            loadingBar.incrementCurrentValue();
            //wait for the next frame
            yield return new WaitForEndOfFrame();
        }

        LoadingScreenObject.SetActive(false);

    }
}
