using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TimeMonitor : MonoBehaviour
{
    public float timer = 0f;
    TextMeshProUGUI mText;

    void Start() {
        mText = gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Instance.trackFinished && !GameManager.Instance.startRace) timer += Time.deltaTime;
        mText.text = TimeSpan.FromSeconds(timer).ToString("mm\\:ss\\.ff");
    }
}
