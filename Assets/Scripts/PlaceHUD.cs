using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceHUD : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var healtBar = GameObject.Find("PlayerHealthBar").gameObject;
        //position the healtbar in the bottom left corner
        RectTransform rt = healtBar.GetComponent<RectTransform>();
        rt.anchorMin = new Vector2(0, 0);
        rt.anchorMax = new Vector2(0.2f, 0.2f);
        rt.pivot = new Vector2(0, 0);
        rt.anchoredPosition = new Vector2(0, 0);
        rt.sizeDelta = new Vector2(0, 0);
        rt.localScale = new Vector3(1, 1, 1);
        rt.localRotation = Quaternion.Euler(0, 0, 0);

    }

    
}
