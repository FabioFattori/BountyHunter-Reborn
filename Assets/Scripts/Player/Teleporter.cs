using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UI;

public class Teleporter : MonoBehaviour
{
    public SceneChanger sceneChanger;
    private bool sceneIsChanged = false;
    public Slider loadingBar;

    public SceneChanger.Scene destination;

    public int maxLoadingTime = 100;
    public float loadingPerSecond = 1;

    private bool isTeleporting = false;

    void Start()
    {
        //make sure the loading bar is not visible
        loadingBar.gameObject.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.B)){
            isTeleporting = !isTeleporting;
            if(!isTeleporting){
                loadingBar.gameObject.SetActive(false);
            }else{
                loadingBar.gameObject.SetActive(true);
            }
        }
        TeleportPlayer();
    }

    public void cancelTeleport(){
        isTeleporting = false;
        loadingBar.gameObject.SetActive(false);
    }

    public void TeleportPlayer(){
        if(isTeleporting){
            loadingBar.gameObject.SetActive(true);
            StartCoroutine(Teleport());
        }
    }

    IEnumerator Teleport(){
        float loadingTime = 0;
        while(loadingTime < maxLoadingTime && isTeleporting){
            loadingTime += loadingPerSecond;
            loadingBar.value = loadingTime;
            Debug.Log("Loading: " + loadingBar.value);
            yield return null;
        }
        if(loadingTime == maxLoadingTime && sceneIsChanged == false){
            sceneIsChanged = true;
            sceneChanger.ChangeScene(destination);
        }
    }
}
