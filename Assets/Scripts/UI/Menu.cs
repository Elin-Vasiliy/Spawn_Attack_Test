﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject Panel;

    public void OpenPan()
    {
        Panel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ClosePan()
    {
        Panel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Exit()
    {
        Application.Quit();
    }
}