﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    void OnTriggerEnter(Collider other) 
    {
        GameManager.Instance.trackFinished = true;
    }
}
