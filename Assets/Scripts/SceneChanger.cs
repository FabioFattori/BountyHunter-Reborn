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
    public Slider loadingBarFill;
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
            default:
                LoadScene("OpenWorld");
                break;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        ChangeScene(Scene.OpenWorld);
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
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            
            loadingBarFill.value = progress;
            yield return null;
        }
    }
}
