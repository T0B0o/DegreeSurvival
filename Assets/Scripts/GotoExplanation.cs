﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GotoExplanation : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Jump()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Explain");
    }
}
