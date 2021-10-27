using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpeedMonitor : MonoBehaviour
{
    public Rigidbody _rigidbody;
    TextMeshProUGUI mText;
    // Start is called before the first frame update
    void Start()
    {
        mText = gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        int mph = (int)(_rigidbody.velocity.magnitude * 2.236936f);
        mText.text = mph.ToString() + "MPH";
    }
}
