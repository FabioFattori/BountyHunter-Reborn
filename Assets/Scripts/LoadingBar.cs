using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Unity.VisualStudio.Editor;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LoadingBar : MonoBehaviour
{
    public int maxValue = 100;
    public int currentValue = 0;

    private String[] frases = new String[] { "Loading...", "Please wait...", "Almost there...", "Just a moment..." };

    private List<Text> oldText = new List<Text>();
    public void incrementCurrentValue()
    {
        if (currentValue < maxValue)
        {
            currentValue++;

            if (oldText.Count != 0)
            {
                foreach (Text txt in oldText)
                {
                    txt.gameObject.SetActive(false);
                }
            }

            var text = new GameObject().AddComponent<Text>();
            text.transform.SetParent(this.transform);
            text.text = frases[UnityEngine.Random.Range(0, frases.Length)]; 
            text.font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
            text.fontSize = 25;
            text.color = Color.black;
            text.alignment = TextAnchor.MiddleCenter;
            text.rectTransform.sizeDelta = new Vector2(200, 50);
            text.rectTransform.anchoredPosition = new Vector2(0, 0);
            oldText.Add(text);

        }
    }
}
